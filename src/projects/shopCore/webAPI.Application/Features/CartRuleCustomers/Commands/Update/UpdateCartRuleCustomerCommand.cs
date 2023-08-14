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

namespace Application.Features.CartRuleCustomers.Commands.Update;

public class UpdateCartRuleCustomerCommand : IRequest<CustomResponseDto<UpdatedCartRuleCustomerResponse>>, ISecuredRequest
{
    public uint Id { get; set; }
    public ulong TimesUsed { get; set; }
    public uint CartRuleId { get; set; }
    public uint CustomerId { get; set; }

    public string[] Roles => new[] { Admin, Write, CartRuleCustomersOperationClaims.Update };

    public class UpdateCartRuleCustomerCommandHandler : IRequestHandler<UpdateCartRuleCustomerCommand, CustomResponseDto<UpdatedCartRuleCustomerResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartRuleCustomerRepository _cartRuleCustomerRepository;
        private readonly CartRuleCustomerBusinessRules _cartRuleCustomerBusinessRules;

        public UpdateCartRuleCustomerCommandHandler(IMapper mapper, ICartRuleCustomerRepository cartRuleCustomerRepository,
                                         CartRuleCustomerBusinessRules cartRuleCustomerBusinessRules)
        {
            _mapper = mapper;
            _cartRuleCustomerRepository = cartRuleCustomerRepository;
            _cartRuleCustomerBusinessRules = cartRuleCustomerBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedCartRuleCustomerResponse>> Handle(UpdateCartRuleCustomerCommand request, CancellationToken cancellationToken)
        {
            CartRuleCustomer? cartRuleCustomer = await _cartRuleCustomerRepository.GetAsync(predicate: crc => crc.Id == request.Id, cancellationToken: cancellationToken);
            await _cartRuleCustomerBusinessRules.CartRuleCustomerShouldExistWhenSelected(cartRuleCustomer);
            cartRuleCustomer = _mapper.Map(request, cartRuleCustomer);

            await _cartRuleCustomerRepository.UpdateAsync(cartRuleCustomer!);

            UpdatedCartRuleCustomerResponse response = _mapper.Map<UpdatedCartRuleCustomerResponse>(cartRuleCustomer);

          return CustomResponseDto<UpdatedCartRuleCustomerResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}