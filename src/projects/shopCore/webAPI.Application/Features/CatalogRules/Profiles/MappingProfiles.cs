using Application.Features.CatalogRules.Commands.Create;
using Application.Features.CatalogRules.Commands.Delete;
using Application.Features.CatalogRules.Commands.Update;
using Application.Features.CatalogRules.Queries.GetById;
using Application.Features.CatalogRules.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CatalogRules.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CatalogRule, CreateCatalogRuleCommand>().ReverseMap();
        CreateMap<CatalogRule, CreatedCatalogRuleResponse>().ReverseMap();
        CreateMap<CatalogRule, UpdateCatalogRuleCommand>().ReverseMap();
        CreateMap<CatalogRule, UpdatedCatalogRuleResponse>().ReverseMap();
        CreateMap<CatalogRule, DeleteCatalogRuleCommand>().ReverseMap();
        CreateMap<CatalogRule, DeletedCatalogRuleResponse>().ReverseMap();
        CreateMap<CatalogRule, GetByIdCatalogRuleResponse>().ReverseMap();
        CreateMap<CatalogRule, GetListCatalogRuleListItemDto>().ReverseMap();
        CreateMap<IPaginate<CatalogRule>, GetListResponse<GetListCatalogRuleListItemDto>>().ReverseMap();
    }
}