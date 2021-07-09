using ListaReproduccionAudiencia.Infrastructure.Entities;
using ListaReproduccionAudiencia.Infrastructure.IRepositories;
using SEJE.EFCORE.Middleware;
using SEJE.EFCORE.Operations;
using System;

namespace ListaReproduccionAudiencia.Infrastructure.Repositories
{
    public class ParteRepository : OperationBase<Guid, string, Parte>, IParteRepository
    {
        public ParteRepository(IAuthenticateUser<string> authenticatetUser, SqlServerContext context) 
            : base(authenticatetUser, context)
        {
        }
    }
}
