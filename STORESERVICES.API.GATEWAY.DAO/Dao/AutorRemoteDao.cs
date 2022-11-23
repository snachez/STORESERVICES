using Microsoft.Extensions.Logging;
using STORESERVICES.API.GATEWAY.DAO.Interfaces;
using STORESERVICES.API.GATEWAY.MODEL.EntitiesRemote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace STORESERVICES.API.GATEWAY.DAO.Dao
{
    public class AutorRemoteDao : IAutorRemoteDao
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<AutorRemoteDao> _logger;

        public AutorRemoteDao(IHttpClientFactory httpClient, ILogger<AutorRemoteDao> logger)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<(bool resultado, AutorModeloRemote autor, string ErrorMessage)> GetAuthor(Guid AutorId)
        {
            try
            {
                var cliente = _httpClient.CreateClient("AutorService");
                var response = await cliente.GetAsync($"/Author/{AutorId}");
                if (response.IsSuccessStatusCode)
                {
                    var contenido = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var resultado = JsonSerializer.Deserialize<AutorModeloRemote>(contenido, options);
                    return (true, resultado, null);
                }

                return (false, null, response.ReasonPhrase);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return (false, null, e.Message);
            }

        }
    }
}
