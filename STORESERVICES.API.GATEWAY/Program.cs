using Microsoft.OpenApi.Models;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using STORESERVICES.API.GATEWAY.DAO;
using STORESERVICES.API.GATEWAY.SERVICES;

namespace STORESERVICES.API.GATEWAY
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            ConfigureServices(builder);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            Configure(app);

        }

        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
            builder.Services.AddOcelot();
            builder.Services.AddSwaggerForOcelot(builder.Configuration);

            builder.Services.AddSERVICESLayer();
            builder.Services.AddDAOLayer(builder.Configuration);

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "STORESERVICES.API.GATEWAY", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "STORESERVICES.API.GATEWAY v1"));
            }

            app.UseSwaggerForOcelotUI(opt => {
                opt.PathToSwaggerGenerator = "/swagger/docs";
            }).UseOcelot().Wait();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}