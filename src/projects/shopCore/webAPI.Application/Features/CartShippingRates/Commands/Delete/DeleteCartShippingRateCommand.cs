using Application.Features.CartShippingRates.Constants;
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

namespace Application.Features.CartShippingRates.Commands.Delete;

public class DeleteCartShippingRateCommand : IRequest<CustomResponseDto<DeletedCartShippingRateResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CartShippingRatesOperationClaims.Delete };

    public class DeleteCartShippingRateCommandHandler : IRequestHandler<DeleteCartShippingRateCommand, CustomResponseDto<DeletedCartShippingRateResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartShippingRateRepository _cartShippingRateRepository;
        private readonly CartShippingRateBusinessRules _cartShippingRateBusinessRules;

        public DeleteCartShippingRateCommandHandler(IMapper mapper, ICartShippingRateRepository cartShippingRateRepository,
                                         CartShippingRateBusinessRules cartShippingRateBusinessRules)
        {
            _mapper = mapper;
            _cartShippingRateRepository = cartShippingRateRepository;
            _cartShippingRateBusinessRules = cartShippingRateBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedCartShippingRateResponse>> Handle(DeleteCartShippingRateCommand request, CancellationToken cancellationToken)
        {
            CartShippingRate? cartShippingRate = await _cartShippingRateRepository.GetAsync(predicate: csr => csr.Id == request.Id, cancellationToken: cancellationToken);
            await _cartShippingRateBusinessRules.CartShippingRateShouldExistWhenSelected(cartShippingRate);

            await _cartShippingRateRepository.DeleteAsync(cartShippingRate!);

            DeletedCartShippingRateResponse response = _mapper.Map<DeletedCartShippingRateResponse>(cartShippingRate);

             return CustomResponseDto<DeletedCartShippingRateResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}