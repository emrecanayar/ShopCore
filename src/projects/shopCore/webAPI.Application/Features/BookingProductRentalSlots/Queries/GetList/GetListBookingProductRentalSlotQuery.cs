using Application.Features.BookingProductRentalSlots.Constants;
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
using static Application.Features.BookingProductRentalSlots.Constants.BookingProductRentalSlotsOperationClaims;

namespace Application.Features.BookingProductRentalSlots.Queries.GetList;

public class GetListBookingProductRentalSlotQuery : IRequest<CustomResponseDto<GetListResponse<GetListBookingProductRentalSlotListItemDto>>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListBookingProductRentalSlotQueryHandler : IRequestHandler<GetListBookingProductRentalSlotQuery, CustomResponseDto<GetListResponse<GetListBookingProductRentalSlotListItemDto>>>
    {
        private readonly IBookingProductRentalSlotRepository _bookingProductRentalSlotRepository;
        private readonly IMapper _mapper;

        public GetListBookingProductRentalSlotQueryHandler(IBookingProductRentalSlotRepository bookingProductRentalSlotRepository, IMapper mapper)
        {
            _bookingProductRentalSlotRepository = bookingProductRentalSlotRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListBookingProductRentalSlotListItemDto>>> Handle(GetListBookingProductRentalSlotQuery request, CancellationToken cancellationToken)
        {
            IPaginate<BookingProductRentalSlot> bookingProductRentalSlots = await _bookingProductRentalSlotRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListBookingProductRentalSlotListItemDto> response = _mapper.Map<GetListResponse<GetListBookingProductRentalSlotListItemDto>>(bookingProductRentalSlots);
             return CustomResponseDto<GetListResponse<GetListBookingProductRentalSlotListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}