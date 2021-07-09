using ListaReproduccionAviso.Service.Proxies.IProxies;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;

using System.Threading.Tasks;

namespace ListaReproduccionAviso.Service.Proxies
{
    public class AnuncioProxy : IAnuncioProxy
    {
        private readonly ApiUrl apiUrl;
        private readonly HttpClient httpClient;

        public AnuncioProxy(IOptions<ApiUrl> apiUrl, HttpClient httpClient)
        {
            this.apiUrl = apiUrl.Value;
            this.httpClient = httpClient;
        }        

        public async Task<string> ListaAnunciosDiarios(DateTime FechaActual)
        {
            var response = await httpClient.GetAsync(apiUrl.AnunciosUrl + "api/Anuncio/GetDate?FechaActual=" + FechaActual.ToString("yyyy-MM-dd"));
            return await response.Content.ReadAsStringAsync();
        }
    }

   
}
