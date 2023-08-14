using Application.Features.CatalogRuleProductPrices.Constants;
using Application.Features.CatalogRuleProductPrices.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CatalogRuleProductPrices.Constants.CatalogRuleProductPricesOperationClaims;

namespace Application.Features.CatalogRuleProductPrices.Queries.GetById;

public class GetByIdCatalogRuleProductPriceQuery : IRequest<CustomResponseDto<GetByIdCatalogRuleProductPriceResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCatalogRuleProductPriceQueryHandler : IRequestHandler<GetByIdCatalogRuleProductPriceQuery, CustomResponseDto<GetByIdCatalogRuleProductPriceResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICatalogRuleProductPriceRepository _catalogRuleProductPriceRepository;
        private readonly CatalogRuleProductPriceBusinessRules _catalogRuleProductPriceBusinessRules;

        public GetByIdCatalogRuleProductPriceQueryHandler(IMapper mapper, ICatalogRuleProductPriceRepository catalogRuleProductPriceRepository, CatalogRuleProductPriceBusinessRules catalogRuleProductPriceBusinessRules)
        {
            _mapper = mapper;
            _catalogRuleProductPriceRepository = catalogRuleProductPriceRepository;
            _catalogRuleProductPriceBusinessRules = catalogRuleProductPriceBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdCatalogRuleProductPriceResponse>> Handle(GetByIdCatalogRuleProductPriceQuery request, CancellationToken cancellationToken)
        {
            CatalogRuleProductPrice? catalogRuleProductPrice = await _catalogRuleProductPriceRepository.GetAsync(predicate: crpp => crpp.Id == request.Id, cancellationToken: cancellationToken);
            await _catalogRuleProductPriceBusinessRules.CatalogRuleProductPriceShouldExistWhenSelected(catalogRuleProductPrice);

            GetByIdCatalogRuleProductPriceResponse response = _mapper.Map<GetByIdCatalogRuleProductPriceResponse>(catalogRuleProductPrice);

          return CustomResponseDto<GetByIdCatalogRuleProductPriceResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}