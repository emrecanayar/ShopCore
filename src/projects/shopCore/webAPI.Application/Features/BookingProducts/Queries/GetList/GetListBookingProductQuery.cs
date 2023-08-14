using Application.Features.BookingProducts.Constants;
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
using static Application.Features.BookingProducts.Constants.BookingProductsOperationClaims;

namespace Application.Features.BookingProducts.Queries.GetList;

public class GetListBookingProductQuery : IRequest<CustomResponseDto<GetListResponse<GetListBookingProductListItemDto>>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListBookingProductQueryHandler : IRequestHandler<GetListBookingProductQuery, CustomResponseDto<GetListResponse<GetListBookingProductListItemDto>>>
    {
        private readonly IBookingProductRepository _bookingProductRepository;
        private readonly IMapper _mapper;

        public GetListBookingProductQueryHandler(IBookingProductRepository bookingProductRepository, IMapper mapper)
        {
            _bookingProductRepository = bookingProductRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListBookingProductListItemDto>>> Handle(GetListBookingProductQuery request, CancellationToken cancellationToken)
        {
            IPaginate<BookingProduct> bookingProducts = await _bookingProductRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListBookingProductListItemDto> response = _mapper.Map<GetListResponse<GetListBookingProductListItemDto>>(bookingProducts);
             return CustomResponseDto<GetListResponse<GetListBookingProductListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}