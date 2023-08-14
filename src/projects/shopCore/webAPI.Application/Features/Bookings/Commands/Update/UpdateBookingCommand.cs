using Application.Features.Bookings.Constants;
using Application.Features.Bookings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Bookings.Constants.BookingsOperationClaims;

namespace Application.Features.Bookings.Commands.Update;

public class UpdateBookingCommand : IRequest<CustomResponseDto<UpdatedBookingResponse>>, ISecuredRequest
{
    public uint Id { get; set; }
    public int? Qty { get; set; }
    public int? From { get; set; }
    public int? To { get; set; }
    public uint? OrderItemId { get; set; }
    public uint? BookingProductEventTicketId { get; set; }
    public uint? OrderId { get; set; }
    public uint? ProductId { get; set; }

    public string[] Roles => new[] { Admin, Write, BookingsOperationClaims.Update };

    public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand, CustomResponseDto<UpdatedBookingResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBookingRepository _bookingRepository;
        private readonly BookingBusinessRules _bookingBusinessRules;

        public UpdateBookingCommandHandler(IMapper mapper, IBookingRepository bookingRepository,
                                         BookingBusinessRules bookingBusinessRules)
        {
            _mapper = mapper;
            _bookingRepository = bookingRepository;
            _bookingBusinessRules = bookingBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedBookingResponse>> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {
            Booking? booking = await _bookingRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
            await _bookingBusinessRules.BookingShouldExistWhenSelected(booking);
            booking = _mapper.Map(request, booking);

            await _bookingRepository.UpdateAsync(booking!);

            UpdatedBookingResponse response = _mapper.Map<UpdatedBookingResponse>(booking);

          return CustomResponseDto<UpdatedBookingResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}