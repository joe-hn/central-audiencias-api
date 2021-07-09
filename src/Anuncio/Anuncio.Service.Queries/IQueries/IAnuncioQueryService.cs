using Anuncio.Service.Queries.Dto;
using SEJE.CORE.Model.Pager;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Anuncio.Service.Queries.IQueries
{
    public interface IAnuncioQueryService
    {
        Task<Pager<AnuncioDto>> PageAsync(int CurrentPage, int PageSize);
        Task<AnuncioDto> GetIdAsync(Guid id);

        Task<List<AnuncioDto>> GetDate(DateTime date);
    }
}
