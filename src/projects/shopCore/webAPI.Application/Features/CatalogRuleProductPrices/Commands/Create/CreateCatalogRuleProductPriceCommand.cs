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

namespace Application.Features.CatalogRuleProductPrices.Commands.Create;

public class CreateCatalogRuleProductPriceCommand : IRequest<CustomResponseDto<CreatedCatalogRuleProductPriceResponse>>, ISecuredRequest
{
    public decimal Price { get; set; }
    public DateTime RuleDate { get; set; }
    public DateTime? StartsFrom { get; set; }
    public DateTime? EndsTill { get; set; }
    public uint ProductId { get; set; }
    public uint CustomerGroupId { get; set; }
    public uint CatalogRuleId { get; set; }
    public uint ChannelId { get; set; }

    public string[] Roles => new[] { Admin, Write, CatalogRuleProductPricesOperationClaims.Create };

    public class CreateCatalogRuleProductPriceCommandHandler : IRequestHandler<CreateCatalogRuleProductPriceCommand, CustomResponseDto<CreatedCatalogRuleProductPriceResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICatalogRuleProductPriceRepository _catalogRuleProductPriceRepository;
        private readonly CatalogRuleProductPriceBusinessRules _catalogRuleProductPriceBusinessRules;

        public CreateCatalogRuleProductPriceCommandHandler(IMapper mapper, ICatalogRuleProductPriceRepository catalogRuleProductPriceRepository,
                                         CatalogRuleProductPriceBusinessRules catalogRuleProductPriceBusinessRules)
        {
            _mapper = mapper;
            _catalogRuleProductPriceRepository = catalogRuleProductPriceRepository;
            _catalogRuleProductPriceBusinessRules = catalogRuleProductPriceBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedCatalogRuleProductPriceResponse>> Handle(CreateCatalogRuleProductPriceCommand request, CancellationToken cancellationToken)
        {
            CatalogRuleProductPrice catalogRuleProductPrice = _mapper.Map<CatalogRuleProductPrice>(request);

            await _catalogRuleProductPriceRepository.AddAsync(catalogRuleProductPrice);

            CreatedCatalogRuleProductPriceResponse response = _mapper.Map<CreatedCatalogRuleProductPriceResponse>(catalogRuleProductPrice);
         return CustomResponseDto<CreatedCatalogRuleProductPriceResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}