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

namespace Application.Features.CartPayments.Commands.Create;

public class CreateCartPaymentCommand : IRequest<CustomResponseDto<CreatedCartPaymentResponse>>, ISecuredRequest
{
    public string Method { get; set; }
    public string? MethodTitle { get; set; }
    public uint? CartId { get; set; }

    public string[] Roles => new[] { Admin, Write, CartPaymentsOperationClaims.Create };

    public class CreateCartPaymentCommandHandler : IRequestHandler<CreateCartPaymentCommand, CustomResponseDto<CreatedCartPaymentResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartPaymentRepository _cartPaymentRepository;
        private readonly CartPaymentBusinessRules _cartPaymentBusinessRules;

        public CreateCartPaymentCommandHandler(IMapper mapper, ICartPaymentRepository cartPaymentRepository,
                                         CartPaymentBusinessRules cartPaymentBusinessRules)
        {
            _mapper = mapper;
            _cartPaymentRepository = cartPaymentRepository;
            _cartPaymentBusinessRules = cartPaymentBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedCartPaymentResponse>> Handle(CreateCartPaymentCommand request, CancellationToken cancellationToken)
        {
            CartPayment cartPayment = _mapper.Map<CartPayment>(request);

            await _cartPaymentRepository.AddAsync(cartPayment);

            CreatedCartPaymentResponse response = _mapper.Map<CreatedCartPaymentResponse>(cartPayment);
         return CustomResponseDto<CreatedCartPaymentResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}