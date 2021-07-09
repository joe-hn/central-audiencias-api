using AutoMapper;
using ListaReproduccionAviso.Infrastructure.Entities;
using ListaReproduccionAviso.Service.Queries.Dto;
using SEJE.CORE.Model.Pager;

namespace ListaReproduccionAviso.Service.Queries.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {

            CreateMap(typeof(Pager<>), typeof(Pager<>));
            CreateMap<Aviso, AvisoDto>().ReverseMap();

        }
    }
}
