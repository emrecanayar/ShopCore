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

namespace Application.Features.BookingProductEventTicketTranslations.Commands.Update;

public class UpdateBookingProductEventTicketTranslationCommand : IRequest<CustomResponseDto<UpdatedBookingProductEventTicketTranslationResponse>>, ISecuredRequest
{
    public uint Id { get; set; }
    public string Locale { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    public string[] Roles => new[] { Admin, Write, BookingProductEventTicketTranslationsOperationClaims.Update };

    public class UpdateBookingProductEventTicketTranslationCommandHandler : IRequestHandler<UpdateBookingProductEventTicketTranslationCommand, CustomResponseDto<UpdatedBookingProductEventTicketTranslationResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBookingProductEventTicketTranslationRepository _bookingProductEventTicketTranslationRepository;
        private readonly BookingProductEventTicketTranslationBusinessRules _bookingProductEventTicketTranslationBusinessRules;

        public UpdateBookingProductEventTicketTranslationCommandHandler(IMapper mapper, IBookingProductEventTicketTranslationRepository bookingProductEventTicketTranslationRepository,
                                         BookingProductEventTicketTranslationBusinessRules bookingProductEventTicketTranslationBusinessRules)
        {
            _mapper = mapper;
            _bookingProductEventTicketTranslationRepository = bookingProductEventTicketTranslationRepository;
            _bookingProductEventTicketTranslationBusinessRules = bookingProductEventTicketTranslationBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedBookingProductEventTicketTranslationResponse>> Handle(UpdateBookingProductEventTicketTranslationCommand request, CancellationToken cancellationToken)
        {
            BookingProductEventTicketTranslation? bookingProductEventTicketTranslation = await _bookingProductEventTicketTranslationRepository.GetAsync(predicate: bpett => bpett.Id == request.Id, cancellationToken: cancellationToken);
            await _bookingProductEventTicketTranslationBusinessRules.BookingProductEventTicketTranslationShouldExistWhenSelected(bookingProductEventTicketTranslation);
            bookingProductEventTicketTranslation = _mapper.Map(request, bookingProductEventTicketTranslation);

            await _bookingProductEventTicketTranslationRepository.UpdateAsync(bookingProductEventTicketTranslation!);

            UpdatedBookingProductEventTicketTranslationResponse response = _mapper.Map<UpdatedBookingProductEventTicketTranslationResponse>(bookingProductEventTicketTranslation);

          return CustomResponseDto<UpdatedBookingProductEventTicketTranslationResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}