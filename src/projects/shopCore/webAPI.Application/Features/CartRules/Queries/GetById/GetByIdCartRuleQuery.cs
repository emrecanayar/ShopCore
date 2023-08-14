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

namespace Application.Features.CartRules.Queries.GetById;

public class GetByIdCartRuleQuery : IRequest<CustomResponseDto<GetByIdCartRuleResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCartRuleQueryHandler : IRequestHandler<GetByIdCartRuleQuery, CustomResponseDto<GetByIdCartRuleResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartRuleRepository _cartRuleRepository;
        private readonly CartRuleBusinessRules _cartRuleBusinessRules;

        public GetByIdCartRuleQueryHandler(IMapper mapper, ICartRuleRepository cartRuleRepository, CartRuleBusinessRules cartRuleBusinessRules)
        {
            _mapper = mapper;
            _cartRuleRepository = cartRuleRepository;
            _cartRuleBusinessRules = cartRuleBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdCartRuleResponse>> Handle(GetByIdCartRuleQuery request, CancellationToken cancellationToken)
        {
            CartRule? cartRule = await _cartRuleRepository.GetAsync(predicate: cr => cr.Id == request.Id, cancellationToken: cancellationToken);
            await _cartRuleBusinessRules.CartRuleShouldExistWhenSelected(cartRule);

            GetByIdCartRuleResponse response = _mapper.Map<GetByIdCartRuleResponse>(cartRule);

          return CustomResponseDto<GetByIdCartRuleResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}