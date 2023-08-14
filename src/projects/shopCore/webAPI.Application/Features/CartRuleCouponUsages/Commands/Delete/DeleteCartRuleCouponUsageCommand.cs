using Application.Features.CartRuleCouponUsages.Constants;
using Application.Features.CartRuleCouponUsages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.CartRuleCouponUsages.Commands.Delete;

public class DeleteCartRuleCouponUsageCommand : IRequest<CustomResponseDto<DeletedCartRuleCouponUsageResponse>>
{
    public uint Id { get; set; }

    public class DeleteCartRuleCouponUsageCommandHandler : IRequestHandler<DeleteCartRuleCouponUsageCommand, CustomResponseDto<DeletedCartRuleCouponUsageResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartRuleCouponUsageRepository _cartRuleCouponUsageRepository;
        private readonly CartRuleCouponUsageBusinessRules _cartRuleCouponUsageBusinessRules;

        public DeleteCartRuleCouponUsageCommandHandler(IMapper mapper, ICartRuleCouponUsageRepository cartRuleCouponUsageRepository,
                                         CartRuleCouponUsageBusinessRules cartRuleCouponUsageBusinessRules)
        {
            _mapper = mapper;
            _cartRuleCouponUsageRepository = cartRuleCouponUsageRepository;
            _cartRuleCouponUsageBusinessRules = cartRuleCouponUsageBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedCartRuleCouponUsageResponse>> Handle(DeleteCartRuleCouponUsageCommand request, CancellationToken cancellationToken)
        {
            CartRuleCouponUsage? cartRuleCouponUsage = await _cartRuleCouponUsageRepository.GetAsync(predicate: crcu => crcu.Id == request.Id, cancellationToken: cancellationToken);
            await _cartRuleCouponUsageBusinessRules.CartRuleCouponUsageShouldExistWhenSelected(cartRuleCouponUsage);

            await _cartRuleCouponUsageRepository.DeleteAsync(cartRuleCouponUsage!);

            DeletedCartRuleCouponUsageResponse response = _mapper.Map<DeletedCartRuleCouponUsageResponse>(cartRuleCouponUsage);

             return CustomResponseDto<DeletedCartRuleCouponUsageResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}