using Application.Features.Addresses.Constants;
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

namespace Application.Features.Addresses.Commands.Delete;

public class DeleteAddressCommand : IRequest<CustomResponseDto<DeletedAddressResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Write, AddressesOperationClaims.Delete };

    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, CustomResponseDto<DeletedAddressResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;
        private readonly AddressBusinessRules _addressBusinessRules;

        public DeleteAddressCommandHandler(IMapper mapper, IAddressRepository addressRepository,
                                         AddressBusinessRules addressBusinessRules)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
            _addressBusinessRules = addressBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedAddressResponse>> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            Address? address = await _addressRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _addressBusinessRules.AddressShouldExistWhenSelected(address);

            await _addressRepository.DeleteAsync(address!);

            DeletedAddressResponse response = _mapper.Map<DeletedAddressResponse>(address);

             return CustomResponseDto<DeletedAddressResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}