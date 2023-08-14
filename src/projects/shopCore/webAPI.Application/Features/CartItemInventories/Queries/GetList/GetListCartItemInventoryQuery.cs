using Application.Features.CartItemInventories.Constants;
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
using static Application.Features.CartItemInventories.Constants.CartItemInventoriesOperationClaims;

namespace Application.Features.CartItemInventories.Queries.GetList;

public class GetListCartItemInventoryQuery : IRequest<CustomResponseDto<GetListResponse<GetListCartItemInventoryListItemDto>>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListCartItemInventoryQueryHandler : IRequestHandler<GetListCartItemInventoryQuery, CustomResponseDto<GetListResponse<GetListCartItemInventoryListItemDto>>>
    {
        private readonly ICartItemInventoryRepository _cartItemInventoryRepository;
        private readonly IMapper _mapper;

        public GetListCartItemInventoryQueryHandler(ICartItemInventoryRepository cartItemInventoryRepository, IMapper mapper)
        {
            _cartItemInventoryRepository = cartItemInventoryRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListCartItemInventoryListItemDto>>> Handle(GetListCartItemInventoryQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CartItemInventory> cartItemInventories = await _cartItemInventoryRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCartItemInventoryListItemDto> response = _mapper.Map<GetListResponse<GetListCartItemInventoryListItemDto>>(cartItemInventories);
             return CustomResponseDto<GetListResponse<GetListCartItemInventoryListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}