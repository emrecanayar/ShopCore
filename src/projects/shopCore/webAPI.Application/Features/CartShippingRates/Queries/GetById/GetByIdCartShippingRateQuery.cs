using Application.Features.CartShippingRates.Constants;
using Application.Features.CartShippingRates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CartShippingRates.Constants.CartShippingRatesOperationClaims;

namespace Application.Features.CartShippingRates.Queries.GetById;

public class GetByIdCartShippingRateQuery : IRequest<CustomResponseDto<GetByIdCartShippingRateResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCartShippingRateQueryHandler : IRequestHandler<GetByIdCartShippingRateQuery, CustomResponseDto<GetByIdCartShippingRateResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartShippingRateRepository _cartShippingRateRepository;
        private readonly CartShippingRateBusinessRules _cartShippingRateBusinessRules;

        public GetByIdCartShippingRateQueryHandler(IMapper mapper, ICartShippingRateRepository cartShippingRateRepository, CartShippingRateBusinessRules cartShippingRateBusinessRules)
        {
            _mapper = mapper;
            _cartShippingRateRepository = cartShippingRateRepository;
            _cartShippingRateBusinessRules = cartShippingRateBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdCartShippingRateResponse>> Handle(GetByIdCartShippingRateQuery request, CancellationToken cancellationToken)
        {
            CartShippingRate? cartShippingRate = await _cartShippingRateRepository.GetAsync(predicate: csr => csr.Id == request.Id, cancellationToken: cancellationToken);
            await _cartShippingRateBusinessRules.CartShippingRateShouldExistWhenSelected(cartShippingRate);

            GetByIdCartShippingRateResponse response = _mapper.Map<GetByIdCartShippingRateResponse>(cartShippingRate);

          return CustomResponseDto<GetByIdCartShippingRateResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}