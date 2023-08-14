using Application.Features.CartRuleCoupons.Constants;
using Application.Features.CartRuleCoupons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CartRuleCoupons.Constants.CartRuleCouponsOperationClaims;

namespace Application.Features.CartRuleCoupons.Queries.GetById;

public class GetByIdCartRuleCouponQuery : IRequest<CustomResponseDto<GetByIdCartRuleCouponResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCartRuleCouponQueryHandler : IRequestHandler<GetByIdCartRuleCouponQuery, CustomResponseDto<GetByIdCartRuleCouponResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartRuleCouponRepository _cartRuleCouponRepository;
        private readonly CartRuleCouponBusinessRules _cartRuleCouponBusinessRules;

        public GetByIdCartRuleCouponQueryHandler(IMapper mapper, ICartRuleCouponRepository cartRuleCouponRepository, CartRuleCouponBusinessRules cartRuleCouponBusinessRules)
        {
            _mapper = mapper;
            _cartRuleCouponRepository = cartRuleCouponRepository;
            _cartRuleCouponBusinessRules = cartRuleCouponBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdCartRuleCouponResponse>> Handle(GetByIdCartRuleCouponQuery request, CancellationToken cancellationToken)
        {
            CartRuleCoupon? cartRuleCoupon = await _cartRuleCouponRepository.GetAsync(predicate: crc => crc.Id == request.Id, cancellationToken: cancellationToken);
            await _cartRuleCouponBusinessRules.CartRuleCouponShouldExistWhenSelected(cartRuleCoupon);

            GetByIdCartRuleCouponResponse response = _mapper.Map<GetByIdCartRuleCouponResponse>(cartRuleCoupon);

          return CustomResponseDto<GetByIdCartRuleCouponResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}