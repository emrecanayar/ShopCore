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

namespace Application.Features.CartPayments.Commands.Update;

public class UpdateCartPaymentCommand : IRequest<CustomResponseDto<UpdatedCartPaymentResponse>>, ISecuredRequest
{
    public uint Id { get; set; }
    public string Method { get; set; }
    public string? MethodTitle { get; set; }
    public uint? CartId { get; set; }

    public string[] Roles => new[] { Admin, Write, CartPaymentsOperationClaims.Update };

    public class UpdateCartPaymentCommandHandler : IRequestHandler<UpdateCartPaymentCommand, CustomResponseDto<UpdatedCartPaymentResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartPaymentRepository _cartPaymentRepository;
        private readonly CartPaymentBusinessRules _cartPaymentBusinessRules;

        public UpdateCartPaymentCommandHandler(IMapper mapper, ICartPaymentRepository cartPaymentRepository,
                                         CartPaymentBusinessRules cartPaymentBusinessRules)
        {
            _mapper = mapper;
            _cartPaymentRepository = cartPaymentRepository;
            _cartPaymentBusinessRules = cartPaymentBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedCartPaymentResponse>> Handle(UpdateCartPaymentCommand request, CancellationToken cancellationToken)
        {
            CartPayment? cartPayment = await _cartPaymentRepository.GetAsync(predicate: cp => cp.Id == request.Id, cancellationToken: cancellationToken);
            await _cartPaymentBusinessRules.CartPaymentShouldExistWhenSelected(cartPayment);
            cartPayment = _mapper.Map(request, cartPayment);

            await _cartPaymentRepository.UpdateAsync(cartPayment!);

            UpdatedCartPaymentResponse response = _mapper.Map<UpdatedCartPaymentResponse>(cartPayment);

          return CustomResponseDto<UpdatedCartPaymentResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}