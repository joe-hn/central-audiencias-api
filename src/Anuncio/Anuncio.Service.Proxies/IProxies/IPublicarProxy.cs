using Anuncio.Service.Proxies.command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anuncio.Service.Proxies.IProxies
{
    public interface IPublicarProxy
    {
        Task Publicaraviso(PublicarAvisoCommand notification);
    }
}
