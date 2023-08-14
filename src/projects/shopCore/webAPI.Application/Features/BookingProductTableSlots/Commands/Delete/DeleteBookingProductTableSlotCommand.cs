using Application.Features.BookingProductTableSlots.Constants;
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

namespace Application.Features.BookingProductTableSlots.Commands.Delete;

public class DeleteBookingProductTableSlotCommand : IRequest<CustomResponseDto<DeletedBookingProductTableSlotResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Write, BookingProductTableSlotsOperationClaims.Delete };

    public class DeleteBookingProductTableSlotCommandHandler : IRequestHandler<DeleteBookingProductTableSlotCommand, CustomResponseDto<DeletedBookingProductTableSlotResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBookingProductTableSlotRepository _bookingProductTableSlotRepository;
        private readonly BookingProductTableSlotBusinessRules _bookingProductTableSlotBusinessRules;

        public DeleteBookingProductTableSlotCommandHandler(IMapper mapper, IBookingProductTableSlotRepository bookingProductTableSlotRepository,
                                         BookingProductTableSlotBusinessRules bookingProductTableSlotBusinessRules)
        {
            _mapper = mapper;
            _bookingProductTableSlotRepository = bookingProductTableSlotRepository;
            _bookingProductTableSlotBusinessRules = bookingProductTableSlotBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedBookingProductTableSlotResponse>> Handle(DeleteBookingProductTableSlotCommand request, CancellationToken cancellationToken)
        {
            BookingProductTableSlot? bookingProductTableSlot = await _bookingProductTableSlotRepository.GetAsync(predicate: bpts => bpts.Id == request.Id, cancellationToken: cancellationToken);
            await _bookingProductTableSlotBusinessRules.BookingProductTableSlotShouldExistWhenSelected(bookingProductTableSlot);

            await _bookingProductTableSlotRepository.DeleteAsync(bookingProductTableSlot!);

            DeletedBookingProductTableSlotResponse response = _mapper.Map<DeletedBookingProductTableSlotResponse>(bookingProductTableSlot);

             return CustomResponseDto<DeletedBookingProductTableSlotResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}