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

namespace Application.Features.BookingProductRentalSlots.Commands.Update;

public class UpdateBookingProductRentalSlotCommand : IRequest<CustomResponseDto<UpdatedBookingProductRentalSlotResponse>>, ISecuredRequest
{
    public uint Id { get; set; }
    public string RentingType { get; set; }
    public decimal? DailyPrice { get; set; }
    public decimal? HourlyPrice { get; set; }
    public bool? SameSlotAllDays { get; set; }
    public string? Slots { get; set; }
    public uint BookingProductId { get; set; }

    public string[] Roles => new[] { Admin, Write, BookingProductRentalSlotsOperationClaims.Update };

    public class UpdateBookingProductRentalSlotCommandHandler : IRequestHandler<UpdateBookingProductRentalSlotCommand, CustomResponseDto<UpdatedBookingProductRentalSlotResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBookingProductRentalSlotRepository _bookingProductRentalSlotRepository;
        private readonly BookingProductRentalSlotBusinessRules _bookingProductRentalSlotBusinessRules;

        public UpdateBookingProductRentalSlotCommandHandler(IMapper mapper, IBookingProductRentalSlotRepository bookingProductRentalSlotRepository,
                                         BookingProductRentalSlotBusinessRules bookingProductRentalSlotBusinessRules)
        {
            _mapper = mapper;
            _bookingProductRentalSlotRepository = bookingProductRentalSlotRepository;
            _bookingProductRentalSlotBusinessRules = bookingProductRentalSlotBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedBookingProductRentalSlotResponse>> Handle(UpdateBookingProductRentalSlotCommand request, CancellationToken cancellationToken)
        {
            BookingProductRentalSlot? bookingProductRentalSlot = await _bookingProductRentalSlotRepository.GetAsync(predicate: bprs => bprs.Id == request.Id, cancellationToken: cancellationToken);
            await _bookingProductRentalSlotBusinessRules.BookingProductRentalSlotShouldExistWhenSelected(bookingProductRentalSlot);
            bookingProductRentalSlot = _mapper.Map(request, bookingProductRentalSlot);

            await _bookingProductRentalSlotRepository.UpdateAsync(bookingProductRentalSlot!);

            UpdatedBookingProductRentalSlotResponse response = _mapper.Map<UpdatedBookingProductRentalSlotResponse>(bookingProductRentalSlot);

          return CustomResponseDto<UpdatedBookingProductRentalSlotResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}