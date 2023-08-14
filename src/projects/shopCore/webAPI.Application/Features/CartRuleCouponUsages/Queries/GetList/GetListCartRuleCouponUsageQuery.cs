using Application.Services.Repositories;
using AutoMapper;
using Core.Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.CartRuleCouponUsages.Queries.GetList;

public class GetListCartRuleCouponUsageQuery : IRequest<CustomResponseDto<GetListResponse<GetListCartRuleCouponUsageListItemDto>>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListCartRuleCouponUsageQueryHandler : IRequestHandler<GetListCartRuleCouponUsageQuery, CustomResponseDto<GetListResponse<GetListCartRuleCouponUsageListItemDto>>>
    {
        private readonly ICartRuleCouponUsageRepository _cartRuleCouponUsageRepository;
        private readonly IMapper _mapper;

        public GetListCartRuleCouponUsageQueryHandler(ICartRuleCouponUsageRepository cartRuleCouponUsageRepository, IMapper mapper)
        {
            _cartRuleCouponUsageRepository = cartRuleCouponUsageRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListCartRuleCouponUsageListItemDto>>> Handle(GetListCartRuleCouponUsageQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CartRuleCouponUsage> cartRuleCouponUsages = await _cartRuleCouponUsageRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCartRuleCouponUsageListItemDto> response = _mapper.Map<GetListResponse<GetListCartRuleCouponUsageListItemDto>>(cartRuleCouponUsages);
             return CustomResponseDto<GetListResponse<GetListCartRuleCouponUsageListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}