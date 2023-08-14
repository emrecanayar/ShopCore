using Application.Features.CartRuleCoupons.Constants;
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

namespace Application.Features.CartRuleCoupons.Commands.Delete;

public class DeleteCartRuleCouponCommand : IRequest<CustomResponseDto<DeletedCartRuleCouponResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CartRuleCouponsOperationClaims.Delete };

    public class DeleteCartRuleCouponCommandHandler : IRequestHandler<DeleteCartRuleCouponCommand, CustomResponseDto<DeletedCartRuleCouponResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartRuleCouponRepository _cartRuleCouponRepository;
        private readonly CartRuleCouponBusinessRules _cartRuleCouponBusinessRules;

        public DeleteCartRuleCouponCommandHandler(IMapper mapper, ICartRuleCouponRepository cartRuleCouponRepository,
                                         CartRuleCouponBusinessRules cartRuleCouponBusinessRules)
        {
            _mapper = mapper;
            _cartRuleCouponRepository = cartRuleCouponRepository;
            _cartRuleCouponBusinessRules = cartRuleCouponBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedCartRuleCouponResponse>> Handle(DeleteCartRuleCouponCommand request, CancellationToken cancellationToken)
        {
            CartRuleCoupon? cartRuleCoupon = await _cartRuleCouponRepository.GetAsync(predicate: crc => crc.Id == request.Id, cancellationToken: cancellationToken);
            await _cartRuleCouponBusinessRules.CartRuleCouponShouldExistWhenSelected(cartRuleCoupon);

            await _cartRuleCouponRepository.DeleteAsync(cartRuleCoupon!);

            DeletedCartRuleCouponResponse response = _mapper.Map<DeletedCartRuleCouponResponse>(cartRuleCoupon);

             return CustomResponseDto<DeletedCartRuleCouponResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}