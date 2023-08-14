using Application.Features.CatalogRuleCustomerGroups.Constants;
using Application.Features.CatalogRuleCustomerGroups.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CatalogRuleCustomerGroups.Constants.CatalogRuleCustomerGroupsOperationClaims;

namespace Application.Features.CatalogRuleCustomerGroups.Queries.GetById;

public class GetByIdCatalogRuleCustomerGroupQuery : IRequest<CustomResponseDto<GetByIdCatalogRuleCustomerGroupResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCatalogRuleCustomerGroupQueryHandler : IRequestHandler<GetByIdCatalogRuleCustomerGroupQuery, CustomResponseDto<GetByIdCatalogRuleCustomerGroupResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICatalogRuleCustomerGroupRepository _catalogRuleCustomerGroupRepository;
        private readonly CatalogRuleCustomerGroupBusinessRules _catalogRuleCustomerGroupBusinessRules;

        public GetByIdCatalogRuleCustomerGroupQueryHandler(IMapper mapper, ICatalogRuleCustomerGroupRepository catalogRuleCustomerGroupRepository, CatalogRuleCustomerGroupBusinessRules catalogRuleCustomerGroupBusinessRules)
        {
            _mapper = mapper;
            _catalogRuleCustomerGroupRepository = catalogRuleCustomerGroupRepository;
            _catalogRuleCustomerGroupBusinessRules = catalogRuleCustomerGroupBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdCatalogRuleCustomerGroupResponse>> Handle(GetByIdCatalogRuleCustomerGroupQuery request, CancellationToken cancellationToken)
        {
            CatalogRuleCustomerGroup? catalogRuleCustomerGroup = await _catalogRuleCustomerGroupRepository.GetAsync(predicate: crcg => crcg.Id == request.Id, cancellationToken: cancellationToken);
            await _catalogRuleCustomerGroupBusinessRules.CatalogRuleCustomerGroupShouldExistWhenSelected(catalogRuleCustomerGroup);

            GetByIdCatalogRuleCustomerGroupResponse response = _mapper.Map<GetByIdCatalogRuleCustomerGroupResponse>(catalogRuleCustomerGroup);

          return CustomResponseDto<GetByIdCatalogRuleCustomerGroupResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}