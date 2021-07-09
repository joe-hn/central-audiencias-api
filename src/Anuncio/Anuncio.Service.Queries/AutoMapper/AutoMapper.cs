using Anuncio.Infrastructure.Entities;
using Anuncio.Service.Queries.Dto;
using AutoMapper;
using SEJE.CORE.Model.Pager;

namespace Anuncio.Service.Queries.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap(typeof(Pager<>), typeof(Pager<>));
            CreateMap<Aviso, AnuncioDto>().ReverseMap();
        }
    }
}
