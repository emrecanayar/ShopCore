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

namespace Application.Features.BookingProductEventTicketTranslations.Commands.Create;

public class CreateBookingProductEventTicketTranslationCommand : IRequest<CustomResponseDto<CreatedBookingProductEventTicketTranslationResponse>>, ISecuredRequest
{
    public string Locale { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    public string[] Roles => new[] { Admin, Write, BookingProductEventTicketTranslationsOperationClaims.Create };

    public class CreateBookingProductEventTicketTranslationCommandHandler : IRequestHandler<CreateBookingProductEventTicketTranslationCommand, CustomResponseDto<CreatedBookingProductEventTicketTranslationResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBookingProductEventTicketTranslationRepository _bookingProductEventTicketTranslationRepository;
        private readonly BookingProductEventTicketTranslationBusinessRules _bookingProductEventTicketTranslationBusinessRules;

        public CreateBookingProductEventTicketTranslationCommandHandler(IMapper mapper, IBookingProductEventTicketTranslationRepository bookingProductEventTicketTranslationRepository,
                                         BookingProductEventTicketTranslationBusinessRules bookingProductEventTicketTranslationBusinessRules)
        {
            _mapper = mapper;
            _bookingProductEventTicketTranslationRepository = bookingProductEventTicketTranslationRepository;
            _bookingProductEventTicketTranslationBusinessRules = bookingProductEventTicketTranslationBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedBookingProductEventTicketTranslationResponse>> Handle(CreateBookingProductEventTicketTranslationCommand request, CancellationToken cancellationToken)
        {
            BookingProductEventTicketTranslation bookingProductEventTicketTranslation = _mapper.Map<BookingProductEventTicketTranslation>(request);

            await _bookingProductEventTicketTranslationRepository.AddAsync(bookingProductEventTicketTranslation);

            CreatedBookingProductEventTicketTranslationResponse response = _mapper.Map<CreatedBookingProductEventTicketTranslationResponse>(bookingProductEventTicketTranslation);
         return CustomResponseDto<CreatedBookingProductEventTicketTranslationResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}