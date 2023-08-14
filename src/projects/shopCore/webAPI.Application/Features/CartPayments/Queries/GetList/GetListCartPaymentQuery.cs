using Application.Features.CartPayments.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.CartPayments.Constants.CartPaymentsOperationClaims;

namespace Application.Features.CartPayments.Queries.GetList;

public class GetListCartPaymentQuery : IRequest<CustomResponseDto<GetListResponse<GetListCartPaymentListItemDto>>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListCartPaymentQueryHandler : IRequestHandler<GetListCartPaymentQuery, CustomResponseDto<GetListResponse<GetListCartPaymentListItemDto>>>
    {
        private readonly ICartPaymentRepository _cartPaymentRepository;
        private readonly IMapper _mapper;

        public GetListCartPaymentQueryHandler(ICartPaymentRepository cartPaymentRepository, IMapper mapper)
        {
            _cartPaymentRepository = cartPaymentRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListCartPaymentListItemDto>>> Handle(GetListCartPaymentQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CartPayment> cartPayments = await _cartPaymentRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCartPaymentListItemDto> response = _mapper.Map<GetListResponse<GetListCartPaymentListItemDto>>(cartPayments);
             return CustomResponseDto<GetListResponse<GetListCartPaymentListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}