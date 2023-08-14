using Application.Features.CatalogRuleProducts.Constants;
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
using static Application.Features.CatalogRuleProducts.Constants.CatalogRuleProductsOperationClaims;

namespace Application.Features.CatalogRuleProducts.Queries.GetList;

public class GetListCatalogRuleProductQuery : IRequest<CustomResponseDto<GetListResponse<GetListCatalogRuleProductListItemDto>>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListCatalogRuleProductQueryHandler : IRequestHandler<GetListCatalogRuleProductQuery, CustomResponseDto<GetListResponse<GetListCatalogRuleProductListItemDto>>>
    {
        private readonly ICatalogRuleProductRepository _catalogRuleProductRepository;
        private readonly IMapper _mapper;

        public GetListCatalogRuleProductQueryHandler(ICatalogRuleProductRepository catalogRuleProductRepository, IMapper mapper)
        {
            _catalogRuleProductRepository = catalogRuleProductRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListCatalogRuleProductListItemDto>>> Handle(GetListCatalogRuleProductQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CatalogRuleProduct> catalogRuleProducts = await _catalogRuleProductRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCatalogRuleProductListItemDto> response = _mapper.Map<GetListResponse<GetListCatalogRuleProductListItemDto>>(catalogRuleProducts);
             return CustomResponseDto<GetListResponse<GetListCatalogRuleProductListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}