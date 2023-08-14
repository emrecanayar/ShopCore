using Application.Features.CartRules.Commands.Create;
using Application.Features.CartRules.Commands.Delete;
using Application.Features.CartRules.Commands.Update;
using Application.Features.CartRules.Queries.GetById;
using Application.Features.CartRules.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CartRules.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CartRule, CreateCartRuleCommand>().ReverseMap();
        CreateMap<CartRule, CreatedCartRuleResponse>().ReverseMap();
        CreateMap<CartRule, UpdateCartRuleCommand>().ReverseMap();
        CreateMap<CartRule, UpdatedCartRuleResponse>().ReverseMap();
        CreateMap<CartRule, DeleteCartRuleCommand>().ReverseMap();
        CreateMap<CartRule, DeletedCartRuleResponse>().ReverseMap();
        CreateMap<CartRule, GetByIdCartRuleResponse>().ReverseMap();
        CreateMap<CartRule, GetListCartRuleListItemDto>().ReverseMap();
        CreateMap<IPaginate<CartRule>, GetListResponse<GetListCartRuleListItemDto>>().ReverseMap();
    }
}