using Anuncio.Infrastructure.Entities;
using Anuncio.Infrastructure.IRepositories;
using SEJE.EFCORE.Middleware;
using SEJE.EFCORE.Operations;
using System;

namespace Anuncio.Infrastructure.Repositories
{
    public class AvisoRepository : OperationBase<Guid, string, Aviso>, IAvisoRepository
    {
        public AvisoRepository(IAuthenticateUser<string> authenticatetUser, SqlServerContext context) : base(authenticatetUser, context)
        {
        }
    }
}
