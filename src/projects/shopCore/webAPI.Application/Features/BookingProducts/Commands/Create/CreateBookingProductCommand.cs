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

namespace Application.Features.BookingProducts.Commands.Create;

public class CreateBookingProductCommand : IRequest<CustomResponseDto<CreatedBookingProductResponse>>, ISecuredRequest
{
    public string Type { get; set; }
    public int? Qty { get; set; }
    public string? Location { get; set; }
    public bool ShowLocation { get; set; }
    public bool? AvailableEveryWeek { get; set; }
    public DateTime? AvailableFrom { get; set; }
    public DateTime? AvailableTo { get; set; }
    public uint ProductId { get; set; }

    public string[] Roles => new[] { Admin, Write, BookingProductsOperationClaims.Create };

    public class CreateBookingProductCommandHandler : IRequestHandler<CreateBookingProductCommand, CustomResponseDto<CreatedBookingProductResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBookingProductRepository _bookingProductRepository;
        private readonly BookingProductBusinessRules _bookingProductBusinessRules;

        public CreateBookingProductCommandHandler(IMapper mapper, IBookingProductRepository bookingProductRepository,
                                         BookingProductBusinessRules bookingProductBusinessRules)
        {
            _mapper = mapper;
            _bookingProductRepository = bookingProductRepository;
            _bookingProductBusinessRules = bookingProductBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedBookingProductResponse>> Handle(CreateBookingProductCommand request, CancellationToken cancellationToken)
        {
            BookingProduct bookingProduct = _mapper.Map<BookingProduct>(request);

            await _bookingProductRepository.AddAsync(bookingProduct);

            CreatedBookingProductResponse response = _mapper.Map<CreatedBookingProductResponse>(bookingProduct);
         return CustomResponseDto<CreatedBookingProductResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}