using Application.Features.CartRuleCustomers.Constants;
using Application.Features.CartRuleCustomers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CartRuleCustomers.Constants.CartRuleCustomersOperationClaims;

namespace Application.Features.CartRuleCustomers.Queries.GetById;

public class GetByIdCartRuleCustomerQuery : IRequest<CustomResponseDto<GetByIdCartRuleCustomerResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCartRuleCustomerQueryHandler : IRequestHandler<GetByIdCartRuleCustomerQuery, CustomResponseDto<GetByIdCartRuleCustomerResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartRuleCustomerRepository _cartRuleCustomerRepository;
        private readonly CartRuleCustomerBusinessRules _cartRuleCustomerBusinessRules;

        public GetByIdCartRuleCustomerQueryHandler(IMapper mapper, ICartRuleCustomerRepository cartRuleCustomerRepository, CartRuleCustomerBusinessRules cartRuleCustomerBusinessRules)
        {
            _mapper = mapper;
            _cartRuleCustomerRepository = cartRuleCustomerRepository;
            _cartRuleCustomerBusinessRules = cartRuleCustomerBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdCartRuleCustomerResponse>> Handle(GetByIdCartRuleCustomerQuery request, CancellationToken cancellationToken)
        {
            CartRuleCustomer? cartRuleCustomer = await _cartRuleCustomerRepository.GetAsync(predicate: crc => crc.Id == request.Id, cancellationToken: cancellationToken);
            await _cartRuleCustomerBusinessRules.CartRuleCustomerShouldExistWhenSelected(cartRuleCustomer);

            GetByIdCartRuleCustomerResponse response = _mapper.Map<GetByIdCartRuleCustomerResponse>(cartRuleCustomer);

          return CustomResponseDto<GetByIdCartRuleCustomerResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}