using Application.Features.Addresses.Constants;
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
using static Application.Features.Addresses.Constants.AddressesOperationClaims;

namespace Application.Features.Addresses.Queries.GetList;

public class GetListAddressQuery : IRequest<CustomResponseDto<GetListResponse<GetListAddressListItemDto>>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListAddressQueryHandler : IRequestHandler<GetListAddressQuery, CustomResponseDto<GetListResponse<GetListAddressListItemDto>>>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public GetListAddressQueryHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListAddressListItemDto>>> Handle(GetListAddressQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Address> addresses = await _addressRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAddressListItemDto> response = _mapper.Map<GetListResponse<GetListAddressListItemDto>>(addresses);
             return CustomResponseDto<GetListResponse<GetListAddressListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}