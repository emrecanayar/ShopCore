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

namespace Application.Features.BookingProducts.Commands.Update;

public class UpdateBookingProductCommand : IRequest<CustomResponseDto<UpdatedBookingProductResponse>>, ISecuredRequest
{
    public uint Id { get; set; }
    public string Type { get; set; }
    public int? Qty { get; set; }
    public string? Location { get; set; }
    public bool ShowLocation { get; set; }
    public bool? AvailableEveryWeek { get; set; }
    public DateTime? AvailableFrom { get; set; }
    public DateTime? AvailableTo { get; set; }
    public uint ProductId { get; set; }

    public string[] Roles => new[] { Admin, Write, BookingProductsOperationClaims.Update };

    public class UpdateBookingProductCommandHandler : IRequestHandler<UpdateBookingProductCommand, CustomResponseDto<UpdatedBookingProductResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBookingProductRepository _bookingProductRepository;
        private readonly BookingProductBusinessRules _bookingProductBusinessRules;

        public UpdateBookingProductCommandHandler(IMapper mapper, IBookingProductRepository bookingProductRepository,
                                         BookingProductBusinessRules bookingProductBusinessRules)
        {
            _mapper = mapper;
            _bookingProductRepository = bookingProductRepository;
            _bookingProductBusinessRules = bookingProductBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedBookingProductResponse>> Handle(UpdateBookingProductCommand request, CancellationToken cancellationToken)
        {
            BookingProduct? bookingProduct = await _bookingProductRepository.GetAsync(predicate: bp => bp.Id == request.Id, cancellationToken: cancellationToken);
            await _bookingProductBusinessRules.BookingProductShouldExistWhenSelected(bookingProduct);
            bookingProduct = _mapper.Map(request, bookingProduct);

            await _bookingProductRepository.UpdateAsync(bookingProduct!);

            UpdatedBookingProductResponse response = _mapper.Map<UpdatedBookingProductResponse>(bookingProduct);

          return CustomResponseDto<UpdatedBookingProductResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}