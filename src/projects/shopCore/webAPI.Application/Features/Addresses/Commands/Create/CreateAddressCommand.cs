using Application.Features.Addresses.Constants;
using Application.Features.Addresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using System.Net;
using static Application.Features.Addresses.Constants.AddressesOperationClaims;

namespace Application.Features.Addresses.Commands.Create;

public class CreateAddressCommand : IRequest<CustomResponseDto<CreatedAddressResponse>>, ISecuredRequest
{
    public string AddressType { get; set; }
    public uint? CustomerId { get; set; }
    public uint? CartId { get; set; }
    public uint? OrderId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Gender { get; set; }
    public string? CompanyName { get; set; }
    public string Address1 { get; set; }
    public string? Address2 { get; set; }
    public string? Postcode { get; set; }
    public string City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? VatId { get; set; }
    public bool DefaultAddress { get; set; }
    public string? Additional { get; set; }

    public string[] Roles => new[] { Admin, Write, AddressesOperationClaims.Create };

    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, CustomResponseDto<CreatedAddressResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;
        private readonly AddressBusinessRules _addressBusinessRules;

        public CreateAddressCommandHandler(IMapper mapper, IAddressRepository addressRepository,
                                         AddressBusinessRules addressBusinessRules)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
            _addressBusinessRules = addressBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedAddressResponse>> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            Address address = _mapper.Map<Address>(request);

            await _addressRepository.AddAsync(address);

            CreatedAddressResponse response = _mapper.Map<CreatedAddressResponse>(address);
            return CustomResponseDto<CreatedAddressResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}