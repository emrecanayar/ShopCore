using Application.Features.CartRuleCouponUsages.Commands.Create;
using Application.Features.CartRuleCouponUsages.Commands.Delete;
using Application.Features.CartRuleCouponUsages.Commands.Update;
using Application.Features.CartRuleCouponUsages.Queries.GetById;
using Application.Features.CartRuleCouponUsages.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CartRuleCouponUsages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CartRuleCouponUsage, CreateCartRuleCouponUsageCommand>().ReverseMap();
        CreateMap<CartRuleCouponUsage, CreatedCartRuleCouponUsageResponse>().ReverseMap();
        CreateMap<CartRuleCouponUsage, UpdateCartRuleCouponUsageCommand>().ReverseMap();
        CreateMap<CartRuleCouponUsage, UpdatedCartRuleCouponUsageResponse>().ReverseMap();
        CreateMap<CartRuleCouponUsage, DeleteCartRuleCouponUsageCommand>().ReverseMap();
        CreateMap<CartRuleCouponUsage, DeletedCartRuleCouponUsageResponse>().ReverseMap();
        CreateMap<CartRuleCouponUsage, GetByIdCartRuleCouponUsageResponse>().ReverseMap();
        CreateMap<CartRuleCouponUsage, GetListCartRuleCouponUsageListItemDto>().ReverseMap();
        CreateMap<IPaginate<CartRuleCouponUsage>, GetListResponse<GetListCartRuleCouponUsageListItemDto>>().ReverseMap();
    }
}