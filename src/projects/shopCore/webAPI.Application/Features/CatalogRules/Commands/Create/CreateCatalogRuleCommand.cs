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

namespace Application.Features.CatalogRules.Commands.Create;

public class CreateCatalogRuleCommand : IRequest<CustomResponseDto<CreatedCatalogRuleResponse>>, ISecuredRequest
{
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

    public string[] Roles => new[] { Admin, Write, CatalogRulesOperationClaims.Create };

    public class CreateCatalogRuleCommandHandler : IRequestHandler<CreateCatalogRuleCommand, CustomResponseDto<CreatedCatalogRuleResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICatalogRuleRepository _catalogRuleRepository;
        private readonly CatalogRuleBusinessRules _catalogRuleBusinessRules;

        public CreateCatalogRuleCommandHandler(IMapper mapper, ICatalogRuleRepository catalogRuleRepository,
                                         CatalogRuleBusinessRules catalogRuleBusinessRules)
        {
            _mapper = mapper;
            _catalogRuleRepository = catalogRuleRepository;
            _catalogRuleBusinessRules = catalogRuleBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedCatalogRuleResponse>> Handle(CreateCatalogRuleCommand request, CancellationToken cancellationToken)
        {
            CatalogRule catalogRule = _mapper.Map<CatalogRule>(request);

            await _catalogRuleRepository.AddAsync(catalogRule);

            CreatedCatalogRuleResponse response = _mapper.Map<CreatedCatalogRuleResponse>(catalogRule);
         return CustomResponseDto<CreatedCatalogRuleResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}