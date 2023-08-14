using Application.Features.BookingProductEventTicketTranslations.Constants;
using Application.Features.BookingProductEventTicketTranslations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.BookingProductEventTicketTranslations.Constants.BookingProductEventTicketTranslationsOperationClaims;

namespace Application.Features.BookingProductEventTicketTranslations.Queries.GetById;

public class GetByIdBookingProductEventTicketTranslationQuery : IRequest<CustomResponseDto<GetByIdBookingProductEventTicketTranslationResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdBookingProductEventTicketTranslationQueryHandler : IRequestHandler<GetByIdBookingProductEventTicketTranslationQuery, CustomResponseDto<GetByIdBookingProductEventTicketTranslationResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBookingProductEventTicketTranslationRepository _bookingProductEventTicketTranslationRepository;
        private readonly BookingProductEventTicketTranslationBusinessRules _bookingProductEventTicketTranslationBusinessRules;

        public GetByIdBookingProductEventTicketTranslationQueryHandler(IMapper mapper, IBookingProductEventTicketTranslationRepository bookingProductEventTicketTranslationRepository, BookingProductEventTicketTranslationBusinessRules bookingProductEventTicketTranslationBusinessRules)
        {
            _mapper = mapper;
            _bookingProductEventTicketTranslationRepository = bookingProductEventTicketTranslationRepository;
            _bookingProductEventTicketTranslationBusinessRules = bookingProductEventTicketTranslationBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdBookingProductEventTicketTranslationResponse>> Handle(GetByIdBookingProductEventTicketTranslationQuery request, CancellationToken cancellationToken)
        {
            BookingProductEventTicketTranslation? bookingProductEventTicketTranslation = await _bookingProductEventTicketTranslationRepository.GetAsync(predicate: bpett => bpett.Id == request.Id, cancellationToken: cancellationToken);
            await _bookingProductEventTicketTranslationBusinessRules.BookingProductEventTicketTranslationShouldExistWhenSelected(bookingProductEventTicketTranslation);

            GetByIdBookingProductEventTicketTranslationResponse response = _mapper.Map<GetByIdBookingProductEventTicketTranslationResponse>(bookingProductEventTicketTranslation);

          return CustomResponseDto<GetByIdBookingProductEventTicketTranslationResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}