using Application.Features.BookingProductAppointmentSlots.Constants;
using Application.Features.BookingProductAppointmentSlots.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.BookingProductAppointmentSlots.Constants.BookingProductAppointmentSlotsOperationClaims;

namespace Application.Features.BookingProductAppointmentSlots.Queries.GetById;

public class GetByIdBookingProductAppointmentSlotQuery : IRequest<CustomResponseDto<GetByIdBookingProductAppointmentSlotResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdBookingProductAppointmentSlotQueryHandler : IRequestHandler<GetByIdBookingProductAppointmentSlotQuery, CustomResponseDto<GetByIdBookingProductAppointmentSlotResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBookingProductAppointmentSlotRepository _bookingProductAppointmentSlotRepository;
        private readonly BookingProductAppointmentSlotBusinessRules _bookingProductAppointmentSlotBusinessRules;

        public GetByIdBookingProductAppointmentSlotQueryHandler(IMapper mapper, IBookingProductAppointmentSlotRepository bookingProductAppointmentSlotRepository, BookingProductAppointmentSlotBusinessRules bookingProductAppointmentSlotBusinessRules)
        {
            _mapper = mapper;
            _bookingProductAppointmentSlotRepository = bookingProductAppointmentSlotRepository;
            _bookingProductAppointmentSlotBusinessRules = bookingProductAppointmentSlotBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdBookingProductAppointmentSlotResponse>> Handle(GetByIdBookingProductAppointmentSlotQuery request, CancellationToken cancellationToken)
        {
            BookingProductAppointmentSlot? bookingProductAppointmentSlot = await _bookingProductAppointmentSlotRepository.GetAsync(predicate: bpas => bpas.Id == request.Id, cancellationToken: cancellationToken);
            await _bookingProductAppointmentSlotBusinessRules.BookingProductAppointmentSlotShouldExistWhenSelected(bookingProductAppointmentSlot);

            GetByIdBookingProductAppointmentSlotResponse response = _mapper.Map<GetByIdBookingProductAppointmentSlotResponse>(bookingProductAppointmentSlot);

          return CustomResponseDto<GetByIdBookingProductAppointmentSlotResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}