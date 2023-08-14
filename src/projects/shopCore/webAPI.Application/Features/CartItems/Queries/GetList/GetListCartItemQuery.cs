using Application.Features.CartItems.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.CartItems.Constants.CartItemsOperationClaims;

namespace Application.Features.CartItems.Queries.GetList;

public class GetListCartItemQuery : IRequest<CustomResponseDto<GetListResponse<GetListCartItemListItemDto>>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListCartItemQueryHandler : IRequestHandler<GetListCartItemQuery, CustomResponseDto<GetListResponse<GetListCartItemListItemDto>>>
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IMapper _mapper;

        public GetListCartItemQueryHandler(ICartItemRepository cartItemRepository, IMapper mapper)
        {
            _cartItemRepository = cartItemRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListCartItemListItemDto>>> Handle(GetListCartItemQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CartItem> cartItems = await _cartItemRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCartItemListItemDto> response = _mapper.Map<GetListResponse<GetListCartItemListItemDto>>(cartItems);
             return CustomResponseDto<GetListResponse<GetListCartItemListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}