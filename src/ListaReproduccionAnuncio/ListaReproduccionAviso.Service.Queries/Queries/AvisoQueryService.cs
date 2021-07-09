using AutoMapper;
using ListaReproduccionAviso.Infrastructure.Entities;
using ListaReproduccionAviso.Infrastructure.IRepositories;
using ListaReproduccionAviso.Service.Queries.Dto;
using ListaReproduccionAviso.Service.Queries.IQueries;
using Microsoft.EntityFrameworkCore;
using SEJE.CORE.Model.Pager;
using SEJE.EFCORE.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ListaReproduccionAviso.Service.Queries.Queries
{
    public class AvisoQueryService : IAvisoQueryService
    {

        private readonly IAvisoRepository repository;
        private readonly IMapper mapper;

        public AvisoQueryService(IAvisoRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<AvisoDto>> GetAllAsync()
        {
            var entities = await this.repository.GetEntity<Aviso>().ToListAsync();
            return this.mapper.Map<List<AvisoDto>>(entities);
        }

        public async Task<AvisoDto> GetIdAsync(Guid id)
        {
            var entity = await this.repository.GetEntity<Aviso>().FindAsync(id);
            return this.mapper.Map<AvisoDto>(entity);
        }

        public async Task<Pager<AvisoDto>> PageAsync(int CurrentPage, int PageSize)
        {
            var entities = await this.repository.GetEntity<Aviso>().ToPageAsync(CurrentPage, PageSize);
            return this.mapper.Map<Pager<AvisoDto>>(entities);
        }
    }
}
