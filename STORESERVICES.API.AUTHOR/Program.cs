using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using STORESERVICES.API.AUTHOR.DAO;
using STORESERVICES.API.AUTHOR.DAO.Data;
using STORESERVICES.API.AUTHOR.SERVICES;

namespace STORESERVICES.API.AUTHOR
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
            builder.Services.AddSERVICESLayer();
            builder.Services.AddDAOLayer();

            builder.Services.AddControllers();

            builder.Services.AddDbContext<ContextoAutor>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("ConexionDatabase"));
            });

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "STORESERVICES.API.AUTHOR", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "STORESERVICES.API.AUTHOR v1"));
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}