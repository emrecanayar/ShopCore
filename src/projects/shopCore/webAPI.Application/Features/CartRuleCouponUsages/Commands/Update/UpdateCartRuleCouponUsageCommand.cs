using Application.Features.CartRuleCouponUsages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.CartRuleCouponUsages.Commands.Update;

public class UpdateCartRuleCouponUsageCommand : IRequest<CustomResponseDto<UpdatedCartRuleCouponUsageResponse>>
{
    public uint Id { get; set; }
    public int TimesUsed { get; set; }
    public uint CartRuleCouponId { get; set; }
    public uint CustomerId { get; set; }

    public class UpdateCartRuleCouponUsageCommandHandler : IRequestHandler<UpdateCartRuleCouponUsageCommand, CustomResponseDto<UpdatedCartRuleCouponUsageResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartRuleCouponUsageRepository _cartRuleCouponUsageRepository;
        private readonly CartRuleCouponUsageBusinessRules _cartRuleCouponUsageBusinessRules;

        public UpdateCartRuleCouponUsageCommandHandler(IMapper mapper, ICartRuleCouponUsageRepository cartRuleCouponUsageRepository,
                                         CartRuleCouponUsageBusinessRules cartRuleCouponUsageBusinessRules)
        {
            _mapper = mapper;
            _cartRuleCouponUsageRepository = cartRuleCouponUsageRepository;
            _cartRuleCouponUsageBusinessRules = cartRuleCouponUsageBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedCartRuleCouponUsageResponse>> Handle(UpdateCartRuleCouponUsageCommand request, CancellationToken cancellationToken)
        {
            CartRuleCouponUsage? cartRuleCouponUsage = await _cartRuleCouponUsageRepository.GetAsync(predicate: crcu => crcu.Id == request.Id, cancellationToken: cancellationToken);
            await _cartRuleCouponUsageBusinessRules.CartRuleCouponUsageShouldExistWhenSelected(cartRuleCouponUsage);
            cartRuleCouponUsage = _mapper.Map(request, cartRuleCouponUsage);

            await _cartRuleCouponUsageRepository.UpdateAsync(cartRuleCouponUsage!);

            UpdatedCartRuleCouponUsageResponse response = _mapper.Map<UpdatedCartRuleCouponUsageResponse>(cartRuleCouponUsage);

          return CustomResponseDto<UpdatedCartRuleCouponUsageResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}