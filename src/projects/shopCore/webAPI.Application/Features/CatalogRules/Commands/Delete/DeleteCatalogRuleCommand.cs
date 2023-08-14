using Application.Features.CatalogRules.Constants;
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

namespace Application.Features.CatalogRules.Commands.Delete;

public class DeleteCatalogRuleCommand : IRequest<CustomResponseDto<DeletedCatalogRuleResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CatalogRulesOperationClaims.Delete };

    public class DeleteCatalogRuleCommandHandler : IRequestHandler<DeleteCatalogRuleCommand, CustomResponseDto<DeletedCatalogRuleResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICatalogRuleRepository _catalogRuleRepository;
        private readonly CatalogRuleBusinessRules _catalogRuleBusinessRules;

        public DeleteCatalogRuleCommandHandler(IMapper mapper, ICatalogRuleRepository catalogRuleRepository,
                                         CatalogRuleBusinessRules catalogRuleBusinessRules)
        {
            _mapper = mapper;
            _catalogRuleRepository = catalogRuleRepository;
            _catalogRuleBusinessRules = catalogRuleBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedCatalogRuleResponse>> Handle(DeleteCatalogRuleCommand request, CancellationToken cancellationToken)
        {
            CatalogRule? catalogRule = await _catalogRuleRepository.GetAsync(predicate: cr => cr.Id == request.Id, cancellationToken: cancellationToken);
            await _catalogRuleBusinessRules.CatalogRuleShouldExistWhenSelected(catalogRule);

            await _catalogRuleRepository.DeleteAsync(catalogRule!);

            DeletedCatalogRuleResponse response = _mapper.Map<DeletedCatalogRuleResponse>(catalogRule);

             return CustomResponseDto<DeletedCatalogRuleResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}