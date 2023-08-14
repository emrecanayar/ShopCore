using Application.Features.CatalogRuleProductPrices.Constants;
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
using static Application.Features.CatalogRuleProductPrices.Constants.CatalogRuleProductPricesOperationClaims;

namespace Application.Features.CatalogRuleProductPrices.Queries.GetList;

public class GetListCatalogRuleProductPriceQuery : IRequest<CustomResponseDto<GetListResponse<GetListCatalogRuleProductPriceListItemDto>>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListCatalogRuleProductPriceQueryHandler : IRequestHandler<GetListCatalogRuleProductPriceQuery, CustomResponseDto<GetListResponse<GetListCatalogRuleProductPriceListItemDto>>>
    {
        private readonly ICatalogRuleProductPriceRepository _catalogRuleProductPriceRepository;
        private readonly IMapper _mapper;

        public GetListCatalogRuleProductPriceQueryHandler(ICatalogRuleProductPriceRepository catalogRuleProductPriceRepository, IMapper mapper)
        {
            _catalogRuleProductPriceRepository = catalogRuleProductPriceRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListCatalogRuleProductPriceListItemDto>>> Handle(GetListCatalogRuleProductPriceQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CatalogRuleProductPrice> catalogRuleProductPrices = await _catalogRuleProductPriceRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCatalogRuleProductPriceListItemDto> response = _mapper.Map<GetListResponse<GetListCatalogRuleProductPriceListItemDto>>(catalogRuleProductPrices);
             return CustomResponseDto<GetListResponse<GetListCatalogRuleProductPriceListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}