using Application.Features.Carts.Constants;
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
using static Application.Features.Carts.Constants.CartsOperationClaims;

namespace Application.Features.Carts.Queries.GetList;

public class GetListCartQuery : IRequest<CustomResponseDto<GetListResponse<GetListCartListItemDto>>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListCartQueryHandler : IRequestHandler<GetListCartQuery, CustomResponseDto<GetListResponse<GetListCartListItemDto>>>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public GetListCartQueryHandler(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListCartListItemDto>>> Handle(GetListCartQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Cart> carts = await _cartRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCartListItemDto> response = _mapper.Map<GetListResponse<GetListCartListItemDto>>(carts);
             return CustomResponseDto<GetListResponse<GetListCartListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}