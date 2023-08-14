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

namespace Application.Features.BookingProductDefaultSlots.Commands.Update;

public class UpdateBookingProductDefaultSlotCommand : IRequest<CustomResponseDto<UpdatedBookingProductDefaultSlotResponse>>, ISecuredRequest
{
    public uint Id { get; set; }
    public string BookingType { get; set; }
    public int? Duration { get; set; }
    public int? BreakTime { get; set; }
    public string? Slots { get; set; }
    public uint BookingProductId { get; set; }

    public string[] Roles => new[] { Admin, Write, BookingProductDefaultSlotsOperationClaims.Update };

    public class UpdateBookingProductDefaultSlotCommandHandler : IRequestHandler<UpdateBookingProductDefaultSlotCommand, CustomResponseDto<UpdatedBookingProductDefaultSlotResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBookingProductDefaultSlotRepository _bookingProductDefaultSlotRepository;
        private readonly BookingProductDefaultSlotBusinessRules _bookingProductDefaultSlotBusinessRules;

        public UpdateBookingProductDefaultSlotCommandHandler(IMapper mapper, IBookingProductDefaultSlotRepository bookingProductDefaultSlotRepository,
                                         BookingProductDefaultSlotBusinessRules bookingProductDefaultSlotBusinessRules)
        {
            _mapper = mapper;
            _bookingProductDefaultSlotRepository = bookingProductDefaultSlotRepository;
            _bookingProductDefaultSlotBusinessRules = bookingProductDefaultSlotBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedBookingProductDefaultSlotResponse>> Handle(UpdateBookingProductDefaultSlotCommand request, CancellationToken cancellationToken)
        {
            BookingProductDefaultSlot? bookingProductDefaultSlot = await _bookingProductDefaultSlotRepository.GetAsync(predicate: bpds => bpds.Id == request.Id, cancellationToken: cancellationToken);
            await _bookingProductDefaultSlotBusinessRules.BookingProductDefaultSlotShouldExistWhenSelected(bookingProductDefaultSlot);
            bookingProductDefaultSlot = _mapper.Map(request, bookingProductDefaultSlot);

            await _bookingProductDefaultSlotRepository.UpdateAsync(bookingProductDefaultSlot!);

            UpdatedBookingProductDefaultSlotResponse response = _mapper.Map<UpdatedBookingProductDefaultSlotResponse>(bookingProductDefaultSlot);

          return CustomResponseDto<UpdatedBookingProductDefaultSlotResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}