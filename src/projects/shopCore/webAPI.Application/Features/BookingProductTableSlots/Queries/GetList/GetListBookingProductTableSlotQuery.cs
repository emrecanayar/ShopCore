using Application.Features.BookingProductTableSlots.Constants;
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
using static Application.Features.BookingProductTableSlots.Constants.BookingProductTableSlotsOperationClaims;

namespace Application.Features.BookingProductTableSlots.Queries.GetList;

public class GetListBookingProductTableSlotQuery : IRequest<CustomResponseDto<GetListResponse<GetListBookingProductTableSlotListItemDto>>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListBookingProductTableSlotQueryHandler : IRequestHandler<GetListBookingProductTableSlotQuery, CustomResponseDto<GetListResponse<GetListBookingProductTableSlotListItemDto>>>
    {
        private readonly IBookingProductTableSlotRepository _bookingProductTableSlotRepository;
        private readonly IMapper _mapper;

        public GetListBookingProductTableSlotQueryHandler(IBookingProductTableSlotRepository bookingProductTableSlotRepository, IMapper mapper)
        {
            _bookingProductTableSlotRepository = bookingProductTableSlotRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListBookingProductTableSlotListItemDto>>> Handle(GetListBookingProductTableSlotQuery request, CancellationToken cancellationToken)
        {
            IPaginate<BookingProductTableSlot> bookingProductTableSlots = await _bookingProductTableSlotRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListBookingProductTableSlotListItemDto> response = _mapper.Map<GetListResponse<GetListBookingProductTableSlotListItemDto>>(bookingProductTableSlots);
             return CustomResponseDto<GetListResponse<GetListBookingProductTableSlotListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}