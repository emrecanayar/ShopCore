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

namespace Application.Features.CatalogRuleProductPrices.Commands.Update;

public class UpdateCatalogRuleProductPriceCommand : IRequest<CustomResponseDto<UpdatedCatalogRuleProductPriceResponse>>, ISecuredRequest
{
    public uint Id { get; set; }
    public decimal Price { get; set; }
    public DateTime RuleDate { get; set; }
    public DateTime? StartsFrom { get; set; }
    public DateTime? EndsTill { get; set; }
    public uint ProductId { get; set; }
    public uint CustomerGroupId { get; set; }
    public uint CatalogRuleId { get; set; }
    public uint ChannelId { get; set; }

    public string[] Roles => new[] { Admin, Write, CatalogRuleProductPricesOperationClaims.Update };

    public class UpdateCatalogRuleProductPriceCommandHandler : IRequestHandler<UpdateCatalogRuleProductPriceCommand, CustomResponseDto<UpdatedCatalogRuleProductPriceResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICatalogRuleProductPriceRepository _catalogRuleProductPriceRepository;
        private readonly CatalogRuleProductPriceBusinessRules _catalogRuleProductPriceBusinessRules;

        public UpdateCatalogRuleProductPriceCommandHandler(IMapper mapper, ICatalogRuleProductPriceRepository catalogRuleProductPriceRepository,
                                         CatalogRuleProductPriceBusinessRules catalogRuleProductPriceBusinessRules)
        {
            _mapper = mapper;
            _catalogRuleProductPriceRepository = catalogRuleProductPriceRepository;
            _catalogRuleProductPriceBusinessRules = catalogRuleProductPriceBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedCatalogRuleProductPriceResponse>> Handle(UpdateCatalogRuleProductPriceCommand request, CancellationToken cancellationToken)
        {
            CatalogRuleProductPrice? catalogRuleProductPrice = await _catalogRuleProductPriceRepository.GetAsync(predicate: crpp => crpp.Id == request.Id, cancellationToken: cancellationToken);
            await _catalogRuleProductPriceBusinessRules.CatalogRuleProductPriceShouldExistWhenSelected(catalogRuleProductPrice);
            catalogRuleProductPrice = _mapper.Map(request, catalogRuleProductPrice);

            await _catalogRuleProductPriceRepository.UpdateAsync(catalogRuleProductPrice!);

            UpdatedCatalogRuleProductPriceResponse response = _mapper.Map<UpdatedCatalogRuleProductPriceResponse>(catalogRuleProductPrice);

          return CustomResponseDto<UpdatedCatalogRuleProductPriceResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}