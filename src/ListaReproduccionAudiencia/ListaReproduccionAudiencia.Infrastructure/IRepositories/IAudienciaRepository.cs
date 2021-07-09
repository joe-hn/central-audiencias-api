using ListaReproduccionAudiencia.Infrastructure.Entities;
using SEJE.EFCORE.Operations;
using System;

namespace ListaReproduccionAudiencia.Infrastructure.IRepositories
{
    public interface IAudienciaRepository: IOperationBase<Guid, string, Audiencia>
    {
    }
}
