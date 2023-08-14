using Application.Features.CatalogRuleProducts.Constants;
using Application.Features.CatalogRuleProducts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CatalogRuleProducts.Constants.CatalogRuleProductsOperationClaims;

namespace Application.Features.CatalogRuleProducts.Queries.GetById;

public class GetByIdCatalogRuleProductQuery : IRequest<CustomResponseDto<GetByIdCatalogRuleProductResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCatalogRuleProductQueryHandler : IRequestHandler<GetByIdCatalogRuleProductQuery, CustomResponseDto<GetByIdCatalogRuleProductResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICatalogRuleProductRepository _catalogRuleProductRepository;
        private readonly CatalogRuleProductBusinessRules _catalogRuleProductBusinessRules;

        public GetByIdCatalogRuleProductQueryHandler(IMapper mapper, ICatalogRuleProductRepository catalogRuleProductRepository, CatalogRuleProductBusinessRules catalogRuleProductBusinessRules)
        {
            _mapper = mapper;
            _catalogRuleProductRepository = catalogRuleProductRepository;
            _catalogRuleProductBusinessRules = catalogRuleProductBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdCatalogRuleProductResponse>> Handle(GetByIdCatalogRuleProductQuery request, CancellationToken cancellationToken)
        {
            CatalogRuleProduct? catalogRuleProduct = await _catalogRuleProductRepository.GetAsync(predicate: crp => crp.Id == request.Id, cancellationToken: cancellationToken);
            await _catalogRuleProductBusinessRules.CatalogRuleProductShouldExistWhenSelected(catalogRuleProduct);

            GetByIdCatalogRuleProductResponse response = _mapper.Map<GetByIdCatalogRuleProductResponse>(catalogRuleProduct);

          return CustomResponseDto<GetByIdCatalogRuleProductResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}