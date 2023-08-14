using Application.Features.Addresses.Constants;
using Application.Features.Addresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Addresses.Constants.AddressesOperationClaims;

namespace Application.Features.Addresses.Queries.GetById;

public class GetByIdAddressQuery : IRequest<CustomResponseDto<GetByIdAddressResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdAddressQueryHandler : IRequestHandler<GetByIdAddressQuery, CustomResponseDto<GetByIdAddressResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;
        private readonly AddressBusinessRules _addressBusinessRules;

        public GetByIdAddressQueryHandler(IMapper mapper, IAddressRepository addressRepository, AddressBusinessRules addressBusinessRules)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
            _addressBusinessRules = addressBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdAddressResponse>> Handle(GetByIdAddressQuery request, CancellationToken cancellationToken)
        {
            Address? address = await _addressRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _addressBusinessRules.AddressShouldExistWhenSelected(address);

            GetByIdAddressResponse response = _mapper.Map<GetByIdAddressResponse>(address);

          return CustomResponseDto<GetByIdAddressResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}