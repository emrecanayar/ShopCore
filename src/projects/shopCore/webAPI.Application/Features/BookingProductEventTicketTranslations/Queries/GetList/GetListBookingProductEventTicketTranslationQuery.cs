using Application.Features.BookingProductEventTicketTranslations.Constants;
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
using static Application.Features.BookingProductEventTicketTranslations.Constants.BookingProductEventTicketTranslationsOperationClaims;

namespace Application.Features.BookingProductEventTicketTranslations.Queries.GetList;

public class GetListBookingProductEventTicketTranslationQuery : IRequest<CustomResponseDto<GetListResponse<GetListBookingProductEventTicketTranslationListItemDto>>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListBookingProductEventTicketTranslationQueryHandler : IRequestHandler<GetListBookingProductEventTicketTranslationQuery, CustomResponseDto<GetListResponse<GetListBookingProductEventTicketTranslationListItemDto>>>
    {
        private readonly IBookingProductEventTicketTranslationRepository _bookingProductEventTicketTranslationRepository;
        private readonly IMapper _mapper;

        public GetListBookingProductEventTicketTranslationQueryHandler(IBookingProductEventTicketTranslationRepository bookingProductEventTicketTranslationRepository, IMapper mapper)
        {
            _bookingProductEventTicketTranslationRepository = bookingProductEventTicketTranslationRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListBookingProductEventTicketTranslationListItemDto>>> Handle(GetListBookingProductEventTicketTranslationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<BookingProductEventTicketTranslation> bookingProductEventTicketTranslations = await _bookingProductEventTicketTranslationRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListBookingProductEventTicketTranslationListItemDto> response = _mapper.Map<GetListResponse<GetListBookingProductEventTicketTranslationListItemDto>>(bookingProductEventTicketTranslations);
             return CustomResponseDto<GetListResponse<GetListBookingProductEventTicketTranslationListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}