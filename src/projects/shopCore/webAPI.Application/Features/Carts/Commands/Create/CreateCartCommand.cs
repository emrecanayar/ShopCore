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

namespace Application.Features.Carts.Commands.Create;

public class CreateCartCommand : IRequest<CustomResponseDto<CreatedCartResponse>>, ISecuredRequest
{
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

    public string[] Roles => new[] { Admin, Write, CartsOperationClaims.Create };

    public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, CustomResponseDto<CreatedCartResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartRepository _cartRepository;
        private readonly CartBusinessRules _cartBusinessRules;

        public CreateCartCommandHandler(IMapper mapper, ICartRepository cartRepository,
                                         CartBusinessRules cartBusinessRules)
        {
            _mapper = mapper;
            _cartRepository = cartRepository;
            _cartBusinessRules = cartBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedCartResponse>> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            Cart cart = _mapper.Map<Cart>(request);

            await _cartRepository.AddAsync(cart);

            CreatedCartResponse response = _mapper.Map<CreatedCartResponse>(cart);
         return CustomResponseDto<CreatedCartResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}