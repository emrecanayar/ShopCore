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

namespace Application.Features.CatalogRuleCustomerGroups.Commands.Create;

public class CreateCatalogRuleCustomerGroupCommand : IRequest<CustomResponseDto<CreatedCatalogRuleCustomerGroupResponse>>, ISecuredRequest
{
    public uint CatalogRuleId { get; set; }
    public uint CustomerGroupId { get; set; }

    public string[] Roles => new[] { Admin, Write, CatalogRuleCustomerGroupsOperationClaims.Create };

    public class CreateCatalogRuleCustomerGroupCommandHandler : IRequestHandler<CreateCatalogRuleCustomerGroupCommand, CustomResponseDto<CreatedCatalogRuleCustomerGroupResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICatalogRuleCustomerGroupRepository _catalogRuleCustomerGroupRepository;
        private readonly CatalogRuleCustomerGroupBusinessRules _catalogRuleCustomerGroupBusinessRules;

        public CreateCatalogRuleCustomerGroupCommandHandler(IMapper mapper, ICatalogRuleCustomerGroupRepository catalogRuleCustomerGroupRepository,
                                         CatalogRuleCustomerGroupBusinessRules catalogRuleCustomerGroupBusinessRules)
        {
            _mapper = mapper;
            _catalogRuleCustomerGroupRepository = catalogRuleCustomerGroupRepository;
            _catalogRuleCustomerGroupBusinessRules = catalogRuleCustomerGroupBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedCatalogRuleCustomerGroupResponse>> Handle(CreateCatalogRuleCustomerGroupCommand request, CancellationToken cancellationToken)
        {
            CatalogRuleCustomerGroup catalogRuleCustomerGroup = _mapper.Map<CatalogRuleCustomerGroup>(request);

            await _catalogRuleCustomerGroupRepository.AddAsync(catalogRuleCustomerGroup);

            CreatedCatalogRuleCustomerGroupResponse response = _mapper.Map<CreatedCatalogRuleCustomerGroupResponse>(catalogRuleCustomerGroup);
         return CustomResponseDto<CreatedCatalogRuleCustomerGroupResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}