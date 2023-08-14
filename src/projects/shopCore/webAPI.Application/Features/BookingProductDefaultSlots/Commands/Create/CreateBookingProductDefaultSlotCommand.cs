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

namespace Application.Features.BookingProductDefaultSlots.Commands.Create;

public class CreateBookingProductDefaultSlotCommand : IRequest<CustomResponseDto<CreatedBookingProductDefaultSlotResponse>>, ISecuredRequest
{
    public string BookingType { get; set; }
    public int? Duration { get; set; }
    public int? BreakTime { get; set; }
    public string? Slots { get; set; }
    public uint BookingProductId { get; set; }

    public string[] Roles => new[] { Admin, Write, BookingProductDefaultSlotsOperationClaims.Create };

    public class CreateBookingProductDefaultSlotCommandHandler : IRequestHandler<CreateBookingProductDefaultSlotCommand, CustomResponseDto<CreatedBookingProductDefaultSlotResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBookingProductDefaultSlotRepository _bookingProductDefaultSlotRepository;
        private readonly BookingProductDefaultSlotBusinessRules _bookingProductDefaultSlotBusinessRules;

        public CreateBookingProductDefaultSlotCommandHandler(IMapper mapper, IBookingProductDefaultSlotRepository bookingProductDefaultSlotRepository,
                                         BookingProductDefaultSlotBusinessRules bookingProductDefaultSlotBusinessRules)
        {
            _mapper = mapper;
            _bookingProductDefaultSlotRepository = bookingProductDefaultSlotRepository;
            _bookingProductDefaultSlotBusinessRules = bookingProductDefaultSlotBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedBookingProductDefaultSlotResponse>> Handle(CreateBookingProductDefaultSlotCommand request, CancellationToken cancellationToken)
        {
            BookingProductDefaultSlot bookingProductDefaultSlot = _mapper.Map<BookingProductDefaultSlot>(request);

            await _bookingProductDefaultSlotRepository.AddAsync(bookingProductDefaultSlot);

            CreatedBookingProductDefaultSlotResponse response = _mapper.Map<CreatedBookingProductDefaultSlotResponse>(bookingProductDefaultSlot);
         return CustomResponseDto<CreatedBookingProductDefaultSlotResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}