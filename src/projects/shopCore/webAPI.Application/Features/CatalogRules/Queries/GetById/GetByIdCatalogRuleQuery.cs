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

namespace Application.Features.CatalogRules.Queries.GetById;

public class GetByIdCatalogRuleQuery : IRequest<CustomResponseDto<GetByIdCatalogRuleResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCatalogRuleQueryHandler : IRequestHandler<GetByIdCatalogRuleQuery, CustomResponseDto<GetByIdCatalogRuleResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICatalogRuleRepository _catalogRuleRepository;
        private readonly CatalogRuleBusinessRules _catalogRuleBusinessRules;

        public GetByIdCatalogRuleQueryHandler(IMapper mapper, ICatalogRuleRepository catalogRuleRepository, CatalogRuleBusinessRules catalogRuleBusinessRules)
        {
            _mapper = mapper;
            _catalogRuleRepository = catalogRuleRepository;
            _catalogRuleBusinessRules = catalogRuleBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdCatalogRuleResponse>> Handle(GetByIdCatalogRuleQuery request, CancellationToken cancellationToken)
        {
            CatalogRule? catalogRule = await _catalogRuleRepository.GetAsync(predicate: cr => cr.Id == request.Id, cancellationToken: cancellationToken);
            await _catalogRuleBusinessRules.CatalogRuleShouldExistWhenSelected(catalogRule);

            GetByIdCatalogRuleResponse response = _mapper.Map<GetByIdCatalogRuleResponse>(catalogRule);

          return CustomResponseDto<GetByIdCatalogRuleResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}