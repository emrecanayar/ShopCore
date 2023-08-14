using Application.Features.Bookings.Constants;
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
using static Application.Features.Bookings.Constants.BookingsOperationClaims;

namespace Application.Features.Bookings.Queries.GetList;

public class GetListBookingQuery : IRequest<CustomResponseDto<GetListResponse<GetListBookingListItemDto>>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListBookingQueryHandler : IRequestHandler<GetListBookingQuery, CustomResponseDto<GetListResponse<GetListBookingListItemDto>>>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;

        public GetListBookingQueryHandler(IBookingRepository bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListBookingListItemDto>>> Handle(GetListBookingQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Booking> bookings = await _bookingRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListBookingListItemDto> response = _mapper.Map<GetListResponse<GetListBookingListItemDto>>(bookings);
             return CustomResponseDto<GetListResponse<GetListBookingListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}