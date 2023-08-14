using Application.Features.CartRuleCouponUsages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.CartRuleCouponUsages.Commands.Create;

public class CreateCartRuleCouponUsageCommand : IRequest<CustomResponseDto<CreatedCartRuleCouponUsageResponse>>
{
    public int TimesUsed { get; set; }
    public uint CartRuleCouponId { get; set; }
    public uint CustomerId { get; set; }

    public class CreateCartRuleCouponUsageCommandHandler : IRequestHandler<CreateCartRuleCouponUsageCommand, CustomResponseDto<CreatedCartRuleCouponUsageResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartRuleCouponUsageRepository _cartRuleCouponUsageRepository;
        private readonly CartRuleCouponUsageBusinessRules _cartRuleCouponUsageBusinessRules;

        public CreateCartRuleCouponUsageCommandHandler(IMapper mapper, ICartRuleCouponUsageRepository cartRuleCouponUsageRepository,
                                         CartRuleCouponUsageBusinessRules cartRuleCouponUsageBusinessRules)
        {
            _mapper = mapper;
            _cartRuleCouponUsageRepository = cartRuleCouponUsageRepository;
            _cartRuleCouponUsageBusinessRules = cartRuleCouponUsageBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedCartRuleCouponUsageResponse>> Handle(CreateCartRuleCouponUsageCommand request, CancellationToken cancellationToken)
        {
            CartRuleCouponUsage cartRuleCouponUsage = _mapper.Map<CartRuleCouponUsage>(request);

            await _cartRuleCouponUsageRepository.AddAsync(cartRuleCouponUsage);

            CreatedCartRuleCouponUsageResponse response = _mapper.Map<CreatedCartRuleCouponUsageResponse>(cartRuleCouponUsage);
         return CustomResponseDto<CreatedCartRuleCouponUsageResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}