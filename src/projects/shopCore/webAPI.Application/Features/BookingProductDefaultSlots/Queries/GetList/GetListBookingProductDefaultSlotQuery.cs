using Application.Features.BookingProductDefaultSlots.Constants;
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
using static Application.Features.BookingProductDefaultSlots.Constants.BookingProductDefaultSlotsOperationClaims;

namespace Application.Features.BookingProductDefaultSlots.Queries.GetList;

public class GetListBookingProductDefaultSlotQuery : IRequest<CustomResponseDto<GetListResponse<GetListBookingProductDefaultSlotListItemDto>>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListBookingProductDefaultSlotQueryHandler : IRequestHandler<GetListBookingProductDefaultSlotQuery, CustomResponseDto<GetListResponse<GetListBookingProductDefaultSlotListItemDto>>>
    {
        private readonly IBookingProductDefaultSlotRepository _bookingProductDefaultSlotRepository;
        private readonly IMapper _mapper;

        public GetListBookingProductDefaultSlotQueryHandler(IBookingProductDefaultSlotRepository bookingProductDefaultSlotRepository, IMapper mapper)
        {
            _bookingProductDefaultSlotRepository = bookingProductDefaultSlotRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListBookingProductDefaultSlotListItemDto>>> Handle(GetListBookingProductDefaultSlotQuery request, CancellationToken cancellationToken)
        {
            IPaginate<BookingProductDefaultSlot> bookingProductDefaultSlots = await _bookingProductDefaultSlotRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListBookingProductDefaultSlotListItemDto> response = _mapper.Map<GetListResponse<GetListBookingProductDefaultSlotListItemDto>>(bookingProductDefaultSlots);
             return CustomResponseDto<GetListResponse<GetListBookingProductDefaultSlotListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}