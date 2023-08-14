using Application.Features.BookingProducts.Constants;
using Application.Features.BookingProducts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.BookingProducts.Constants.BookingProductsOperationClaims;

namespace Application.Features.BookingProducts.Queries.GetById;

public class GetByIdBookingProductQuery : IRequest<CustomResponseDto<GetByIdBookingProductResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdBookingProductQueryHandler : IRequestHandler<GetByIdBookingProductQuery, CustomResponseDto<GetByIdBookingProductResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBookingProductRepository _bookingProductRepository;
        private readonly BookingProductBusinessRules _bookingProductBusinessRules;

        public GetByIdBookingProductQueryHandler(IMapper mapper, IBookingProductRepository bookingProductRepository, BookingProductBusinessRules bookingProductBusinessRules)
        {
            _mapper = mapper;
            _bookingProductRepository = bookingProductRepository;
            _bookingProductBusinessRules = bookingProductBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdBookingProductResponse>> Handle(GetByIdBookingProductQuery request, CancellationToken cancellationToken)
        {
            BookingProduct? bookingProduct = await _bookingProductRepository.GetAsync(predicate: bp => bp.Id == request.Id, cancellationToken: cancellationToken);
            await _bookingProductBusinessRules.BookingProductShouldExistWhenSelected(bookingProduct);

            GetByIdBookingProductResponse response = _mapper.Map<GetByIdBookingProductResponse>(bookingProduct);

          return CustomResponseDto<GetByIdBookingProductResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}