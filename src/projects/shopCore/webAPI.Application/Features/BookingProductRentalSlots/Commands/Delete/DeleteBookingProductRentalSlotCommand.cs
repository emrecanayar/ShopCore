using Application.Features.BookingProductRentalSlots.Constants;
using Application.Features.BookingProductRentalSlots.Constants;
using Application.Features.BookingProductRentalSlots.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.BookingProductRentalSlots.Constants.BookingProductRentalSlotsOperationClaims;

namespace Application.Features.BookingProductRentalSlots.Commands.Delete;

public class DeleteBookingProductRentalSlotCommand : IRequest<CustomResponseDto<DeletedBookingProductRentalSlotResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Write, BookingProductRentalSlotsOperationClaims.Delete };

    public class DeleteBookingProductRentalSlotCommandHandler : IRequestHandler<DeleteBookingProductRentalSlotCommand, CustomResponseDto<DeletedBookingProductRentalSlotResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBookingProductRentalSlotRepository _bookingProductRentalSlotRepository;
        private readonly BookingProductRentalSlotBusinessRules _bookingProductRentalSlotBusinessRules;

        public DeleteBookingProductRentalSlotCommandHandler(IMapper mapper, IBookingProductRentalSlotRepository bookingProductRentalSlotRepository,
                                         BookingProductRentalSlotBusinessRules bookingProductRentalSlotBusinessRules)
        {
            _mapper = mapper;
            _bookingProductRentalSlotRepository = bookingProductRentalSlotRepository;
            _bookingProductRentalSlotBusinessRules = bookingProductRentalSlotBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedBookingProductRentalSlotResponse>> Handle(DeleteBookingProductRentalSlotCommand request, CancellationToken cancellationToken)
        {
            BookingProductRentalSlot? bookingProductRentalSlot = await _bookingProductRentalSlotRepository.GetAsync(predicate: bprs => bprs.Id == request.Id, cancellationToken: cancellationToken);
            await _bookingProductRentalSlotBusinessRules.BookingProductRentalSlotShouldExistWhenSelected(bookingProductRentalSlot);

            await _bookingProductRentalSlotRepository.DeleteAsync(bookingProductRentalSlot!);

            DeletedBookingProductRentalSlotResponse response = _mapper.Map<DeletedBookingProductRentalSlotResponse>(bookingProductRentalSlot);

             return CustomResponseDto<DeletedBookingProductRentalSlotResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}