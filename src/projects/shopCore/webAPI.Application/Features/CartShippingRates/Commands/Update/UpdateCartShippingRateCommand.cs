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

namespace Application.Features.CartShippingRates.Commands.Update;

public class UpdateCartShippingRateCommand : IRequest<CustomResponseDto<UpdatedCartShippingRateResponse>>, ISecuredRequest
{
    public uint Id { get; set; }
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

    public string[] Roles => new[] { Admin, Write, CartShippingRatesOperationClaims.Update };

    public class UpdateCartShippingRateCommandHandler : IRequestHandler<UpdateCartShippingRateCommand, CustomResponseDto<UpdatedCartShippingRateResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartShippingRateRepository _cartShippingRateRepository;
        private readonly CartShippingRateBusinessRules _cartShippingRateBusinessRules;

        public UpdateCartShippingRateCommandHandler(IMapper mapper, ICartShippingRateRepository cartShippingRateRepository,
                                         CartShippingRateBusinessRules cartShippingRateBusinessRules)
        {
            _mapper = mapper;
            _cartShippingRateRepository = cartShippingRateRepository;
            _cartShippingRateBusinessRules = cartShippingRateBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedCartShippingRateResponse>> Handle(UpdateCartShippingRateCommand request, CancellationToken cancellationToken)
        {
            CartShippingRate? cartShippingRate = await _cartShippingRateRepository.GetAsync(predicate: csr => csr.Id == request.Id, cancellationToken: cancellationToken);
            await _cartShippingRateBusinessRules.CartShippingRateShouldExistWhenSelected(cartShippingRate);
            cartShippingRate = _mapper.Map(request, cartShippingRate);

            await _cartShippingRateRepository.UpdateAsync(cartShippingRate!);

            UpdatedCartShippingRateResponse response = _mapper.Map<UpdatedCartShippingRateResponse>(cartShippingRate);

          return CustomResponseDto<UpdatedCartShippingRateResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}