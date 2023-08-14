using Application.Features.CartRuleChannels.Commands.Create;
using Application.Features.CartRuleChannels.Commands.Delete;
using Application.Features.CartRuleChannels.Commands.Update;
using Application.Features.CartRuleChannels.Queries.GetById;
using Application.Features.CartRuleChannels.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CartRuleChannels.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CartRuleChannel, CreateCartRuleChannelCommand>().ReverseMap();
        CreateMap<CartRuleChannel, CreatedCartRuleChannelResponse>().ReverseMap();
        CreateMap<CartRuleChannel, UpdateCartRuleChannelCommand>().ReverseMap();
        CreateMap<CartRuleChannel, UpdatedCartRuleChannelResponse>().ReverseMap();
        CreateMap<CartRuleChannel, DeleteCartRuleChannelCommand>().ReverseMap();
        CreateMap<CartRuleChannel, DeletedCartRuleChannelResponse>().ReverseMap();
        CreateMap<CartRuleChannel, GetByIdCartRuleChannelResponse>().ReverseMap();
        CreateMap<CartRuleChannel, GetListCartRuleChannelListItemDto>().ReverseMap();
        CreateMap<IPaginate<CartRuleChannel>, GetListResponse<GetListCartRuleChannelListItemDto>>().ReverseMap();
    }
}