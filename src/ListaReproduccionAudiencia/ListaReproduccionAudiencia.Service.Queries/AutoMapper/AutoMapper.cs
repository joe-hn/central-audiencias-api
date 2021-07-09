using AutoMapper;
using ListaReproduccionAudiencia.Infrastructure.Entities;
using ListaReproduccionAudiencia.Service.Queries.Dto;
using SEJE.CORE.Model.Pager;

namespace ListaReproduccionAudiencia.Service.Queries.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {

            CreateMap(typeof(Pager<>), typeof(Pager<>));
            CreateMap<Audiencia, AudienciaDto>().ReverseMap();
            CreateMap<Parte, ParteDto>().ReverseMap();

        }
    }
}
