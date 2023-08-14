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

namespace Application.Features.CartRuleCustomers.Commands.Create;

public class CreateCartRuleCustomerCommand : IRequest<CustomResponseDto<CreatedCartRuleCustomerResponse>>, ISecuredRequest
{
    public ulong TimesUsed { get; set; }
    public uint CartRuleId { get; set; }
    public uint CustomerId { get; set; }

    public string[] Roles => new[] { Admin, Write, CartRuleCustomersOperationClaims.Create };

    public class CreateCartRuleCustomerCommandHandler : IRequestHandler<CreateCartRuleCustomerCommand, CustomResponseDto<CreatedCartRuleCustomerResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartRuleCustomerRepository _cartRuleCustomerRepository;
        private readonly CartRuleCustomerBusinessRules _cartRuleCustomerBusinessRules;

        public CreateCartRuleCustomerCommandHandler(IMapper mapper, ICartRuleCustomerRepository cartRuleCustomerRepository,
                                         CartRuleCustomerBusinessRules cartRuleCustomerBusinessRules)
        {
            _mapper = mapper;
            _cartRuleCustomerRepository = cartRuleCustomerRepository;
            _cartRuleCustomerBusinessRules = cartRuleCustomerBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedCartRuleCustomerResponse>> Handle(CreateCartRuleCustomerCommand request, CancellationToken cancellationToken)
        {
            CartRuleCustomer cartRuleCustomer = _mapper.Map<CartRuleCustomer>(request);

            await _cartRuleCustomerRepository.AddAsync(cartRuleCustomer);

            CreatedCartRuleCustomerResponse response = _mapper.Map<CreatedCartRuleCustomerResponse>(cartRuleCustomer);
         return CustomResponseDto<CreatedCartRuleCustomerResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}