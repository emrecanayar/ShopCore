using Application.Features.CatalogRuleProducts.Commands.Create;
using Application.Features.CatalogRuleProducts.Commands.Delete;
using Application.Features.CatalogRuleProducts.Commands.Update;
using Application.Features.CatalogRuleProducts.Queries.GetById;
using Application.Features.CatalogRuleProducts.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CatalogRuleProducts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CatalogRuleProduct, CreateCatalogRuleProductCommand>().ReverseMap();
        CreateMap<CatalogRuleProduct, CreatedCatalogRuleProductResponse>().ReverseMap();
        CreateMap<CatalogRuleProduct, UpdateCatalogRuleProductCommand>().ReverseMap();
        CreateMap<CatalogRuleProduct, UpdatedCatalogRuleProductResponse>().ReverseMap();
        CreateMap<CatalogRuleProduct, DeleteCatalogRuleProductCommand>().ReverseMap();
        CreateMap<CatalogRuleProduct, DeletedCatalogRuleProductResponse>().ReverseMap();
        CreateMap<CatalogRuleProduct, GetByIdCatalogRuleProductResponse>().ReverseMap();
        CreateMap<CatalogRuleProduct, GetListCatalogRuleProductListItemDto>().ReverseMap();
        CreateMap<IPaginate<CatalogRuleProduct>, GetListResponse<GetListCatalogRuleProductListItemDto>>().ReverseMap();
    }
}