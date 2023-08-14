using Application.Features.CartRules.Constants;
using Application.Features.CartRules.Constants;
using Application.Features.CartRules.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CartRules.Constants.CartRulesOperationClaims;

namespace Application.Features.CartRules.Commands.Delete;

public class DeleteCartRuleCommand : IRequest<CustomResponseDto<DeletedCartRuleResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CartRulesOperationClaims.Delete };

    public class DeleteCartRuleCommandHandler : IRequestHandler<DeleteCartRuleCommand, CustomResponseDto<DeletedCartRuleResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartRuleRepository _cartRuleRepository;
        private readonly CartRuleBusinessRules _cartRuleBusinessRules;

        public DeleteCartRuleCommandHandler(IMapper mapper, ICartRuleRepository cartRuleRepository,
                                         CartRuleBusinessRules cartRuleBusinessRules)
        {
            _mapper = mapper;
            _cartRuleRepository = cartRuleRepository;
            _cartRuleBusinessRules = cartRuleBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedCartRuleResponse>> Handle(DeleteCartRuleCommand request, CancellationToken cancellationToken)
        {
            CartRule? cartRule = await _cartRuleRepository.GetAsync(predicate: cr => cr.Id == request.Id, cancellationToken: cancellationToken);
            await _cartRuleBusinessRules.CartRuleShouldExistWhenSelected(cartRule);

            await _cartRuleRepository.DeleteAsync(cartRule!);

            DeletedCartRuleResponse response = _mapper.Map<DeletedCartRuleResponse>(cartRule);

             return CustomResponseDto<DeletedCartRuleResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}