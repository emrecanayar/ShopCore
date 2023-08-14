using Application.Features.CartRuleCouponUsages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.CartRuleCouponUsages.Queries.GetById;

public class GetByIdCartRuleCouponUsageQuery : IRequest<CustomResponseDto<GetByIdCartRuleCouponUsageResponse>>
{
    public uint Id { get; set; }

    public class GetByIdCartRuleCouponUsageQueryHandler : IRequestHandler<GetByIdCartRuleCouponUsageQuery, CustomResponseDto<GetByIdCartRuleCouponUsageResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartRuleCouponUsageRepository _cartRuleCouponUsageRepository;
        private readonly CartRuleCouponUsageBusinessRules _cartRuleCouponUsageBusinessRules;

        public GetByIdCartRuleCouponUsageQueryHandler(IMapper mapper, ICartRuleCouponUsageRepository cartRuleCouponUsageRepository, CartRuleCouponUsageBusinessRules cartRuleCouponUsageBusinessRules)
        {
            _mapper = mapper;
            _cartRuleCouponUsageRepository = cartRuleCouponUsageRepository;
            _cartRuleCouponUsageBusinessRules = cartRuleCouponUsageBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdCartRuleCouponUsageResponse>> Handle(GetByIdCartRuleCouponUsageQuery request, CancellationToken cancellationToken)
        {
            CartRuleCouponUsage? cartRuleCouponUsage = await _cartRuleCouponUsageRepository.GetAsync(predicate: crcu => crcu.Id == request.Id, cancellationToken: cancellationToken);
            await _cartRuleCouponUsageBusinessRules.CartRuleCouponUsageShouldExistWhenSelected(cartRuleCouponUsage);

            GetByIdCartRuleCouponUsageResponse response = _mapper.Map<GetByIdCartRuleCouponUsageResponse>(cartRuleCouponUsage);

          return CustomResponseDto<GetByIdCartRuleCouponUsageResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}