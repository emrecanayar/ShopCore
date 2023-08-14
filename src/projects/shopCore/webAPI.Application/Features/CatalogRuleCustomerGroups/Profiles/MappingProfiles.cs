using Application.Features.CatalogRuleCustomerGroups.Commands.Create;
using Application.Features.CatalogRuleCustomerGroups.Commands.Delete;
using Application.Features.CatalogRuleCustomerGroups.Commands.Update;
using Application.Features.CatalogRuleCustomerGroups.Queries.GetById;
using Application.Features.CatalogRuleCustomerGroups.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CatalogRuleCustomerGroups.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CatalogRuleCustomerGroup, CreateCatalogRuleCustomerGroupCommand>().ReverseMap();
        CreateMap<CatalogRuleCustomerGroup, CreatedCatalogRuleCustomerGroupResponse>().ReverseMap();
        CreateMap<CatalogRuleCustomerGroup, UpdateCatalogRuleCustomerGroupCommand>().ReverseMap();
        CreateMap<CatalogRuleCustomerGroup, UpdatedCatalogRuleCustomerGroupResponse>().ReverseMap();
        CreateMap<CatalogRuleCustomerGroup, DeleteCatalogRuleCustomerGroupCommand>().ReverseMap();
        CreateMap<CatalogRuleCustomerGroup, DeletedCatalogRuleCustomerGroupResponse>().ReverseMap();
        CreateMap<CatalogRuleCustomerGroup, GetByIdCatalogRuleCustomerGroupResponse>().ReverseMap();
        CreateMap<CatalogRuleCustomerGroup, GetListCatalogRuleCustomerGroupListItemDto>().ReverseMap();
        CreateMap<IPaginate<CatalogRuleCustomerGroup>, GetListResponse<GetListCatalogRuleCustomerGroupListItemDto>>().ReverseMap();
    }
}