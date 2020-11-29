using AutoMapper;
using MaryShoppins.ApplicationCore.Entities;
using MaryShoppins.PublicApi.CatalogBrandEndpoints;
using MaryShoppins.PublicApi.CatalogItemEndpoints;
using MaryShoppins.PublicApi.CatalogTypeEndpoints;

namespace MaryShoppins.PublicApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CatalogItem, CatalogItemDto>();
            CreateMap<CatalogType, CatalogTypeDto>()
                .ForMember(dto => dto.Name, options => options.MapFrom(src => src.Type));
            CreateMap<CatalogBrand, CatalogBrandDto>()
                .ForMember(dto => dto.Name, options => options.MapFrom(src => src.Brand));
        }
    }
}
