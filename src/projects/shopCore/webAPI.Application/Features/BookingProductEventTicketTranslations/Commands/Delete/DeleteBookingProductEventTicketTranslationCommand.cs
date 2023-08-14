using Application.Features.BookingProductEventTicketTranslations.Constants;
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

namespace Application.Features.BookingProductEventTicketTranslations.Commands.Delete;

public class DeleteBookingProductEventTicketTranslationCommand : IRequest<CustomResponseDto<DeletedBookingProductEventTicketTranslationResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Write, BookingProductEventTicketTranslationsOperationClaims.Delete };

    public class DeleteBookingProductEventTicketTranslationCommandHandler : IRequestHandler<DeleteBookingProductEventTicketTranslationCommand, CustomResponseDto<DeletedBookingProductEventTicketTranslationResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBookingProductEventTicketTranslationRepository _bookingProductEventTicketTranslationRepository;
        private readonly BookingProductEventTicketTranslationBusinessRules _bookingProductEventTicketTranslationBusinessRules;

        public DeleteBookingProductEventTicketTranslationCommandHandler(IMapper mapper, IBookingProductEventTicketTranslationRepository bookingProductEventTicketTranslationRepository,
                                         BookingProductEventTicketTranslationBusinessRules bookingProductEventTicketTranslationBusinessRules)
        {
            _mapper = mapper;
            _bookingProductEventTicketTranslationRepository = bookingProductEventTicketTranslationRepository;
            _bookingProductEventTicketTranslationBusinessRules = bookingProductEventTicketTranslationBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedBookingProductEventTicketTranslationResponse>> Handle(DeleteBookingProductEventTicketTranslationCommand request, CancellationToken cancellationToken)
        {
            BookingProductEventTicketTranslation? bookingProductEventTicketTranslation = await _bookingProductEventTicketTranslationRepository.GetAsync(predicate: bpett => bpett.Id == request.Id, cancellationToken: cancellationToken);
            await _bookingProductEventTicketTranslationBusinessRules.BookingProductEventTicketTranslationShouldExistWhenSelected(bookingProductEventTicketTranslation);

            await _bookingProductEventTicketTranslationRepository.DeleteAsync(bookingProductEventTicketTranslation!);

            DeletedBookingProductEventTicketTranslationResponse response = _mapper.Map<DeletedBookingProductEventTicketTranslationResponse>(bookingProductEventTicketTranslation);

             return CustomResponseDto<DeletedBookingProductEventTicketTranslationResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}