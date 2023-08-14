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

namespace Application.Features.CartItems.Queries.GetById;

public class GetByIdCartItemQuery : IRequest<CustomResponseDto<GetByIdCartItemResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCartItemQueryHandler : IRequestHandler<GetByIdCartItemQuery, CustomResponseDto<GetByIdCartItemResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly CartItemBusinessRules _cartItemBusinessRules;

        public GetByIdCartItemQueryHandler(IMapper mapper, ICartItemRepository cartItemRepository, CartItemBusinessRules cartItemBusinessRules)
        {
            _mapper = mapper;
            _cartItemRepository = cartItemRepository;
            _cartItemBusinessRules = cartItemBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdCartItemResponse>> Handle(GetByIdCartItemQuery request, CancellationToken cancellationToken)
        {
            CartItem? cartItem = await _cartItemRepository.GetAsync(predicate: ci => ci.Id == request.Id, cancellationToken: cancellationToken);
            await _cartItemBusinessRules.CartItemShouldExistWhenSelected(cartItem);

            GetByIdCartItemResponse response = _mapper.Map<GetByIdCartItemResponse>(cartItem);

          return CustomResponseDto<GetByIdCartItemResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}