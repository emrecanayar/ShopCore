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

namespace Application.Features.BookingProductAppointmentSlots.Commands.Create;

public class CreateBookingProductAppointmentSlotCommand : IRequest<CustomResponseDto<CreatedBookingProductAppointmentSlotResponse>>, ISecuredRequest
{
    public int? Duration { get; set; }
    public int? BreakTime { get; set; }
    public bool? SameSlotAllDays { get; set; }
    public string? Slots { get; set; }
    public uint BookingProductId { get; set; }

    public string[] Roles => new[] { Admin, Write, BookingProductAppointmentSlotsOperationClaims.Create };

    public class CreateBookingProductAppointmentSlotCommandHandler : IRequestHandler<CreateBookingProductAppointmentSlotCommand, CustomResponseDto<CreatedBookingProductAppointmentSlotResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBookingProductAppointmentSlotRepository _bookingProductAppointmentSlotRepository;
        private readonly BookingProductAppointmentSlotBusinessRules _bookingProductAppointmentSlotBusinessRules;

        public CreateBookingProductAppointmentSlotCommandHandler(IMapper mapper, IBookingProductAppointmentSlotRepository bookingProductAppointmentSlotRepository,
                                         BookingProductAppointmentSlotBusinessRules bookingProductAppointmentSlotBusinessRules)
        {
            _mapper = mapper;
            _bookingProductAppointmentSlotRepository = bookingProductAppointmentSlotRepository;
            _bookingProductAppointmentSlotBusinessRules = bookingProductAppointmentSlotBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedBookingProductAppointmentSlotResponse>> Handle(CreateBookingProductAppointmentSlotCommand request, CancellationToken cancellationToken)
        {
            BookingProductAppointmentSlot bookingProductAppointmentSlot = _mapper.Map<BookingProductAppointmentSlot>(request);

            await _bookingProductAppointmentSlotRepository.AddAsync(bookingProductAppointmentSlot);

            CreatedBookingProductAppointmentSlotResponse response = _mapper.Map<CreatedBookingProductAppointmentSlotResponse>(bookingProductAppointmentSlot);
         return CustomResponseDto<CreatedBookingProductAppointmentSlotResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}