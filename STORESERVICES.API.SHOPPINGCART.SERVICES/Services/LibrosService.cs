using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using STORESERVICES.API.SHOPPINGCART.SERVICES.DTO.Response;
using STORESERVICES.API.SHOPPINGCART.SERVICES.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace STORESERVICES.API.SHOPPINGCART.SERVICES.Services
{
    public class LibrosService : ILibrosService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<LibrosService> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LibrosService(IHttpClientFactory httpClient, ILogger<LibrosService> logger, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<(bool resultado, LibroRemote Libro, string ErrorMessage)> GetLibro(Guid LibroId)
        {
            try
            {
                var httpContext = _httpContextAccessor.HttpContext;

                // Read JWT
                var jwt = httpContext.Request.Headers["Authorization"].ToString();

                var cliente = _httpClient.CreateClient("Libros");
                cliente.DefaultRequestHeaders.Add("Authorization", jwt);
                var response = await cliente.GetAsync($"api/LibroMaterial/{LibroId}");
                if (response.IsSuccessStatusCode)
                {
                    var contenido = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var resultado = JsonSerializer.Deserialize<LibroRemote>(contenido, options);
                    return (true, resultado, null);
                }

                return (false, null, response.ReasonPhrase);

            }
            catch (Exception e)
            {
                _logger?.LogError(e.ToString());
                return (false, null, e.Message);
            }
        }
    }
}
