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

namespace Application.Features.CatalogRuleProducts.Commands.Update;

public class UpdateCatalogRuleProductCommand : IRequest<CustomResponseDto<UpdatedCatalogRuleProductResponse>>, ISecuredRequest
{
    public uint Id { get; set; }
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

    public string[] Roles => new[] { Admin, Write, CatalogRuleProductsOperationClaims.Update };

    public class UpdateCatalogRuleProductCommandHandler : IRequestHandler<UpdateCatalogRuleProductCommand, CustomResponseDto<UpdatedCatalogRuleProductResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICatalogRuleProductRepository _catalogRuleProductRepository;
        private readonly CatalogRuleProductBusinessRules _catalogRuleProductBusinessRules;

        public UpdateCatalogRuleProductCommandHandler(IMapper mapper, ICatalogRuleProductRepository catalogRuleProductRepository,
                                         CatalogRuleProductBusinessRules catalogRuleProductBusinessRules)
        {
            _mapper = mapper;
            _catalogRuleProductRepository = catalogRuleProductRepository;
            _catalogRuleProductBusinessRules = catalogRuleProductBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedCatalogRuleProductResponse>> Handle(UpdateCatalogRuleProductCommand request, CancellationToken cancellationToken)
        {
            CatalogRuleProduct? catalogRuleProduct = await _catalogRuleProductRepository.GetAsync(predicate: crp => crp.Id == request.Id, cancellationToken: cancellationToken);
            await _catalogRuleProductBusinessRules.CatalogRuleProductShouldExistWhenSelected(catalogRuleProduct);
            catalogRuleProduct = _mapper.Map(request, catalogRuleProduct);

            await _catalogRuleProductRepository.UpdateAsync(catalogRuleProduct!);

            UpdatedCatalogRuleProductResponse response = _mapper.Map<UpdatedCatalogRuleProductResponse>(catalogRuleProduct);

          return CustomResponseDto<UpdatedCatalogRuleProductResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}