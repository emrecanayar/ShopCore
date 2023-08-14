using Application.Features.CartRuleCoupons.Commands.Create;
using Application.Features.CartRuleCoupons.Commands.Delete;
using Application.Features.CartRuleCoupons.Commands.Update;
using Application.Features.CartRuleCoupons.Queries.GetById;
using Application.Features.CartRuleCoupons.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CartRuleCoupons.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CartRuleCoupon, CreateCartRuleCouponCommand>().ReverseMap();
        CreateMap<CartRuleCoupon, CreatedCartRuleCouponResponse>().ReverseMap();
        CreateMap<CartRuleCoupon, UpdateCartRuleCouponCommand>().ReverseMap();
        CreateMap<CartRuleCoupon, UpdatedCartRuleCouponResponse>().ReverseMap();
        CreateMap<CartRuleCoupon, DeleteCartRuleCouponCommand>().ReverseMap();
        CreateMap<CartRuleCoupon, DeletedCartRuleCouponResponse>().ReverseMap();
        CreateMap<CartRuleCoupon, GetByIdCartRuleCouponResponse>().ReverseMap();
        CreateMap<CartRuleCoupon, GetListCartRuleCouponListItemDto>().ReverseMap();
        CreateMap<IPaginate<CartRuleCoupon>, GetListResponse<GetListCartRuleCouponListItemDto>>().ReverseMap();
    }
}