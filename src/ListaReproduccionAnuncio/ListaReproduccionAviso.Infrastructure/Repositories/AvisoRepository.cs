using ListaReproduccionAviso.Infrastructure.Entities;
using ListaReproduccionAviso.Infrastructure.IRepositories;
using Microsoft.EntityFrameworkCore;
using SEJE.EFCORE.Middleware;
using SEJE.EFCORE.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaReproduccionAviso.Infrastructure.Repositories
{
    public class AvisoRepository : OperationBase<Guid, string, Aviso>, IAvisoRepository
    {
        public AvisoRepository(IAuthenticateUser<string> authenticatetUser, SqlServerContext context) 
            : base(authenticatetUser, context)
        {
        }
    }
}
