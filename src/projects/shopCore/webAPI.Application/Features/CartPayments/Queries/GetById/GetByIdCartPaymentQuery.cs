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

namespace Application.Features.CartPayments.Queries.GetById;

public class GetByIdCartPaymentQuery : IRequest<CustomResponseDto<GetByIdCartPaymentResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCartPaymentQueryHandler : IRequestHandler<GetByIdCartPaymentQuery, CustomResponseDto<GetByIdCartPaymentResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartPaymentRepository _cartPaymentRepository;
        private readonly CartPaymentBusinessRules _cartPaymentBusinessRules;

        public GetByIdCartPaymentQueryHandler(IMapper mapper, ICartPaymentRepository cartPaymentRepository, CartPaymentBusinessRules cartPaymentBusinessRules)
        {
            _mapper = mapper;
            _cartPaymentRepository = cartPaymentRepository;
            _cartPaymentBusinessRules = cartPaymentBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdCartPaymentResponse>> Handle(GetByIdCartPaymentQuery request, CancellationToken cancellationToken)
        {
            CartPayment? cartPayment = await _cartPaymentRepository.GetAsync(predicate: cp => cp.Id == request.Id, cancellationToken: cancellationToken);
            await _cartPaymentBusinessRules.CartPaymentShouldExistWhenSelected(cartPayment);

            GetByIdCartPaymentResponse response = _mapper.Map<GetByIdCartPaymentResponse>(cartPayment);

          return CustomResponseDto<GetByIdCartPaymentResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}