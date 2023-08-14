using Application.Features.CartItemInventories.Constants;
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

namespace Application.Features.CartItemInventories.Commands.Delete;

public class DeleteCartItemInventoryCommand : IRequest<CustomResponseDto<DeletedCartItemInventoryResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CartItemInventoriesOperationClaims.Delete };

    public class DeleteCartItemInventoryCommandHandler : IRequestHandler<DeleteCartItemInventoryCommand, CustomResponseDto<DeletedCartItemInventoryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartItemInventoryRepository _cartItemInventoryRepository;
        private readonly CartItemInventoryBusinessRules _cartItemInventoryBusinessRules;

        public DeleteCartItemInventoryCommandHandler(IMapper mapper, ICartItemInventoryRepository cartItemInventoryRepository,
                                         CartItemInventoryBusinessRules cartItemInventoryBusinessRules)
        {
            _mapper = mapper;
            _cartItemInventoryRepository = cartItemInventoryRepository;
            _cartItemInventoryBusinessRules = cartItemInventoryBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedCartItemInventoryResponse>> Handle(DeleteCartItemInventoryCommand request, CancellationToken cancellationToken)
        {
            CartItemInventory? cartItemInventory = await _cartItemInventoryRepository.GetAsync(predicate: cii => cii.Id == request.Id, cancellationToken: cancellationToken);
            await _cartItemInventoryBusinessRules.CartItemInventoryShouldExistWhenSelected(cartItemInventory);

            await _cartItemInventoryRepository.DeleteAsync(cartItemInventory!);

            DeletedCartItemInventoryResponse response = _mapper.Map<DeletedCartItemInventoryResponse>(cartItemInventory);

             return CustomResponseDto<DeletedCartItemInventoryResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}