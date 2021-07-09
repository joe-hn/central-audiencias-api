using Anuncio.Infrastructure.Entities;
using Anuncio.Infrastructure.IRepositories;
using Anuncio.Service.Queries.Dto;
using Anuncio.Service.Queries.IQueries;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SEJE.CORE.Model.Pager;
using SEJE.EFCORE.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anuncio.Service.Queries.Queries
{
    public class AnuncioQueryService : IAnuncioQueryService
    {
        private readonly IAvisoRepository avisoRepository;       
        private readonly IMapper mapper;

        public AnuncioQueryService(IAvisoRepository avisoRepository, IMapper mapper)
        {
            this.avisoRepository = avisoRepository;            
            this.mapper = mapper;
        }

        public async Task<List<AnuncioDto>> GetDate(DateTime date)
        {                        
            var entities = await this.avisoRepository.GetEntity<Aviso>().Where(c => c.fechaInicio <= date && c.fechaFinalizacion >= date).ToListAsync();
            return this.mapper.Map<List<AnuncioDto>>(entities);
        }

        public async Task<AnuncioDto> GetIdAsync(Guid id)
        {
            var entities = await this.avisoRepository.GetEntity<Aviso>().FindAsync(id);
            return this.mapper.Map<AnuncioDto>(entities);
        }

        public async Task<Pager<AnuncioDto>> PageAsync(int CurrentPage, int PageSize)
        {
            var entities = await this.avisoRepository.GetEntity<Aviso>().ToPageAsync(CurrentPage, PageSize);
            return this.mapper.Map<Pager<AnuncioDto>>(entities);

        }

    }
}
