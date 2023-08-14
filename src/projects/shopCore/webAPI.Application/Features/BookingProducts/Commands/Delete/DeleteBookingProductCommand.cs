using Application.Features.BookingProducts.Constants;
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

namespace Application.Features.BookingProducts.Commands.Delete;

public class DeleteBookingProductCommand : IRequest<CustomResponseDto<DeletedBookingProductResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Write, BookingProductsOperationClaims.Delete };

    public class DeleteBookingProductCommandHandler : IRequestHandler<DeleteBookingProductCommand, CustomResponseDto<DeletedBookingProductResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBookingProductRepository _bookingProductRepository;
        private readonly BookingProductBusinessRules _bookingProductBusinessRules;

        public DeleteBookingProductCommandHandler(IMapper mapper, IBookingProductRepository bookingProductRepository,
                                         BookingProductBusinessRules bookingProductBusinessRules)
        {
            _mapper = mapper;
            _bookingProductRepository = bookingProductRepository;
            _bookingProductBusinessRules = bookingProductBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedBookingProductResponse>> Handle(DeleteBookingProductCommand request, CancellationToken cancellationToken)
        {
            BookingProduct? bookingProduct = await _bookingProductRepository.GetAsync(predicate: bp => bp.Id == request.Id, cancellationToken: cancellationToken);
            await _bookingProductBusinessRules.BookingProductShouldExistWhenSelected(bookingProduct);

            await _bookingProductRepository.DeleteAsync(bookingProduct!);

            DeletedBookingProductResponse response = _mapper.Map<DeletedBookingProductResponse>(bookingProduct);

             return CustomResponseDto<DeletedBookingProductResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}