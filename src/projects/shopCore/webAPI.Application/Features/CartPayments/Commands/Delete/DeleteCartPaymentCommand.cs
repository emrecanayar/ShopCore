using Application.Features.CartPayments.Constants;
using Application.Features.CartPayments.Constants;
using Application.Features.CartPayments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CartPayments.Constants.CartPaymentsOperationClaims;

namespace Application.Features.CartPayments.Commands.Delete;

public class DeleteCartPaymentCommand : IRequest<CustomResponseDto<DeletedCartPaymentResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CartPaymentsOperationClaims.Delete };

    public class DeleteCartPaymentCommandHandler : IRequestHandler<DeleteCartPaymentCommand, CustomResponseDto<DeletedCartPaymentResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartPaymentRepository _cartPaymentRepository;
        private readonly CartPaymentBusinessRules _cartPaymentBusinessRules;

        public DeleteCartPaymentCommandHandler(IMapper mapper, ICartPaymentRepository cartPaymentRepository,
                                         CartPaymentBusinessRules cartPaymentBusinessRules)
        {
            _mapper = mapper;
            _cartPaymentRepository = cartPaymentRepository;
            _cartPaymentBusinessRules = cartPaymentBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedCartPaymentResponse>> Handle(DeleteCartPaymentCommand request, CancellationToken cancellationToken)
        {
            CartPayment? cartPayment = await _cartPaymentRepository.GetAsync(predicate: cp => cp.Id == request.Id, cancellationToken: cancellationToken);
            await _cartPaymentBusinessRules.CartPaymentShouldExistWhenSelected(cartPayment);

            await _cartPaymentRepository.DeleteAsync(cartPayment!);

            DeletedCartPaymentResponse response = _mapper.Map<DeletedCartPaymentResponse>(cartPayment);

             return CustomResponseDto<DeletedCartPaymentResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}