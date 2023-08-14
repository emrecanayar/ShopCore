using Application.Features.CatalogRules.Constants;
using Application.Features.CatalogRules.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CatalogRules.Constants.CatalogRulesOperationClaims;

namespace Application.Features.CatalogRules.Commands.Update;

public class UpdateCatalogRuleCommand : IRequest<CustomResponseDto<UpdatedCatalogRuleResponse>>, ISecuredRequest
{
    public uint Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime? StartsFrom { get; set; }
    public DateTime? EndsTill { get; set; }
    public bool Status { get; set; }
    public bool? ConditionType { get; set; }
    public string? Conditions { get; set; }
    public bool EndOtherRules { get; set; }
    public string? ActionType { get; set; }
    public decimal DiscountAmount { get; set; }
    public uint SortOrder { get; set; }

    public string[] Roles => new[] { Admin, Write, CatalogRulesOperationClaims.Update };

    public class UpdateCatalogRuleCommandHandler : IRequestHandler<UpdateCatalogRuleCommand, CustomResponseDto<UpdatedCatalogRuleResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICatalogRuleRepository _catalogRuleRepository;
        private readonly CatalogRuleBusinessRules _catalogRuleBusinessRules;

        public UpdateCatalogRuleCommandHandler(IMapper mapper, ICatalogRuleRepository catalogRuleRepository,
                                         CatalogRuleBusinessRules catalogRuleBusinessRules)
        {
            _mapper = mapper;
            _catalogRuleRepository = catalogRuleRepository;
            _catalogRuleBusinessRules = catalogRuleBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedCatalogRuleResponse>> Handle(UpdateCatalogRuleCommand request, CancellationToken cancellationToken)
        {
            CatalogRule? catalogRule = await _catalogRuleRepository.GetAsync(predicate: cr => cr.Id == request.Id, cancellationToken: cancellationToken);
            await _catalogRuleBusinessRules.CatalogRuleShouldExistWhenSelected(catalogRule);
            catalogRule = _mapper.Map(request, catalogRule);

            await _catalogRuleRepository.UpdateAsync(catalogRule!);

            UpdatedCatalogRuleResponse response = _mapper.Map<UpdatedCatalogRuleResponse>(catalogRule);

          return CustomResponseDto<UpdatedCatalogRuleResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}