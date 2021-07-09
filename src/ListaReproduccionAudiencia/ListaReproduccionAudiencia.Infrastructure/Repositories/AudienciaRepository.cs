using ListaReproduccionAudiencia.Infrastructure.Entities;
using ListaReproduccionAudiencia.Infrastructure.IRepositories;
using SEJE.EFCORE.Middleware;
using SEJE.EFCORE.Operations;
using System;

namespace ListaReproduccionAudiencia.Infrastructure.Repositories
{
    public class AudienciaRepository : OperationBase<Guid, string, Audiencia>, IAudienciaRepository
    {
        public AudienciaRepository(IAuthenticateUser<string> authenticatetUser, SqlServerContext context) 
            : base(authenticatetUser, context)
        {
        }
    }
}
