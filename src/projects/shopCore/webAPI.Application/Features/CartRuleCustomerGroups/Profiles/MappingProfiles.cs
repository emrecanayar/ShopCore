using Application.Features.CartRuleCustomerGroups.Commands.Create;
using Application.Features.CartRuleCustomerGroups.Commands.Delete;
using Application.Features.CartRuleCustomerGroups.Commands.Update;
using Application.Features.CartRuleCustomerGroups.Queries.GetById;
using Application.Features.CartRuleCustomerGroups.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CartRuleCustomerGroups.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CartRuleCustomerGroup, CreateCartRuleCustomerGroupCommand>().ReverseMap();
        CreateMap<CartRuleCustomerGroup, CreatedCartRuleCustomerGroupResponse>().ReverseMap();
        CreateMap<CartRuleCustomerGroup, UpdateCartRuleCustomerGroupCommand>().ReverseMap();
        CreateMap<CartRuleCustomerGroup, UpdatedCartRuleCustomerGroupResponse>().ReverseMap();
        CreateMap<CartRuleCustomerGroup, DeleteCartRuleCustomerGroupCommand>().ReverseMap();
        CreateMap<CartRuleCustomerGroup, DeletedCartRuleCustomerGroupResponse>().ReverseMap();
        CreateMap<CartRuleCustomerGroup, GetByIdCartRuleCustomerGroupResponse>().ReverseMap();
        CreateMap<CartRuleCustomerGroup, GetListCartRuleCustomerGroupListItemDto>().ReverseMap();
        CreateMap<IPaginate<CartRuleCustomerGroup>, GetListResponse<GetListCartRuleCustomerGroupListItemDto>>().ReverseMap();
    }
}