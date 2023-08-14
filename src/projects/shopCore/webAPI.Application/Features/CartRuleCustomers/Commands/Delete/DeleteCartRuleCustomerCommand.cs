using Application.Features.CartRuleCustomers.Constants;
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

namespace Application.Features.CartRuleCustomers.Commands.Delete;

public class DeleteCartRuleCustomerCommand : IRequest<CustomResponseDto<DeletedCartRuleCustomerResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CartRuleCustomersOperationClaims.Delete };

    public class DeleteCartRuleCustomerCommandHandler : IRequestHandler<DeleteCartRuleCustomerCommand, CustomResponseDto<DeletedCartRuleCustomerResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartRuleCustomerRepository _cartRuleCustomerRepository;
        private readonly CartRuleCustomerBusinessRules _cartRuleCustomerBusinessRules;

        public DeleteCartRuleCustomerCommandHandler(IMapper mapper, ICartRuleCustomerRepository cartRuleCustomerRepository,
                                         CartRuleCustomerBusinessRules cartRuleCustomerBusinessRules)
        {
            _mapper = mapper;
            _cartRuleCustomerRepository = cartRuleCustomerRepository;
            _cartRuleCustomerBusinessRules = cartRuleCustomerBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedCartRuleCustomerResponse>> Handle(DeleteCartRuleCustomerCommand request, CancellationToken cancellationToken)
        {
            CartRuleCustomer? cartRuleCustomer = await _cartRuleCustomerRepository.GetAsync(predicate: crc => crc.Id == request.Id, cancellationToken: cancellationToken);
            await _cartRuleCustomerBusinessRules.CartRuleCustomerShouldExistWhenSelected(cartRuleCustomer);

            await _cartRuleCustomerRepository.DeleteAsync(cartRuleCustomer!);

            DeletedCartRuleCustomerResponse response = _mapper.Map<DeletedCartRuleCustomerResponse>(cartRuleCustomer);

             return CustomResponseDto<DeletedCartRuleCustomerResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}