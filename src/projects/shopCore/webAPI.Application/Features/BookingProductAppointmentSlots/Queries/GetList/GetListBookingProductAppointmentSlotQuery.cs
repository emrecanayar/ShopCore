using Application.Features.BookingProductAppointmentSlots.Constants;
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
using static Application.Features.BookingProductAppointmentSlots.Constants.BookingProductAppointmentSlotsOperationClaims;

namespace Application.Features.BookingProductAppointmentSlots.Queries.GetList;

public class GetListBookingProductAppointmentSlotQuery : IRequest<CustomResponseDto<GetListResponse<GetListBookingProductAppointmentSlotListItemDto>>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListBookingProductAppointmentSlotQueryHandler : IRequestHandler<GetListBookingProductAppointmentSlotQuery, CustomResponseDto<GetListResponse<GetListBookingProductAppointmentSlotListItemDto>>>
    {
        private readonly IBookingProductAppointmentSlotRepository _bookingProductAppointmentSlotRepository;
        private readonly IMapper _mapper;

        public GetListBookingProductAppointmentSlotQueryHandler(IBookingProductAppointmentSlotRepository bookingProductAppointmentSlotRepository, IMapper mapper)
        {
            _bookingProductAppointmentSlotRepository = bookingProductAppointmentSlotRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListBookingProductAppointmentSlotListItemDto>>> Handle(GetListBookingProductAppointmentSlotQuery request, CancellationToken cancellationToken)
        {
            IPaginate<BookingProductAppointmentSlot> bookingProductAppointmentSlots = await _bookingProductAppointmentSlotRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListBookingProductAppointmentSlotListItemDto> response = _mapper.Map<GetListResponse<GetListBookingProductAppointmentSlotListItemDto>>(bookingProductAppointmentSlots);
             return CustomResponseDto<GetListResponse<GetListBookingProductAppointmentSlotListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}