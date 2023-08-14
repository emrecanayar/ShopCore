using Application.Features.BookingProductTableSlots.Constants;
using Application.Features.BookingProductTableSlots.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.BookingProductTableSlots.Constants.BookingProductTableSlotsOperationClaims;

namespace Application.Features.BookingProductTableSlots.Queries.GetById;

public class GetByIdBookingProductTableSlotQuery : IRequest<CustomResponseDto<GetByIdBookingProductTableSlotResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdBookingProductTableSlotQueryHandler : IRequestHandler<GetByIdBookingProductTableSlotQuery, CustomResponseDto<GetByIdBookingProductTableSlotResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBookingProductTableSlotRepository _bookingProductTableSlotRepository;
        private readonly BookingProductTableSlotBusinessRules _bookingProductTableSlotBusinessRules;

        public GetByIdBookingProductTableSlotQueryHandler(IMapper mapper, IBookingProductTableSlotRepository bookingProductTableSlotRepository, BookingProductTableSlotBusinessRules bookingProductTableSlotBusinessRules)
        {
            _mapper = mapper;
            _bookingProductTableSlotRepository = bookingProductTableSlotRepository;
            _bookingProductTableSlotBusinessRules = bookingProductTableSlotBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdBookingProductTableSlotResponse>> Handle(GetByIdBookingProductTableSlotQuery request, CancellationToken cancellationToken)
        {
            BookingProductTableSlot? bookingProductTableSlot = await _bookingProductTableSlotRepository.GetAsync(predicate: bpts => bpts.Id == request.Id, cancellationToken: cancellationToken);
            await _bookingProductTableSlotBusinessRules.BookingProductTableSlotShouldExistWhenSelected(bookingProductTableSlot);

            GetByIdBookingProductTableSlotResponse response = _mapper.Map<GetByIdBookingProductTableSlotResponse>(bookingProductTableSlot);

          return CustomResponseDto<GetByIdBookingProductTableSlotResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}