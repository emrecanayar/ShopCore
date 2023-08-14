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

namespace Application.Features.CartItemInventories.Queries.GetById;

public class GetByIdCartItemInventoryQuery : IRequest<CustomResponseDto<GetByIdCartItemInventoryResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCartItemInventoryQueryHandler : IRequestHandler<GetByIdCartItemInventoryQuery, CustomResponseDto<GetByIdCartItemInventoryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartItemInventoryRepository _cartItemInventoryRepository;
        private readonly CartItemInventoryBusinessRules _cartItemInventoryBusinessRules;

        public GetByIdCartItemInventoryQueryHandler(IMapper mapper, ICartItemInventoryRepository cartItemInventoryRepository, CartItemInventoryBusinessRules cartItemInventoryBusinessRules)
        {
            _mapper = mapper;
            _cartItemInventoryRepository = cartItemInventoryRepository;
            _cartItemInventoryBusinessRules = cartItemInventoryBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdCartItemInventoryResponse>> Handle(GetByIdCartItemInventoryQuery request, CancellationToken cancellationToken)
        {
            CartItemInventory? cartItemInventory = await _cartItemInventoryRepository.GetAsync(predicate: cii => cii.Id == request.Id, cancellationToken: cancellationToken);
            await _cartItemInventoryBusinessRules.CartItemInventoryShouldExistWhenSelected(cartItemInventory);

            GetByIdCartItemInventoryResponse response = _mapper.Map<GetByIdCartItemInventoryResponse>(cartItemInventory);

          return CustomResponseDto<GetByIdCartItemInventoryResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}