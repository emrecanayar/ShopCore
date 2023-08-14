using Application.Features.CartItems.Constants;
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

namespace Application.Features.CartItems.Commands.Delete;

public class DeleteCartItemCommand : IRequest<CustomResponseDto<DeletedCartItemResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CartItemsOperationClaims.Delete };

    public class DeleteCartItemCommandHandler : IRequestHandler<DeleteCartItemCommand, CustomResponseDto<DeletedCartItemResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly CartItemBusinessRules _cartItemBusinessRules;

        public DeleteCartItemCommandHandler(IMapper mapper, ICartItemRepository cartItemRepository,
                                         CartItemBusinessRules cartItemBusinessRules)
        {
            _mapper = mapper;
            _cartItemRepository = cartItemRepository;
            _cartItemBusinessRules = cartItemBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedCartItemResponse>> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
        {
            CartItem? cartItem = await _cartItemRepository.GetAsync(predicate: ci => ci.Id == request.Id, cancellationToken: cancellationToken);
            await _cartItemBusinessRules.CartItemShouldExistWhenSelected(cartItem);

            await _cartItemRepository.DeleteAsync(cartItem!);

            DeletedCartItemResponse response = _mapper.Map<DeletedCartItemResponse>(cartItem);

             return CustomResponseDto<DeletedCartItemResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}