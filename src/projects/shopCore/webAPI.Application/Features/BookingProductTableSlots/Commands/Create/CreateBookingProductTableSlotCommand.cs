using Application.Features.BookingProductTableSlots.Constants;
using Application.Features.BookingProductTableSlots.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.BookingProductTableSlots.Constants.BookingProductTableSlotsOperationClaims;

namespace Application.Features.BookingProductTableSlots.Commands.Create;

public class CreateBookingProductTableSlotCommand : IRequest<CustomResponseDto<CreatedBookingProductTableSlotResponse>>, ISecuredRequest
{
    public string PriceType { get; set; }
    public int GuestLimit { get; set; }
    public int Duration { get; set; }
    public int BreakTime { get; set; }
    public int PreventSchedulingBefore { get; set; }
    public bool? SameSlotAllDays { get; set; }
    public string? Slots { get; set; }
    public uint BookingProductId { get; set; }

    public string[] Roles => new[] { Admin, Write, BookingProductTableSlotsOperationClaims.Create };

    public class CreateBookingProductTableSlotCommandHandler : IRequestHandler<CreateBookingProductTableSlotCommand, CustomResponseDto<CreatedBookingProductTableSlotResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBookingProductTableSlotRepository _bookingProductTableSlotRepository;
        private readonly BookingProductTableSlotBusinessRules _bookingProductTableSlotBusinessRules;

        public CreateBookingProductTableSlotCommandHandler(IMapper mapper, IBookingProductTableSlotRepository bookingProductTableSlotRepository,
                                         BookingProductTableSlotBusinessRules bookingProductTableSlotBusinessRules)
        {
            _mapper = mapper;
            _bookingProductTableSlotRepository = bookingProductTableSlotRepository;
            _bookingProductTableSlotBusinessRules = bookingProductTableSlotBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedBookingProductTableSlotResponse>> Handle(CreateBookingProductTableSlotCommand request, CancellationToken cancellationToken)
        {
            BookingProductTableSlot bookingProductTableSlot = _mapper.Map<BookingProductTableSlot>(request);

            await _bookingProductTableSlotRepository.AddAsync(bookingProductTableSlot);

            CreatedBookingProductTableSlotResponse response = _mapper.Map<CreatedBookingProductTableSlotResponse>(bookingProductTableSlot);
         return CustomResponseDto<CreatedBookingProductTableSlotResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}