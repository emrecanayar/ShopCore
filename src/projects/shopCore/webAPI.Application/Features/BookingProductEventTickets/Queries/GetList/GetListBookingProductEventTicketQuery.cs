using Application.Features.BookingProductEventTickets.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.BookingProductEventTickets.Constants.BookingProductEventTicketsOperationClaims;

namespace Application.Features.BookingProductEventTickets.Queries.GetList;

public class GetListBookingProductEventTicketQuery : IRequest<CustomResponseDto<GetListResponse<GetListBookingProductEventTicketListItemDto>>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListBookingProductEventTicketQueryHandler : IRequestHandler<GetListBookingProductEventTicketQuery, CustomResponseDto<GetListResponse<GetListBookingProductEventTicketListItemDto>>>
    {
        private readonly IBookingProductEventTicketRepository _bookingProductEventTicketRepository;
        private readonly IMapper _mapper;

        public GetListBookingProductEventTicketQueryHandler(IBookingProductEventTicketRepository bookingProductEventTicketRepository, IMapper mapper)
        {
            _bookingProductEventTicketRepository = bookingProductEventTicketRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListBookingProductEventTicketListItemDto>>> Handle(GetListBookingProductEventTicketQuery request, CancellationToken cancellationToken)
        {
            IPaginate<BookingProductEventTicket> bookingProductEventTickets = await _bookingProductEventTicketRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListBookingProductEventTicketListItemDto> response = _mapper.Map<GetListResponse<GetListBookingProductEventTicketListItemDto>>(bookingProductEventTickets);
             return CustomResponseDto<GetListResponse<GetListBookingProductEventTicketListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}