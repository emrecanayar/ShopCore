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

namespace Application.Features.BookingProductRentalSlots.Commands.Create;

public class CreateBookingProductRentalSlotCommand : IRequest<CustomResponseDto<CreatedBookingProductRentalSlotResponse>>, ISecuredRequest
{
    public string RentingType { get; set; }
    public decimal? DailyPrice { get; set; }
    public decimal? HourlyPrice { get; set; }
    public bool? SameSlotAllDays { get; set; }
    public string? Slots { get; set; }
    public uint BookingProductId { get; set; }

    public string[] Roles => new[] { Admin, Write, BookingProductRentalSlotsOperationClaims.Create };

    public class CreateBookingProductRentalSlotCommandHandler : IRequestHandler<CreateBookingProductRentalSlotCommand, CustomResponseDto<CreatedBookingProductRentalSlotResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBookingProductRentalSlotRepository _bookingProductRentalSlotRepository;
        private readonly BookingProductRentalSlotBusinessRules _bookingProductRentalSlotBusinessRules;

        public CreateBookingProductRentalSlotCommandHandler(IMapper mapper, IBookingProductRentalSlotRepository bookingProductRentalSlotRepository,
                                         BookingProductRentalSlotBusinessRules bookingProductRentalSlotBusinessRules)
        {
            _mapper = mapper;
            _bookingProductRentalSlotRepository = bookingProductRentalSlotRepository;
            _bookingProductRentalSlotBusinessRules = bookingProductRentalSlotBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedBookingProductRentalSlotResponse>> Handle(CreateBookingProductRentalSlotCommand request, CancellationToken cancellationToken)
        {
            BookingProductRentalSlot bookingProductRentalSlot = _mapper.Map<BookingProductRentalSlot>(request);

            await _bookingProductRentalSlotRepository.AddAsync(bookingProductRentalSlot);

            CreatedBookingProductRentalSlotResponse response = _mapper.Map<CreatedBookingProductRentalSlotResponse>(bookingProductRentalSlot);
         return CustomResponseDto<CreatedBookingProductRentalSlotResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}