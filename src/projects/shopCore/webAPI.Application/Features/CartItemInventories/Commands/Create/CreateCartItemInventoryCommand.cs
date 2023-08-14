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

namespace Application.Features.CartItemInventories.Commands.Create;

public class CreateCartItemInventoryCommand : IRequest<CustomResponseDto<CreatedCartItemInventoryResponse>>, ISecuredRequest
{
    public uint Qty { get; set; }
    public uint? InventorySourceId { get; set; }
    public uint? CartItemId { get; set; }

    public string[] Roles => new[] { Admin, Write, CartItemInventoriesOperationClaims.Create };

    public class CreateCartItemInventoryCommandHandler : IRequestHandler<CreateCartItemInventoryCommand, CustomResponseDto<CreatedCartItemInventoryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartItemInventoryRepository _cartItemInventoryRepository;
        private readonly CartItemInventoryBusinessRules _cartItemInventoryBusinessRules;

        public CreateCartItemInventoryCommandHandler(IMapper mapper, ICartItemInventoryRepository cartItemInventoryRepository,
                                         CartItemInventoryBusinessRules cartItemInventoryBusinessRules)
        {
            _mapper = mapper;
            _cartItemInventoryRepository = cartItemInventoryRepository;
            _cartItemInventoryBusinessRules = cartItemInventoryBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedCartItemInventoryResponse>> Handle(CreateCartItemInventoryCommand request, CancellationToken cancellationToken)
        {
            CartItemInventory cartItemInventory = _mapper.Map<CartItemInventory>(request);

            await _cartItemInventoryRepository.AddAsync(cartItemInventory);

            CreatedCartItemInventoryResponse response = _mapper.Map<CreatedCartItemInventoryResponse>(cartItemInventory);
         return CustomResponseDto<CreatedCartItemInventoryResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}