using Application.Features.CatalogRuleProducts.Constants;
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

namespace Application.Features.CatalogRuleProducts.Commands.Delete;

public class DeleteCatalogRuleProductCommand : IRequest<CustomResponseDto<DeletedCatalogRuleProductResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CatalogRuleProductsOperationClaims.Delete };

    public class DeleteCatalogRuleProductCommandHandler : IRequestHandler<DeleteCatalogRuleProductCommand, CustomResponseDto<DeletedCatalogRuleProductResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICatalogRuleProductRepository _catalogRuleProductRepository;
        private readonly CatalogRuleProductBusinessRules _catalogRuleProductBusinessRules;

        public DeleteCatalogRuleProductCommandHandler(IMapper mapper, ICatalogRuleProductRepository catalogRuleProductRepository,
                                         CatalogRuleProductBusinessRules catalogRuleProductBusinessRules)
        {
            _mapper = mapper;
            _catalogRuleProductRepository = catalogRuleProductRepository;
            _catalogRuleProductBusinessRules = catalogRuleProductBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedCatalogRuleProductResponse>> Handle(DeleteCatalogRuleProductCommand request, CancellationToken cancellationToken)
        {
            CatalogRuleProduct? catalogRuleProduct = await _catalogRuleProductRepository.GetAsync(predicate: crp => crp.Id == request.Id, cancellationToken: cancellationToken);
            await _catalogRuleProductBusinessRules.CatalogRuleProductShouldExistWhenSelected(catalogRuleProduct);

            await _catalogRuleProductRepository.DeleteAsync(catalogRuleProduct!);

            DeletedCatalogRuleProductResponse response = _mapper.Map<DeletedCatalogRuleProductResponse>(catalogRuleProduct);

             return CustomResponseDto<DeletedCatalogRuleProductResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}