using Application.Features.CartShippingRates.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.CartShippingRates.Constants.CartShippingRatesOperationClaims;

namespace Application.Features.CartShippingRates.Queries.GetList;

public class GetListCartShippingRateQuery : IRequest<CustomResponseDto<GetListResponse<GetListCartShippingRateListItemDto>>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListCartShippingRateQueryHandler : IRequestHandler<GetListCartShippingRateQuery, CustomResponseDto<GetListResponse<GetListCartShippingRateListItemDto>>>
    {
        private readonly ICartShippingRateRepository _cartShippingRateRepository;
        private readonly IMapper _mapper;

        public GetListCartShippingRateQueryHandler(ICartShippingRateRepository cartShippingRateRepository, IMapper mapper)
        {
            _cartShippingRateRepository = cartShippingRateRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListCartShippingRateListItemDto>>> Handle(GetListCartShippingRateQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CartShippingRate> cartShippingRates = await _cartShippingRateRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCartShippingRateListItemDto> response = _mapper.Map<GetListResponse<GetListCartShippingRateListItemDto>>(cartShippingRates);
             return CustomResponseDto<GetListResponse<GetListCartShippingRateListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}