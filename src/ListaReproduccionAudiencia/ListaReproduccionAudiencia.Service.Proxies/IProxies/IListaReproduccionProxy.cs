using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaReproduccionAudiencia.Service.Proxies.IProxies
{
    public interface IListaReproduccionProxy
    {
        Task<string> ListaAudiencias();
    }
}
