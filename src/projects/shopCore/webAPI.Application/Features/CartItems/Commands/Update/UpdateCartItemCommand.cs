using Application.Features.CartItems.Constants;
using Application.Features.CartItems.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CartItems.Constants.CartItemsOperationClaims;

namespace Application.Features.CartItems.Commands.Update;

public class UpdateCartItemCommand : IRequest<CustomResponseDto<UpdatedCartItemResponse>>, ISecuredRequest
{
    public uint Id { get; set; }
    public uint Quantity { get; set; }
    public string? Sku { get; set; }
    public string? Type { get; set; }
    public string? Name { get; set; }
    public string? CouponCode { get; set; }
    public decimal Weight { get; set; }
    public decimal TotalWeight { get; set; }
    public decimal BaseTotalWeight { get; set; }
    public decimal Price { get; set; }
    public decimal BasePrice { get; set; }
    public decimal Total { get; set; }
    public decimal BaseTotal { get; set; }
    public decimal? TaxPercent { get; set; }
    public decimal? TaxAmount { get; set; }
    public decimal? BaseTaxAmount { get; set; }
    public decimal DiscountPercent { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal BaseDiscountAmount { get; set; }
    public string? Additional { get; set; }
    public uint? ParentId { get; set; }
    public uint ProductId { get; set; }
    public uint CartId { get; set; }
    public uint? TaxCategoryId { get; set; }
    public decimal? CustomPrice { get; set; }
    public string? AppliedCartRuleIds { get; set; }

    public string[] Roles => new[] { Admin, Write, CartItemsOperationClaims.Update };

    public class UpdateCartItemCommandHandler : IRequestHandler<UpdateCartItemCommand, CustomResponseDto<UpdatedCartItemResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly CartItemBusinessRules _cartItemBusinessRules;

        public UpdateCartItemCommandHandler(IMapper mapper, ICartItemRepository cartItemRepository,
                                         CartItemBusinessRules cartItemBusinessRules)
        {
            _mapper = mapper;
            _cartItemRepository = cartItemRepository;
            _cartItemBusinessRules = cartItemBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedCartItemResponse>> Handle(UpdateCartItemCommand request, CancellationToken cancellationToken)
        {
            CartItem? cartItem = await _cartItemRepository.GetAsync(predicate: ci => ci.Id == request.Id, cancellationToken: cancellationToken);
            await _cartItemBusinessRules.CartItemShouldExistWhenSelected(cartItem);
            cartItem = _mapper.Map(request, cartItem);

            await _cartItemRepository.UpdateAsync(cartItem!);

            UpdatedCartItemResponse response = _mapper.Map<UpdatedCartItemResponse>(cartItem);

          return CustomResponseDto<UpdatedCartItemResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}