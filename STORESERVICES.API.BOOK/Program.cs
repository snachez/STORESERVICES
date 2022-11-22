using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using STORESERVICES.API.BOOK.DAO;
using STORESERVICES.API.BOOK.DAO.Data;
using STORESERVICES.API.BOOK.SERVICES;

namespace STORESERVICES.API.BOOK
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

            builder.Services.AddDbContext<ContextoLibreria>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionDB"));
            });

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "STORESERVICES.API.BOOK", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "STORESERVICES.API.BOOK v1"));
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}