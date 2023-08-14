using Application.Features.BookingProductRentalSlots.Constants;
using Application.Features.BookingProductRentalSlots.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.BookingProductRentalSlots.Constants.BookingProductRentalSlotsOperationClaims;

namespace Application.Features.BookingProductRentalSlots.Queries.GetById;

public class GetByIdBookingProductRentalSlotQuery : IRequest<CustomResponseDto<GetByIdBookingProductRentalSlotResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdBookingProductRentalSlotQueryHandler : IRequestHandler<GetByIdBookingProductRentalSlotQuery, CustomResponseDto<GetByIdBookingProductRentalSlotResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBookingProductRentalSlotRepository _bookingProductRentalSlotRepository;
        private readonly BookingProductRentalSlotBusinessRules _bookingProductRentalSlotBusinessRules;

        public GetByIdBookingProductRentalSlotQueryHandler(IMapper mapper, IBookingProductRentalSlotRepository bookingProductRentalSlotRepository, BookingProductRentalSlotBusinessRules bookingProductRentalSlotBusinessRules)
        {
            _mapper = mapper;
            _bookingProductRentalSlotRepository = bookingProductRentalSlotRepository;
            _bookingProductRentalSlotBusinessRules = bookingProductRentalSlotBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdBookingProductRentalSlotResponse>> Handle(GetByIdBookingProductRentalSlotQuery request, CancellationToken cancellationToken)
        {
            BookingProductRentalSlot? bookingProductRentalSlot = await _bookingProductRentalSlotRepository.GetAsync(predicate: bprs => bprs.Id == request.Id, cancellationToken: cancellationToken);
            await _bookingProductRentalSlotBusinessRules.BookingProductRentalSlotShouldExistWhenSelected(bookingProductRentalSlot);

            GetByIdBookingProductRentalSlotResponse response = _mapper.Map<GetByIdBookingProductRentalSlotResponse>(bookingProductRentalSlot);

          return CustomResponseDto<GetByIdBookingProductRentalSlotResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}