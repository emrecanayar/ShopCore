using Application.Features.BookingProductEventTickets.Constants;
using Application.Features.BookingProductEventTickets.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.BookingProductEventTickets.Constants.BookingProductEventTicketsOperationClaims;

namespace Application.Features.BookingProductEventTickets.Queries.GetById;

public class GetByIdBookingProductEventTicketQuery : IRequest<CustomResponseDto<GetByIdBookingProductEventTicketResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdBookingProductEventTicketQueryHandler : IRequestHandler<GetByIdBookingProductEventTicketQuery, CustomResponseDto<GetByIdBookingProductEventTicketResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBookingProductEventTicketRepository _bookingProductEventTicketRepository;
        private readonly BookingProductEventTicketBusinessRules _bookingProductEventTicketBusinessRules;

        public GetByIdBookingProductEventTicketQueryHandler(IMapper mapper, IBookingProductEventTicketRepository bookingProductEventTicketRepository, BookingProductEventTicketBusinessRules bookingProductEventTicketBusinessRules)
        {
            _mapper = mapper;
            _bookingProductEventTicketRepository = bookingProductEventTicketRepository;
            _bookingProductEventTicketBusinessRules = bookingProductEventTicketBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdBookingProductEventTicketResponse>> Handle(GetByIdBookingProductEventTicketQuery request, CancellationToken cancellationToken)
        {
            BookingProductEventTicket? bookingProductEventTicket = await _bookingProductEventTicketRepository.GetAsync(predicate: bpet => bpet.Id == request.Id, cancellationToken: cancellationToken);
            await _bookingProductEventTicketBusinessRules.BookingProductEventTicketShouldExistWhenSelected(bookingProductEventTicket);

            GetByIdBookingProductEventTicketResponse response = _mapper.Map<GetByIdBookingProductEventTicketResponse>(bookingProductEventTicket);

          return CustomResponseDto<GetByIdBookingProductEventTicketResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}