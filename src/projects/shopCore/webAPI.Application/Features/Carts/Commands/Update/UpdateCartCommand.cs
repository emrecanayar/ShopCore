using Application.Features.Carts.Constants;
using Application.Features.Carts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Carts.Constants.CartsOperationClaims;

namespace Application.Features.Carts.Commands.Update;

public class UpdateCartCommand : IRequest<CustomResponseDto<UpdatedCartResponse>>, ISecuredRequest
{
    public uint Id { get; set; }
    public string? CustomerEmail { get; set; }
    public string? CustomerFirstName { get; set; }
    public string? CustomerLastName { get; set; }
    public string? ShippingMethod { get; set; }
    public string? CouponCode { get; set; }
    public bool IsGift { get; set; }
    public int? ItemsCount { get; set; }
    public decimal? ItemsQty { get; set; }
    public decimal? ExchangeRate { get; set; }
    public string? GlobalCurrencyCode { get; set; }
    public string? BaseCurrencyCode { get; set; }
    public string? ChannelCurrencyCode { get; set; }
    public string? CartCurrencyCode { get; set; }
    public decimal? GrandTotal { get; set; }
    public decimal? BaseGrandTotal { get; set; }
    public decimal? SubTotal { get; set; }
    public decimal? BaseSubTotal { get; set; }
    public decimal? TaxTotal { get; set; }
    public decimal? BaseTaxTotal { get; set; }
    public decimal? DiscountAmount { get; set; }
    public decimal? BaseDiscountAmount { get; set; }
    public string? CheckoutMethod { get; set; }
    public bool? IsGuest { get; set; }
    public bool? IsActive { get; set; }
    public DateTime? ConversionTime { get; set; }
    public uint? CustomerId { get; set; }
    public uint ChannelId { get; set; }
    public string? AppliedCartRuleIds { get; set; }

    public string[] Roles => new[] { Admin, Write, CartsOperationClaims.Update };

    public class UpdateCartCommandHandler : IRequestHandler<UpdateCartCommand, CustomResponseDto<UpdatedCartResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartRepository _cartRepository;
        private readonly CartBusinessRules _cartBusinessRules;

        public UpdateCartCommandHandler(IMapper mapper, ICartRepository cartRepository,
                                         CartBusinessRules cartBusinessRules)
        {
            _mapper = mapper;
            _cartRepository = cartRepository;
            _cartBusinessRules = cartBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedCartResponse>> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {
            Cart? cart = await _cartRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _cartBusinessRules.CartShouldExistWhenSelected(cart);
            cart = _mapper.Map(request, cart);

            await _cartRepository.UpdateAsync(cart!);

            UpdatedCartResponse response = _mapper.Map<UpdatedCartResponse>(cart);

          return CustomResponseDto<UpdatedCartResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}