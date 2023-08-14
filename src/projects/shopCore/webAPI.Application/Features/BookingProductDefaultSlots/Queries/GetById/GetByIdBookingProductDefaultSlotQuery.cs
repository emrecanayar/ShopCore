using Application.Features.BookingProductDefaultSlots.Constants;
using Application.Features.BookingProductDefaultSlots.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.BookingProductDefaultSlots.Constants.BookingProductDefaultSlotsOperationClaims;

namespace Application.Features.BookingProductDefaultSlots.Queries.GetById;

public class GetByIdBookingProductDefaultSlotQuery : IRequest<CustomResponseDto<GetByIdBookingProductDefaultSlotResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdBookingProductDefaultSlotQueryHandler : IRequestHandler<GetByIdBookingProductDefaultSlotQuery, CustomResponseDto<GetByIdBookingProductDefaultSlotResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBookingProductDefaultSlotRepository _bookingProductDefaultSlotRepository;
        private readonly BookingProductDefaultSlotBusinessRules _bookingProductDefaultSlotBusinessRules;

        public GetByIdBookingProductDefaultSlotQueryHandler(IMapper mapper, IBookingProductDefaultSlotRepository bookingProductDefaultSlotRepository, BookingProductDefaultSlotBusinessRules bookingProductDefaultSlotBusinessRules)
        {
            _mapper = mapper;
            _bookingProductDefaultSlotRepository = bookingProductDefaultSlotRepository;
            _bookingProductDefaultSlotBusinessRules = bookingProductDefaultSlotBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdBookingProductDefaultSlotResponse>> Handle(GetByIdBookingProductDefaultSlotQuery request, CancellationToken cancellationToken)
        {
            BookingProductDefaultSlot? bookingProductDefaultSlot = await _bookingProductDefaultSlotRepository.GetAsync(predicate: bpds => bpds.Id == request.Id, cancellationToken: cancellationToken);
            await _bookingProductDefaultSlotBusinessRules.BookingProductDefaultSlotShouldExistWhenSelected(bookingProductDefaultSlot);

            GetByIdBookingProductDefaultSlotResponse response = _mapper.Map<GetByIdBookingProductDefaultSlotResponse>(bookingProductDefaultSlot);

          return CustomResponseDto<GetByIdBookingProductDefaultSlotResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}