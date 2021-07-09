using ListaReproduccionAudiencia.Service.Queries.Dto;
using SEJE.CORE.Model.Pager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaReproduccionAudiencia.Service.Queries.IQueries
{
    public interface IParteQueryService
    {        
        Task<List<ParteDto>> GetAudienciaIdAsync(Guid audienciaId);
    }
}
