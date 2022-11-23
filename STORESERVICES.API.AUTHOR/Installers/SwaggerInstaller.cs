using Microsoft.OpenApi.Models;
using STORESERVICES.API.AUTHOR.SERVICES.Common;

namespace STORESERVICES.API.AUTHOR.Installers
{
    public class SwaggerInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //Configure Swagger
            // Set the comments path for the Swagger JSON and UI.
            services.AddEndpointsApiExplorer();

            var xmlFile = "STORESERVICES.API.AUTHOR.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            CreateXml DocXml = new();
            DocXml.Xml(xmlPath);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "STORESERVICES.API.AUTHOR API",
                    Description = "API de servicios de autor",
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
                //c.AddSecurityDefinition("Bearer", new OAuth2Scheme
                //{
                //    Type = "Bearer",
                //    Flow = "password",
                //    TokenUrl = Path.Combine("https://coworkingidentity.azurewebsites.net/token"),
                //    // Optional scopes
                //    Scopes = new Dictionary<string, string>
                //        {
                //            { "api1", "client" },
                //        }
                //});
            });
        }
    }
}
