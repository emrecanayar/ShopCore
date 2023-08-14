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

namespace Application.Features.Bookings.Queries.GetById;

public class GetByIdBookingQuery : IRequest<CustomResponseDto<GetByIdBookingResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdBookingQueryHandler : IRequestHandler<GetByIdBookingQuery, CustomResponseDto<GetByIdBookingResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBookingRepository _bookingRepository;
        private readonly BookingBusinessRules _bookingBusinessRules;

        public GetByIdBookingQueryHandler(IMapper mapper, IBookingRepository bookingRepository, BookingBusinessRules bookingBusinessRules)
        {
            _mapper = mapper;
            _bookingRepository = bookingRepository;
            _bookingBusinessRules = bookingBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdBookingResponse>> Handle(GetByIdBookingQuery request, CancellationToken cancellationToken)
        {
            Booking? booking = await _bookingRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
            await _bookingBusinessRules.BookingShouldExistWhenSelected(booking);

            GetByIdBookingResponse response = _mapper.Map<GetByIdBookingResponse>(booking);

          return CustomResponseDto<GetByIdBookingResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}