using Application.Features.CatalogRuleProductPrices.Constants;
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

namespace Application.Features.CatalogRuleProductPrices.Commands.Delete;

public class DeleteCatalogRuleProductPriceCommand : IRequest<CustomResponseDto<DeletedCatalogRuleProductPriceResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CatalogRuleProductPricesOperationClaims.Delete };

    public class DeleteCatalogRuleProductPriceCommandHandler : IRequestHandler<DeleteCatalogRuleProductPriceCommand, CustomResponseDto<DeletedCatalogRuleProductPriceResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICatalogRuleProductPriceRepository _catalogRuleProductPriceRepository;
        private readonly CatalogRuleProductPriceBusinessRules _catalogRuleProductPriceBusinessRules;

        public DeleteCatalogRuleProductPriceCommandHandler(IMapper mapper, ICatalogRuleProductPriceRepository catalogRuleProductPriceRepository,
                                         CatalogRuleProductPriceBusinessRules catalogRuleProductPriceBusinessRules)
        {
            _mapper = mapper;
            _catalogRuleProductPriceRepository = catalogRuleProductPriceRepository;
            _catalogRuleProductPriceBusinessRules = catalogRuleProductPriceBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedCatalogRuleProductPriceResponse>> Handle(DeleteCatalogRuleProductPriceCommand request, CancellationToken cancellationToken)
        {
            CatalogRuleProductPrice? catalogRuleProductPrice = await _catalogRuleProductPriceRepository.GetAsync(predicate: crpp => crpp.Id == request.Id, cancellationToken: cancellationToken);
            await _catalogRuleProductPriceBusinessRules.CatalogRuleProductPriceShouldExistWhenSelected(catalogRuleProductPrice);

            await _catalogRuleProductPriceRepository.DeleteAsync(catalogRuleProductPrice!);

            DeletedCatalogRuleProductPriceResponse response = _mapper.Map<DeletedCatalogRuleProductPriceResponse>(catalogRuleProductPrice);

             return CustomResponseDto<DeletedCatalogRuleProductPriceResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}