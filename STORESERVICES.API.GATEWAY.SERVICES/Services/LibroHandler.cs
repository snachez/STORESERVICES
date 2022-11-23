using Microsoft.Extensions.Logging;
using STORESERVICES.API.GATEWAY.DAO.Interfaces;
using STORESERVICES.API.GATEWAY.SERVICES.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace STORESERVICES.API.GATEWAY.SERVICES.Services
{
    public class LibroHandler : DelegatingHandler
    {
        private readonly ILogger<LibroHandler> _logger;

        private readonly IAutorRemoteDao _autorRemote;

        public LibroHandler(ILogger<LibroHandler> logger, IAutorRemoteDao autorRemote)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _autorRemote = autorRemote ?? throw new ArgumentNullException(nameof(autorRemote));
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            var tiempo = Stopwatch.StartNew();
            _logger.LogInformation("Inicia el request");
            var response = await base.SendAsync(request, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                var contenido = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var resultado = JsonSerializer.Deserialize<LibroModeloRemote>(contenido, options);
                var responseAutor = await _autorRemote.GetAuthor(resultado.AutorLibro ?? Guid.Empty);
                if (responseAutor.resultado)
                {
                    var objetoAutor = responseAutor.autor;
                    resultado.AutorData = objetoAutor;
                    var resultadoStr = JsonSerializer.Serialize(resultado);
                    response.Content = new StringContent(resultadoStr, System.Text.Encoding.UTF8, "application/json");
                }
            }

            _logger.LogInformation($"Este proceso se hizo en {tiempo.ElapsedMilliseconds}ms");

            return response;
        }

    }
}
