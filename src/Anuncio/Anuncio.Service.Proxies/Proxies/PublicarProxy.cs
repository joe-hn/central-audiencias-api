using Anuncio.Service.Proxies.command;
using Anuncio.Service.Proxies.IProxies;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Anuncio.Service.Proxies.Proxies
{
    public class PublicarProxy : IPublicarProxy
    {
        private readonly ApiUrl apiUrl;
        private readonly HttpClient httpClient;

        public PublicarProxy(IOptions<ApiUrl> apiUrl, HttpClient httpClient)
        {
            this.apiUrl = apiUrl.Value;
            this.httpClient = httpClient;
        }
        public async Task Publicaraviso(PublicarAvisoCommand notification)
        {
            HttpContent content = new StringContent(JsonSerializer.Serialize(notification), Encoding.UTF8, "application/json");
            await httpClient.PostAsync(apiUrl.ListaReproduccionUrl + "api/ListaReproduccionAviso/PublicarAviso", content);
        }
    }
}
