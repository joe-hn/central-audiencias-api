using System;
using System.Threading.Tasks;

namespace ListaReproduccionAviso.Service.Proxies.IProxies
{
    public interface IAnuncioProxy
    {       
        Task<string> ListaAnunciosDiarios(DateTime FechaActual);
    }
}
