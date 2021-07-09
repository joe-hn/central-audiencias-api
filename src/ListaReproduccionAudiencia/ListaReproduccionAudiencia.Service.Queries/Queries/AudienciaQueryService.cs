using AutoMapper;
using ListaReproduccionAudiencia.Infrastructure.Entities;
using ListaReproduccionAudiencia.Infrastructure.IRepositories;
using ListaReproduccionAudiencia.Service.Queries.Dto;
using ListaReproduccionAudiencia.Service.Queries.IQueries;
using Microsoft.EntityFrameworkCore;
using SEJE.CORE.Model.Pager;
using SEJE.EFCORE.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ListaReproduccionAudiencia.Service.Queries.Queries
{
    public class AudienciaQueryService : IAudienciaQueryService
    {
        private readonly IAudienciaRepository repository;
        private readonly IMapper mapper;

        public AudienciaQueryService(IAudienciaRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<AudienciaDto>> GetAsync()
        {
            var entities = await this.repository.GetEntity<Audiencia>().ToListAsync();
            return this.mapper.Map<List<AudienciaDto>>(entities);
        }
        
    }
}
