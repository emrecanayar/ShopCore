using Application.Features.CatalogRuleCustomerGroups.Constants;
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

namespace Application.Features.CatalogRuleCustomerGroups.Commands.Delete;

public class DeleteCatalogRuleCustomerGroupCommand : IRequest<CustomResponseDto<DeletedCatalogRuleCustomerGroupResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CatalogRuleCustomerGroupsOperationClaims.Delete };

    public class DeleteCatalogRuleCustomerGroupCommandHandler : IRequestHandler<DeleteCatalogRuleCustomerGroupCommand, CustomResponseDto<DeletedCatalogRuleCustomerGroupResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICatalogRuleCustomerGroupRepository _catalogRuleCustomerGroupRepository;
        private readonly CatalogRuleCustomerGroupBusinessRules _catalogRuleCustomerGroupBusinessRules;

        public DeleteCatalogRuleCustomerGroupCommandHandler(IMapper mapper, ICatalogRuleCustomerGroupRepository catalogRuleCustomerGroupRepository,
                                         CatalogRuleCustomerGroupBusinessRules catalogRuleCustomerGroupBusinessRules)
        {
            _mapper = mapper;
            _catalogRuleCustomerGroupRepository = catalogRuleCustomerGroupRepository;
            _catalogRuleCustomerGroupBusinessRules = catalogRuleCustomerGroupBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedCatalogRuleCustomerGroupResponse>> Handle(DeleteCatalogRuleCustomerGroupCommand request, CancellationToken cancellationToken)
        {
            CatalogRuleCustomerGroup? catalogRuleCustomerGroup = await _catalogRuleCustomerGroupRepository.GetAsync(predicate: crcg => crcg.Id == request.Id, cancellationToken: cancellationToken);
            await _catalogRuleCustomerGroupBusinessRules.CatalogRuleCustomerGroupShouldExistWhenSelected(catalogRuleCustomerGroup);

            await _catalogRuleCustomerGroupRepository.DeleteAsync(catalogRuleCustomerGroup!);

            DeletedCatalogRuleCustomerGroupResponse response = _mapper.Map<DeletedCatalogRuleCustomerGroupResponse>(catalogRuleCustomerGroup);

             return CustomResponseDto<DeletedCatalogRuleCustomerGroupResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}