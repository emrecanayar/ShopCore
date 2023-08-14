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

namespace Application.Features.BookingProductEventTickets.Commands.Create;

public class CreateBookingProductEventTicketCommand : IRequest<CustomResponseDto<CreatedBookingProductEventTicketResponse>>, ISecuredRequest
{
    public decimal? Price { get; set; }
    public int? Qty { get; set; }
    public decimal? SpecialPrice { get; set; }
    public DateTime? SpecialPriceFrom { get; set; }
    public DateTime? SpecialPriceTo { get; set; }
    public uint BookingProductId { get; set; }

    public string[] Roles => new[] { Admin, Write, BookingProductEventTicketsOperationClaims.Create };

    public class CreateBookingProductEventTicketCommandHandler : IRequestHandler<CreateBookingProductEventTicketCommand, CustomResponseDto<CreatedBookingProductEventTicketResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBookingProductEventTicketRepository _bookingProductEventTicketRepository;
        private readonly BookingProductEventTicketBusinessRules _bookingProductEventTicketBusinessRules;

        public CreateBookingProductEventTicketCommandHandler(IMapper mapper, IBookingProductEventTicketRepository bookingProductEventTicketRepository,
                                         BookingProductEventTicketBusinessRules bookingProductEventTicketBusinessRules)
        {
            _mapper = mapper;
            _bookingProductEventTicketRepository = bookingProductEventTicketRepository;
            _bookingProductEventTicketBusinessRules = bookingProductEventTicketBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedBookingProductEventTicketResponse>> Handle(CreateBookingProductEventTicketCommand request, CancellationToken cancellationToken)
        {
            BookingProductEventTicket bookingProductEventTicket = _mapper.Map<BookingProductEventTicket>(request);

            await _bookingProductEventTicketRepository.AddAsync(bookingProductEventTicket);

            CreatedBookingProductEventTicketResponse response = _mapper.Map<CreatedBookingProductEventTicketResponse>(bookingProductEventTicket);
         return CustomResponseDto<CreatedBookingProductEventTicketResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}