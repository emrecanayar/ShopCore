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

namespace Application.Features.Addresses.Commands.Update;

public class UpdateAddressCommand : IRequest<CustomResponseDto<UpdatedAddressResponse>>, ISecuredRequest
{
    public uint Id { get; set; }
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

    public string[] Roles => new[] { Admin, Write, AddressesOperationClaims.Update };

    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, CustomResponseDto<UpdatedAddressResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;
        private readonly AddressBusinessRules _addressBusinessRules;

        public UpdateAddressCommandHandler(IMapper mapper, IAddressRepository addressRepository,
                                         AddressBusinessRules addressBusinessRules)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
            _addressBusinessRules = addressBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedAddressResponse>> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            Address? address = await _addressRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _addressBusinessRules.AddressShouldExistWhenSelected(address);
            address = _mapper.Map(request, address);

            await _addressRepository.UpdateAsync(address!);

            UpdatedAddressResponse response = _mapper.Map<UpdatedAddressResponse>(address);

          return CustomResponseDto<UpdatedAddressResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}