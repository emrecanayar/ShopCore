using Application.Features.Attributes.Constants;
using Application.Features.Attributes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.ResponseTypes.Concrete;
using MediatR;
using System.Net;
using static Application.Features.Attributes.Constants.AttributesOperationClaims;
using Attribute = Core.Domain.Entities.Attribute;

namespace Application.Features.Attributes.Commands.Delete;

public class DeleteAttributeCommand : IRequest<CustomResponseDto<DeletedAttributeResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Write, AttributesOperationClaims.Delete };

    public class DeleteAttributeCommandHandler : IRequestHandler<DeleteAttributeCommand, CustomResponseDto<DeletedAttributeResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IAttributeRepository _attributeRepository;
        private readonly AttributeBusinessRules _attributeBusinessRules;

        public DeleteAttributeCommandHandler(IMapper mapper, IAttributeRepository attributeRepository,
                                         AttributeBusinessRules attributeBusinessRules)
        {
            _mapper = mapper;
            _attributeRepository = attributeRepository;
            _attributeBusinessRules = attributeBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedAttributeResponse>> Handle(DeleteAttributeCommand request, CancellationToken cancellationToken)
        {
            Attribute? attribute = await _attributeRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _attributeBusinessRules.AttributeShouldExistWhenSelected(attribute);

            await _attributeRepository.DeleteAsync(attribute!);

            DeletedAttributeResponse response = _mapper.Map<DeletedAttributeResponse>(attribute);

            return CustomResponseDto<DeletedAttributeResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}