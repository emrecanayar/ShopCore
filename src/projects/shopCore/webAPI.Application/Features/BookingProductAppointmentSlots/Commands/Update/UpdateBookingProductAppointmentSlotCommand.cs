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

namespace Application.Features.BookingProductAppointmentSlots.Commands.Update;

public class UpdateBookingProductAppointmentSlotCommand : IRequest<CustomResponseDto<UpdatedBookingProductAppointmentSlotResponse>>, ISecuredRequest
{
    public uint Id { get; set; }
    public int? Duration { get; set; }
    public int? BreakTime { get; set; }
    public bool? SameSlotAllDays { get; set; }
    public string? Slots { get; set; }
    public uint BookingProductId { get; set; }

    public string[] Roles => new[] { Admin, Write, BookingProductAppointmentSlotsOperationClaims.Update };

    public class UpdateBookingProductAppointmentSlotCommandHandler : IRequestHandler<UpdateBookingProductAppointmentSlotCommand, CustomResponseDto<UpdatedBookingProductAppointmentSlotResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBookingProductAppointmentSlotRepository _bookingProductAppointmentSlotRepository;
        private readonly BookingProductAppointmentSlotBusinessRules _bookingProductAppointmentSlotBusinessRules;

        public UpdateBookingProductAppointmentSlotCommandHandler(IMapper mapper, IBookingProductAppointmentSlotRepository bookingProductAppointmentSlotRepository,
                                         BookingProductAppointmentSlotBusinessRules bookingProductAppointmentSlotBusinessRules)
        {
            _mapper = mapper;
            _bookingProductAppointmentSlotRepository = bookingProductAppointmentSlotRepository;
            _bookingProductAppointmentSlotBusinessRules = bookingProductAppointmentSlotBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedBookingProductAppointmentSlotResponse>> Handle(UpdateBookingProductAppointmentSlotCommand request, CancellationToken cancellationToken)
        {
            BookingProductAppointmentSlot? bookingProductAppointmentSlot = await _bookingProductAppointmentSlotRepository.GetAsync(predicate: bpas => bpas.Id == request.Id, cancellationToken: cancellationToken);
            await _bookingProductAppointmentSlotBusinessRules.BookingProductAppointmentSlotShouldExistWhenSelected(bookingProductAppointmentSlot);
            bookingProductAppointmentSlot = _mapper.Map(request, bookingProductAppointmentSlot);

            await _bookingProductAppointmentSlotRepository.UpdateAsync(bookingProductAppointmentSlot!);

            UpdatedBookingProductAppointmentSlotResponse response = _mapper.Map<UpdatedBookingProductAppointmentSlotResponse>(bookingProductAppointmentSlot);

          return CustomResponseDto<UpdatedBookingProductAppointmentSlotResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}