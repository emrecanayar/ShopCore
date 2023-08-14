using Application.Features.BookingProductDefaultSlots.Constants;
using Application.Features.BookingProductDefaultSlots.Constants;
using Application.Features.BookingProductDefaultSlots.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.BookingProductDefaultSlots.Constants.BookingProductDefaultSlotsOperationClaims;

namespace Application.Features.BookingProductDefaultSlots.Commands.Delete;

public class DeleteBookingProductDefaultSlotCommand : IRequest<CustomResponseDto<DeletedBookingProductDefaultSlotResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Write, BookingProductDefaultSlotsOperationClaims.Delete };

    public class DeleteBookingProductDefaultSlotCommandHandler : IRequestHandler<DeleteBookingProductDefaultSlotCommand, CustomResponseDto<DeletedBookingProductDefaultSlotResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBookingProductDefaultSlotRepository _bookingProductDefaultSlotRepository;
        private readonly BookingProductDefaultSlotBusinessRules _bookingProductDefaultSlotBusinessRules;

        public DeleteBookingProductDefaultSlotCommandHandler(IMapper mapper, IBookingProductDefaultSlotRepository bookingProductDefaultSlotRepository,
                                         BookingProductDefaultSlotBusinessRules bookingProductDefaultSlotBusinessRules)
        {
            _mapper = mapper;
            _bookingProductDefaultSlotRepository = bookingProductDefaultSlotRepository;
            _bookingProductDefaultSlotBusinessRules = bookingProductDefaultSlotBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedBookingProductDefaultSlotResponse>> Handle(DeleteBookingProductDefaultSlotCommand request, CancellationToken cancellationToken)
        {
            BookingProductDefaultSlot? bookingProductDefaultSlot = await _bookingProductDefaultSlotRepository.GetAsync(predicate: bpds => bpds.Id == request.Id, cancellationToken: cancellationToken);
            await _bookingProductDefaultSlotBusinessRules.BookingProductDefaultSlotShouldExistWhenSelected(bookingProductDefaultSlot);

            await _bookingProductDefaultSlotRepository.DeleteAsync(bookingProductDefaultSlot!);

            DeletedBookingProductDefaultSlotResponse response = _mapper.Map<DeletedBookingProductDefaultSlotResponse>(bookingProductDefaultSlot);

             return CustomResponseDto<DeletedBookingProductDefaultSlotResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}