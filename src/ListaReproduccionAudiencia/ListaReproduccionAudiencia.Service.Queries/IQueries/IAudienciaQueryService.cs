using ListaReproduccionAudiencia.Service.Queries.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ListaReproduccionAudiencia.Service.Queries.IQueries
{
    public interface IAudienciaQueryService
    {                
        Task<List<AudienciaDto>> GetAsync();
    }
}
