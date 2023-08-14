using Application.Features.BookingProductEventTickets.Constants;
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

namespace Application.Features.BookingProductEventTickets.Commands.Delete;

public class DeleteBookingProductEventTicketCommand : IRequest<CustomResponseDto<DeletedBookingProductEventTicketResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Write, BookingProductEventTicketsOperationClaims.Delete };

    public class DeleteBookingProductEventTicketCommandHandler : IRequestHandler<DeleteBookingProductEventTicketCommand, CustomResponseDto<DeletedBookingProductEventTicketResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBookingProductEventTicketRepository _bookingProductEventTicketRepository;
        private readonly BookingProductEventTicketBusinessRules _bookingProductEventTicketBusinessRules;

        public DeleteBookingProductEventTicketCommandHandler(IMapper mapper, IBookingProductEventTicketRepository bookingProductEventTicketRepository,
                                         BookingProductEventTicketBusinessRules bookingProductEventTicketBusinessRules)
        {
            _mapper = mapper;
            _bookingProductEventTicketRepository = bookingProductEventTicketRepository;
            _bookingProductEventTicketBusinessRules = bookingProductEventTicketBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedBookingProductEventTicketResponse>> Handle(DeleteBookingProductEventTicketCommand request, CancellationToken cancellationToken)
        {
            BookingProductEventTicket? bookingProductEventTicket = await _bookingProductEventTicketRepository.GetAsync(predicate: bpet => bpet.Id == request.Id, cancellationToken: cancellationToken);
            await _bookingProductEventTicketBusinessRules.BookingProductEventTicketShouldExistWhenSelected(bookingProductEventTicket);

            await _bookingProductEventTicketRepository.DeleteAsync(bookingProductEventTicket!);

            DeletedBookingProductEventTicketResponse response = _mapper.Map<DeletedBookingProductEventTicketResponse>(bookingProductEventTicket);

             return CustomResponseDto<DeletedBookingProductEventTicketResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}