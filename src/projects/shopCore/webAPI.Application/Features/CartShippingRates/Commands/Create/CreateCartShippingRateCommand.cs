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

namespace Application.Features.CartShippingRates.Commands.Create;

public class CreateCartShippingRateCommand : IRequest<CustomResponseDto<CreatedCartShippingRateResponse>>, ISecuredRequest
{
    public string Carrier { get; set; }
    public string CarrierTitle { get; set; }
    public string Method { get; set; }
    public string MethodTitle { get; set; }
    public string? MethodDescription { get; set; }
    public double? Price { get; set; }
    public double? BasePrice { get; set; }
    public uint? CartAddressId { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal BaseDiscountAmount { get; set; }
    public bool? IsCalculateTax { get; set; }

    public string[] Roles => new[] { Admin, Write, CartShippingRatesOperationClaims.Create };

    public class CreateCartShippingRateCommandHandler : IRequestHandler<CreateCartShippingRateCommand, CustomResponseDto<CreatedCartShippingRateResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartShippingRateRepository _cartShippingRateRepository;
        private readonly CartShippingRateBusinessRules _cartShippingRateBusinessRules;

        public CreateCartShippingRateCommandHandler(IMapper mapper, ICartShippingRateRepository cartShippingRateRepository,
                                         CartShippingRateBusinessRules cartShippingRateBusinessRules)
        {
            _mapper = mapper;
            _cartShippingRateRepository = cartShippingRateRepository;
            _cartShippingRateBusinessRules = cartShippingRateBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedCartShippingRateResponse>> Handle(CreateCartShippingRateCommand request, CancellationToken cancellationToken)
        {
            CartShippingRate cartShippingRate = _mapper.Map<CartShippingRate>(request);

            await _cartShippingRateRepository.AddAsync(cartShippingRate);

            CreatedCartShippingRateResponse response = _mapper.Map<CreatedCartShippingRateResponse>(cartShippingRate);
         return CustomResponseDto<CreatedCartShippingRateResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}