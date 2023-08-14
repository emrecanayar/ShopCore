using Application.Features.CartRuleCoupons.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.CartRuleCoupons.Constants.CartRuleCouponsOperationClaims;

namespace Application.Features.CartRuleCoupons.Queries.GetList;

public class GetListCartRuleCouponQuery : IRequest<CustomResponseDto<GetListResponse<GetListCartRuleCouponListItemDto>>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListCartRuleCouponQueryHandler : IRequestHandler<GetListCartRuleCouponQuery, CustomResponseDto<GetListResponse<GetListCartRuleCouponListItemDto>>>
    {
        private readonly ICartRuleCouponRepository _cartRuleCouponRepository;
        private readonly IMapper _mapper;

        public GetListCartRuleCouponQueryHandler(ICartRuleCouponRepository cartRuleCouponRepository, IMapper mapper)
        {
            _cartRuleCouponRepository = cartRuleCouponRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListCartRuleCouponListItemDto>>> Handle(GetListCartRuleCouponQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CartRuleCoupon> cartRuleCoupons = await _cartRuleCouponRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCartRuleCouponListItemDto> response = _mapper.Map<GetListResponse<GetListCartRuleCouponListItemDto>>(cartRuleCoupons);
             return CustomResponseDto<GetListResponse<GetListCartRuleCouponListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}