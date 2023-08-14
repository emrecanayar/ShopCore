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

namespace Application.Features.BookingProductTableSlots.Commands.Update;

public class UpdateBookingProductTableSlotCommand : IRequest<CustomResponseDto<UpdatedBookingProductTableSlotResponse>>, ISecuredRequest
{
    public uint Id { get; set; }
    public string PriceType { get; set; }
    public int GuestLimit { get; set; }
    public int Duration { get; set; }
    public int BreakTime { get; set; }
    public int PreventSchedulingBefore { get; set; }
    public bool? SameSlotAllDays { get; set; }
    public string? Slots { get; set; }
    public uint BookingProductId { get; set; }

    public string[] Roles => new[] { Admin, Write, BookingProductTableSlotsOperationClaims.Update };

    public class UpdateBookingProductTableSlotCommandHandler : IRequestHandler<UpdateBookingProductTableSlotCommand, CustomResponseDto<UpdatedBookingProductTableSlotResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBookingProductTableSlotRepository _bookingProductTableSlotRepository;
        private readonly BookingProductTableSlotBusinessRules _bookingProductTableSlotBusinessRules;

        public UpdateBookingProductTableSlotCommandHandler(IMapper mapper, IBookingProductTableSlotRepository bookingProductTableSlotRepository,
                                         BookingProductTableSlotBusinessRules bookingProductTableSlotBusinessRules)
        {
            _mapper = mapper;
            _bookingProductTableSlotRepository = bookingProductTableSlotRepository;
            _bookingProductTableSlotBusinessRules = bookingProductTableSlotBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedBookingProductTableSlotResponse>> Handle(UpdateBookingProductTableSlotCommand request, CancellationToken cancellationToken)
        {
            BookingProductTableSlot? bookingProductTableSlot = await _bookingProductTableSlotRepository.GetAsync(predicate: bpts => bpts.Id == request.Id, cancellationToken: cancellationToken);
            await _bookingProductTableSlotBusinessRules.BookingProductTableSlotShouldExistWhenSelected(bookingProductTableSlot);
            bookingProductTableSlot = _mapper.Map(request, bookingProductTableSlot);

            await _bookingProductTableSlotRepository.UpdateAsync(bookingProductTableSlot!);

            UpdatedBookingProductTableSlotResponse response = _mapper.Map<UpdatedBookingProductTableSlotResponse>(bookingProductTableSlot);

          return CustomResponseDto<UpdatedBookingProductTableSlotResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}