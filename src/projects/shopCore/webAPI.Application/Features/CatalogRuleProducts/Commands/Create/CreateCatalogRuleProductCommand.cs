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

namespace Application.Features.CatalogRuleProducts.Commands.Create;

public class CreateCatalogRuleProductCommand : IRequest<CustomResponseDto<CreatedCatalogRuleProductResponse>>, ISecuredRequest
{
    public DateTime? StartsFrom { get; set; }
    public DateTime? EndsTill { get; set; }
    public bool EndOtherRules { get; set; }
    public string? ActionType { get; set; }
    public decimal DiscountAmount { get; set; }
    public uint SortOrder { get; set; }
    public uint ProductId { get; set; }
    public uint CustomerGroupId { get; set; }
    public uint CatalogRuleId { get; set; }
    public uint ChannelId { get; set; }

    public string[] Roles => new[] { Admin, Write, CatalogRuleProductsOperationClaims.Create };

    public class CreateCatalogRuleProductCommandHandler : IRequestHandler<CreateCatalogRuleProductCommand, CustomResponseDto<CreatedCatalogRuleProductResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICatalogRuleProductRepository _catalogRuleProductRepository;
        private readonly CatalogRuleProductBusinessRules _catalogRuleProductBusinessRules;

        public CreateCatalogRuleProductCommandHandler(IMapper mapper, ICatalogRuleProductRepository catalogRuleProductRepository,
                                         CatalogRuleProductBusinessRules catalogRuleProductBusinessRules)
        {
            _mapper = mapper;
            _catalogRuleProductRepository = catalogRuleProductRepository;
            _catalogRuleProductBusinessRules = catalogRuleProductBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedCatalogRuleProductResponse>> Handle(CreateCatalogRuleProductCommand request, CancellationToken cancellationToken)
        {
            CatalogRuleProduct catalogRuleProduct = _mapper.Map<CatalogRuleProduct>(request);

            await _catalogRuleProductRepository.AddAsync(catalogRuleProduct);

            CreatedCatalogRuleProductResponse response = _mapper.Map<CreatedCatalogRuleProductResponse>(catalogRuleProduct);
         return CustomResponseDto<CreatedCatalogRuleProductResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}