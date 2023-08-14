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

namespace Application.Features.CatalogRuleCustomerGroups.Commands.Update;

public class UpdateCatalogRuleCustomerGroupCommand : IRequest<CustomResponseDto<UpdatedCatalogRuleCustomerGroupResponse>>, ISecuredRequest
{
    public uint Id { get; set; }
    public uint CatalogRuleId { get; set; }
    public uint CustomerGroupId { get; set; }

    public string[] Roles => new[] { Admin, Write, CatalogRuleCustomerGroupsOperationClaims.Update };

    public class UpdateCatalogRuleCustomerGroupCommandHandler : IRequestHandler<UpdateCatalogRuleCustomerGroupCommand, CustomResponseDto<UpdatedCatalogRuleCustomerGroupResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICatalogRuleCustomerGroupRepository _catalogRuleCustomerGroupRepository;
        private readonly CatalogRuleCustomerGroupBusinessRules _catalogRuleCustomerGroupBusinessRules;

        public UpdateCatalogRuleCustomerGroupCommandHandler(IMapper mapper, ICatalogRuleCustomerGroupRepository catalogRuleCustomerGroupRepository,
                                         CatalogRuleCustomerGroupBusinessRules catalogRuleCustomerGroupBusinessRules)
        {
            _mapper = mapper;
            _catalogRuleCustomerGroupRepository = catalogRuleCustomerGroupRepository;
            _catalogRuleCustomerGroupBusinessRules = catalogRuleCustomerGroupBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedCatalogRuleCustomerGroupResponse>> Handle(UpdateCatalogRuleCustomerGroupCommand request, CancellationToken cancellationToken)
        {
            CatalogRuleCustomerGroup? catalogRuleCustomerGroup = await _catalogRuleCustomerGroupRepository.GetAsync(predicate: crcg => crcg.Id == request.Id, cancellationToken: cancellationToken);
            await _catalogRuleCustomerGroupBusinessRules.CatalogRuleCustomerGroupShouldExistWhenSelected(catalogRuleCustomerGroup);
            catalogRuleCustomerGroup = _mapper.Map(request, catalogRuleCustomerGroup);

            await _catalogRuleCustomerGroupRepository.UpdateAsync(catalogRuleCustomerGroup!);

            UpdatedCatalogRuleCustomerGroupResponse response = _mapper.Map<UpdatedCatalogRuleCustomerGroupResponse>(catalogRuleCustomerGroup);

          return CustomResponseDto<UpdatedCatalogRuleCustomerGroupResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}