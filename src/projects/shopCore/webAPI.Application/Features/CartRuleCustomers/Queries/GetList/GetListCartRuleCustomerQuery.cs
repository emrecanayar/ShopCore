using Application.Features.CartRuleCustomers.Constants;
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
using static Application.Features.CartRuleCustomers.Constants.CartRuleCustomersOperationClaims;

namespace Application.Features.CartRuleCustomers.Queries.GetList;

public class GetListCartRuleCustomerQuery : IRequest<CustomResponseDto<GetListResponse<GetListCartRuleCustomerListItemDto>>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListCartRuleCustomerQueryHandler : IRequestHandler<GetListCartRuleCustomerQuery, CustomResponseDto<GetListResponse<GetListCartRuleCustomerListItemDto>>>
    {
        private readonly ICartRuleCustomerRepository _cartRuleCustomerRepository;
        private readonly IMapper _mapper;

        public GetListCartRuleCustomerQueryHandler(ICartRuleCustomerRepository cartRuleCustomerRepository, IMapper mapper)
        {
            _cartRuleCustomerRepository = cartRuleCustomerRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListCartRuleCustomerListItemDto>>> Handle(GetListCartRuleCustomerQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CartRuleCustomer> cartRuleCustomers = await _cartRuleCustomerRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCartRuleCustomerListItemDto> response = _mapper.Map<GetListResponse<GetListCartRuleCustomerListItemDto>>(cartRuleCustomers);
             return CustomResponseDto<GetListResponse<GetListCartRuleCustomerListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}