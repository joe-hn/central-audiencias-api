using ListaReproduccionAviso.Service.Queries.Dto;
using SEJE.CORE.Model.Pager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaReproduccionAviso.Service.Queries.IQueries
{
    public interface IAvisoQueryService
    {
        Task<Pager<AvisoDto>> PageAsync(int CurrentPage, int PageSize);
        Task<List<AvisoDto>> GetAllAsync();
        Task<AvisoDto> GetIdAsync(Guid id);
    }
}
