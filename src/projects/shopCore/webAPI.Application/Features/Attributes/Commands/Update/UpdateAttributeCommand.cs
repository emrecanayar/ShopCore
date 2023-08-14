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

namespace Application.Features.Attributes.Commands.Update;

public class UpdateAttributeCommand : IRequest<CustomResponseDto<UpdatedAttributeResponse>>, ISecuredRequest
{
    public uint Id { get; set; }
    public string Code { get; set; }
    public string AdminName { get; set; }
    public string Type { get; set; }
    public string? Validation { get; set; }
    public int? Position { get; set; }
    public bool IsRequired { get; set; }
    public bool IsUnique { get; set; }
    public bool ValuePerLocale { get; set; }
    public bool ValuePerChannel { get; set; }
    public bool IsFilterable { get; set; }
    public bool IsConfigurable { get; set; }
    public bool? IsUserDefined { get; set; }
    public bool IsVisibleOnFront { get; set; }
    public string? SwatchType { get; set; }
    public bool? UseInFlat { get; set; }
    public bool IsComparable { get; set; }
    public bool EnableWysiwyg { get; set; }

    public string[] Roles => new[] { Admin, Write, AttributesOperationClaims.Update };

    public class UpdateAttributeCommandHandler : IRequestHandler<UpdateAttributeCommand, CustomResponseDto<UpdatedAttributeResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IAttributeRepository _attributeRepository;
        private readonly AttributeBusinessRules _attributeBusinessRules;

        public UpdateAttributeCommandHandler(IMapper mapper, IAttributeRepository attributeRepository,
                                         AttributeBusinessRules attributeBusinessRules)
        {
            _mapper = mapper;
            _attributeRepository = attributeRepository;
            _attributeBusinessRules = attributeBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedAttributeResponse>> Handle(UpdateAttributeCommand request, CancellationToken cancellationToken)
        {
            Attribute? attribute = await _attributeRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _attributeBusinessRules.AttributeShouldExistWhenSelected(attribute);
            attribute = _mapper.Map(request, attribute);

            await _attributeRepository.UpdateAsync(attribute!);

            UpdatedAttributeResponse response = _mapper.Map<UpdatedAttributeResponse>(attribute);

            return CustomResponseDto<UpdatedAttributeResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}