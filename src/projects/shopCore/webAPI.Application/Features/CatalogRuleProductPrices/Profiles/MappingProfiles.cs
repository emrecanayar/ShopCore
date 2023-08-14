using Application.Features.CatalogRuleProductPrices.Commands.Create;
using Application.Features.CatalogRuleProductPrices.Commands.Delete;
using Application.Features.CatalogRuleProductPrices.Commands.Update;
using Application.Features.CatalogRuleProductPrices.Queries.GetById;
using Application.Features.CatalogRuleProductPrices.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CatalogRuleProductPrices.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CatalogRuleProductPrice, CreateCatalogRuleProductPriceCommand>().ReverseMap();
        CreateMap<CatalogRuleProductPrice, CreatedCatalogRuleProductPriceResponse>().ReverseMap();
        CreateMap<CatalogRuleProductPrice, UpdateCatalogRuleProductPriceCommand>().ReverseMap();
        CreateMap<CatalogRuleProductPrice, UpdatedCatalogRuleProductPriceResponse>().ReverseMap();
        CreateMap<CatalogRuleProductPrice, DeleteCatalogRuleProductPriceCommand>().ReverseMap();
        CreateMap<CatalogRuleProductPrice, DeletedCatalogRuleProductPriceResponse>().ReverseMap();
        CreateMap<CatalogRuleProductPrice, GetByIdCatalogRuleProductPriceResponse>().ReverseMap();
        CreateMap<CatalogRuleProductPrice, GetListCatalogRuleProductPriceListItemDto>().ReverseMap();
        CreateMap<IPaginate<CatalogRuleProductPrice>, GetListResponse<GetListCatalogRuleProductPriceListItemDto>>().ReverseMap();
    }
}