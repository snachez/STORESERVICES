using Microsoft.OpenApi.Models;
using STORESERVICES.API.BOOK.SERVICES.Common;

namespace STORESERVICES.API.BOOK.Installers
{
    public class SwaggerInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //Configure Swagger
            // Set the comments path for the Swagger JSON and UI.
            services.AddEndpointsApiExplorer();

            var xmlFile = "STORESERVICES.API.BOOK.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            CreateXml DocXml = new();
            DocXml.Xml(xmlPath);

            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "STORESERVICES.API.BOOK API",
                    Description = "API de servicios de libro",
                    TermsOfService = new Uri("https://policies.google.com/terms?hl=en-US"),
                    Contact = new OpenApiContact
                    {
                        Name = "Contacto de soporte a integraciones",
                        Email = "integration_support_contact@isystemcorp.io",
                        Url = new Uri("https://about.google/contact-google/?hl=es"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Licencia LICX",
                        Url = new Uri("https://opensource.google/documentation/reference/thirdparty/licenses"),
                    }
                });
                c.IncludeXmlComments(xmlPath);

                //TODO: Activar la sección de configuración.
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Copy and paste the Token in the 'Value:' field like this: Bearer {Token JWT}.",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                  {
                    new OpenApiSecurityScheme
                    {
                       Reference = new OpenApiReference
                       {
                         Type = ReferenceType.SecurityScheme,
                         Id = "Bearer"
                       }
                     },
                     new string[] { }
                  }
                });
            });
        }
    }
}
