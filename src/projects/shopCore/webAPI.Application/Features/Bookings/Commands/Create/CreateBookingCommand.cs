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

namespace Application.Features.Bookings.Commands.Create;

public class CreateBookingCommand : IRequest<CustomResponseDto<CreatedBookingResponse>>, ISecuredRequest
{
    public int? Qty { get; set; }
    public int? From { get; set; }
    public int? To { get; set; }
    public uint? OrderItemId { get; set; }
    public uint? BookingProductEventTicketId { get; set; }
    public uint? OrderId { get; set; }
    public uint? ProductId { get; set; }

    public string[] Roles => new[] { Admin, Write, BookingsOperationClaims.Create };

    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, CustomResponseDto<CreatedBookingResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBookingRepository _bookingRepository;
        private readonly BookingBusinessRules _bookingBusinessRules;

        public CreateBookingCommandHandler(IMapper mapper, IBookingRepository bookingRepository,
                                         BookingBusinessRules bookingBusinessRules)
        {
            _mapper = mapper;
            _bookingRepository = bookingRepository;
            _bookingBusinessRules = bookingBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedBookingResponse>> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            Booking booking = _mapper.Map<Booking>(request);

            await _bookingRepository.AddAsync(booking);

            CreatedBookingResponse response = _mapper.Map<CreatedBookingResponse>(booking);
         return CustomResponseDto<CreatedBookingResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}