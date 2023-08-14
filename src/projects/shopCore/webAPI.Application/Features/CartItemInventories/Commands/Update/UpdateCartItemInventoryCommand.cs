using Application.Features.CartItemInventories.Constants;
using Application.Features.CartItemInventories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CartItemInventories.Constants.CartItemInventoriesOperationClaims;

namespace Application.Features.CartItemInventories.Commands.Update;

public class UpdateCartItemInventoryCommand : IRequest<CustomResponseDto<UpdatedCartItemInventoryResponse>>, ISecuredRequest
{
    public uint Id { get; set; }
    public uint Qty { get; set; }
    public uint? InventorySourceId { get; set; }
    public uint? CartItemId { get; set; }

    public string[] Roles => new[] { Admin, Write, CartItemInventoriesOperationClaims.Update };

    public class UpdateCartItemInventoryCommandHandler : IRequestHandler<UpdateCartItemInventoryCommand, CustomResponseDto<UpdatedCartItemInventoryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartItemInventoryRepository _cartItemInventoryRepository;
        private readonly CartItemInventoryBusinessRules _cartItemInventoryBusinessRules;

        public UpdateCartItemInventoryCommandHandler(IMapper mapper, ICartItemInventoryRepository cartItemInventoryRepository,
                                         CartItemInventoryBusinessRules cartItemInventoryBusinessRules)
        {
            _mapper = mapper;
            _cartItemInventoryRepository = cartItemInventoryRepository;
            _cartItemInventoryBusinessRules = cartItemInventoryBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedCartItemInventoryResponse>> Handle(UpdateCartItemInventoryCommand request, CancellationToken cancellationToken)
        {
            CartItemInventory? cartItemInventory = await _cartItemInventoryRepository.GetAsync(predicate: cii => cii.Id == request.Id, cancellationToken: cancellationToken);
            await _cartItemInventoryBusinessRules.CartItemInventoryShouldExistWhenSelected(cartItemInventory);
            cartItemInventory = _mapper.Map(request, cartItemInventory);

            await _cartItemInventoryRepository.UpdateAsync(cartItemInventory!);

            UpdatedCartItemInventoryResponse response = _mapper.Map<UpdatedCartItemInventoryResponse>(cartItemInventory);

          return CustomResponseDto<UpdatedCartItemInventoryResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}