using Application.Features.Carts.Constants;
using Application.Features.Carts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Carts.Constants.CartsOperationClaims;

namespace Application.Features.Carts.Queries.GetById;

public class GetByIdCartQuery : IRequest<CustomResponseDto<GetByIdCartResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCartQueryHandler : IRequestHandler<GetByIdCartQuery, CustomResponseDto<GetByIdCartResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICartRepository _cartRepository;
        private readonly CartBusinessRules _cartBusinessRules;

        public GetByIdCartQueryHandler(IMapper mapper, ICartRepository cartRepository, CartBusinessRules cartBusinessRules)
        {
            _mapper = mapper;
            _cartRepository = cartRepository;
            _cartBusinessRules = cartBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdCartResponse>> Handle(GetByIdCartQuery request, CancellationToken cancellationToken)
        {
            Cart? cart = await _cartRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _cartBusinessRules.CartShouldExistWhenSelected(cart);

            GetByIdCartResponse response = _mapper.Map<GetByIdCartResponse>(cart);

          return CustomResponseDto<GetByIdCartResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}