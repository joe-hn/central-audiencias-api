using Anuncio.Infrastructure.Entities;
using SEJE.EFCORE.Operations;
using System;

namespace Anuncio.Infrastructure.IRepositories
{
    public interface IAvisoRepository: IOperationBase<Guid, string, Aviso>
    {
    }
}
