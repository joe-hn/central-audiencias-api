using ListaReproduccionAviso.Infrastructure.Entities;
using SEJE.EFCORE.Operations;
using System;

namespace ListaReproduccionAviso.Infrastructure.IRepositories
{
    public interface IAvisoRepository: IOperationBase<Guid, string, Aviso>
    {
    }
}
