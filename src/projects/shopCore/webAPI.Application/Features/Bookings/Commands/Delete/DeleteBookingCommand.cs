using Application.Features.Bookings.Constants;
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

namespace Application.Features.Bookings.Commands.Delete;

public class DeleteBookingCommand : IRequest<CustomResponseDto<DeletedBookingResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Write, BookingsOperationClaims.Delete };

    public class DeleteBookingCommandHandler : IRequestHandler<DeleteBookingCommand, CustomResponseDto<DeletedBookingResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBookingRepository _bookingRepository;
        private readonly BookingBusinessRules _bookingBusinessRules;

        public DeleteBookingCommandHandler(IMapper mapper, IBookingRepository bookingRepository,
                                         BookingBusinessRules bookingBusinessRules)
        {
            _mapper = mapper;
            _bookingRepository = bookingRepository;
            _bookingBusinessRules = bookingBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedBookingResponse>> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
        {
            Booking? booking = await _bookingRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
            await _bookingBusinessRules.BookingShouldExistWhenSelected(booking);

            await _bookingRepository.DeleteAsync(booking!);

            DeletedBookingResponse response = _mapper.Map<DeletedBookingResponse>(booking);

             return CustomResponseDto<DeletedBookingResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}