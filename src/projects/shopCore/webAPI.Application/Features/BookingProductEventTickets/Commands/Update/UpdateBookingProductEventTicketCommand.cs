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

namespace Application.Features.BookingProductEventTickets.Commands.Update;

public class UpdateBookingProductEventTicketCommand : IRequest<CustomResponseDto<UpdatedBookingProductEventTicketResponse>>, ISecuredRequest
{
    public uint Id { get; set; }
    public decimal? Price { get; set; }
    public int? Qty { get; set; }
    public decimal? SpecialPrice { get; set; }
    public DateTime? SpecialPriceFrom { get; set; }
    public DateTime? SpecialPriceTo { get; set; }
    public uint BookingProductId { get; set; }

    public string[] Roles => new[] { Admin, Write, BookingProductEventTicketsOperationClaims.Update };

    public class UpdateBookingProductEventTicketCommandHandler : IRequestHandler<UpdateBookingProductEventTicketCommand, CustomResponseDto<UpdatedBookingProductEventTicketResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBookingProductEventTicketRepository _bookingProductEventTicketRepository;
        private readonly BookingProductEventTicketBusinessRules _bookingProductEventTicketBusinessRules;

        public UpdateBookingProductEventTicketCommandHandler(IMapper mapper, IBookingProductEventTicketRepository bookingProductEventTicketRepository,
                                         BookingProductEventTicketBusinessRules bookingProductEventTicketBusinessRules)
        {
            _mapper = mapper;
            _bookingProductEventTicketRepository = bookingProductEventTicketRepository;
            _bookingProductEventTicketBusinessRules = bookingProductEventTicketBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedBookingProductEventTicketResponse>> Handle(UpdateBookingProductEventTicketCommand request, CancellationToken cancellationToken)
        {
            BookingProductEventTicket? bookingProductEventTicket = await _bookingProductEventTicketRepository.GetAsync(predicate: bpet => bpet.Id == request.Id, cancellationToken: cancellationToken);
            await _bookingProductEventTicketBusinessRules.BookingProductEventTicketShouldExistWhenSelected(bookingProductEventTicket);
            bookingProductEventTicket = _mapper.Map(request, bookingProductEventTicket);

            await _bookingProductEventTicketRepository.UpdateAsync(bookingProductEventTicket!);

            UpdatedBookingProductEventTicketResponse response = _mapper.Map<UpdatedBookingProductEventTicketResponse>(bookingProductEventTicket);

          return CustomResponseDto<UpdatedBookingProductEventTicketResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}