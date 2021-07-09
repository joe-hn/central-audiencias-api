using ListaReproduccionAudiencia.Service.Proxies.IProxies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ListaReproduccionAudiencia.Service.Proxies.Proxies
{
    public class ListaReproduccionProxy: IListaReproduccionProxy
    {
        private readonly ApiUrl apiUrl;
        private readonly HttpClient httpClient;

        public ListaReproduccionProxy(ApiUrl apiUrl, HttpClient httpClient)
        {
            this.apiUrl = apiUrl;
            this.httpClient = httpClient;
        }

        public async Task<string> ListaAudiencias()
        {
            //var response = await httpClient.GetAsync(apiUrl.AnunciosUrl + "api/Anuncio/GetDate?FechaActual=" + FechaActual.ToString("yyyy-MM-dd"));
            //return await response.Content.ReadAsStringAsync();

            throw new NotImplementedException();
        }
    }
}
