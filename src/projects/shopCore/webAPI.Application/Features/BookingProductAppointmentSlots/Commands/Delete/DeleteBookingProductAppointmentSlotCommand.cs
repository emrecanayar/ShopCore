using Application.Features.BookingProductAppointmentSlots.Constants;
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

namespace Application.Features.BookingProductAppointmentSlots.Commands.Delete;

public class DeleteBookingProductAppointmentSlotCommand : IRequest<CustomResponseDto<DeletedBookingProductAppointmentSlotResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Write, BookingProductAppointmentSlotsOperationClaims.Delete };

    public class DeleteBookingProductAppointmentSlotCommandHandler : IRequestHandler<DeleteBookingProductAppointmentSlotCommand, CustomResponseDto<DeletedBookingProductAppointmentSlotResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBookingProductAppointmentSlotRepository _bookingProductAppointmentSlotRepository;
        private readonly BookingProductAppointmentSlotBusinessRules _bookingProductAppointmentSlotBusinessRules;

        public DeleteBookingProductAppointmentSlotCommandHandler(IMapper mapper, IBookingProductAppointmentSlotRepository bookingProductAppointmentSlotRepository,
                                         BookingProductAppointmentSlotBusinessRules bookingProductAppointmentSlotBusinessRules)
        {
            _mapper = mapper;
            _bookingProductAppointmentSlotRepository = bookingProductAppointmentSlotRepository;
            _bookingProductAppointmentSlotBusinessRules = bookingProductAppointmentSlotBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedBookingProductAppointmentSlotResponse>> Handle(DeleteBookingProductAppointmentSlotCommand request, CancellationToken cancellationToken)
        {
            BookingProductAppointmentSlot? bookingProductAppointmentSlot = await _bookingProductAppointmentSlotRepository.GetAsync(predicate: bpas => bpas.Id == request.Id, cancellationToken: cancellationToken);
            await _bookingProductAppointmentSlotBusinessRules.BookingProductAppointmentSlotShouldExistWhenSelected(bookingProductAppointmentSlot);

            await _bookingProductAppointmentSlotRepository.DeleteAsync(bookingProductAppointmentSlot!);

            DeletedBookingProductAppointmentSlotResponse response = _mapper.Map<DeletedBookingProductAppointmentSlotResponse>(bookingProductAppointmentSlot);

             return CustomResponseDto<DeletedBookingProductAppointmentSlotResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}