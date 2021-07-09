using ListaReproduccionAudiencia.Infrastructure.Entities;
using SEJE.EFCORE.Operations;
using System;

namespace ListaReproduccionAudiencia.Infrastructure.IRepositories
{
    public interface IParteRepository: IOperationBase<Guid, string, Parte>
    {
    }
}
