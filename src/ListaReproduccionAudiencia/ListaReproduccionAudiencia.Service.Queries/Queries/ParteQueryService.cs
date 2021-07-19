using AutoMapper;
using ListaReproduccionAudiencia.Infrastructure.Entities;
using ListaReproduccionAudiencia.Infrastructure.IRepositories;
using ListaReproduccionAudiencia.Service.Queries.Dto;
using ListaReproduccionAudiencia.Service.Queries.IQueries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaReproduccionAudiencia.Service.Queries.Queries
{
    public class ParteQueryService : IParteQueryService
    {
        private readonly IParteRepository repository;
        private readonly IMapper mapper;

        public ParteQueryService(IParteRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<ParteDto>> GetAudienciaIdAsync(Guid audienciaId)
        {
            var entities = await this.repository.GetEntity<Parte>().Where(x => x.AudienciaId == audienciaId).ToListAsync();
            return this.mapper.Map<List<ParteDto>>(entities);
        }

        public async Task<List<ParteDto>> GetParteAsync()
        {
            var entities = await this.repository.GetEntity<Parte>().ToListAsync();
            return this.mapper.Map<List<ParteDto>>(entities);
        }


    }
}
