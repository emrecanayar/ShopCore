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

namespace Application.Features.Attributes.Commands.Create;

public class CreateAttributeCommand : IRequest<CustomResponseDto<CreatedAttributeResponse>>, ISecuredRequest
{
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

    public string[] Roles => new[] { Admin, Write, AttributesOperationClaims.Create };

    public class CreateAttributeCommandHandler : IRequestHandler<CreateAttributeCommand, CustomResponseDto<CreatedAttributeResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IAttributeRepository _attributeRepository;
        private readonly AttributeBusinessRules _attributeBusinessRules;

        public CreateAttributeCommandHandler(IMapper mapper, IAttributeRepository attributeRepository,
                                         AttributeBusinessRules attributeBusinessRules)
        {
            _mapper = mapper;
            _attributeRepository = attributeRepository;
            _attributeBusinessRules = attributeBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedAttributeResponse>> Handle(CreateAttributeCommand request, CancellationToken cancellationToken)
        {
            Attribute attribute = _mapper.Map<Attribute>(request);

            await _attributeRepository.AddAsync(attribute);

            CreatedAttributeResponse response = _mapper.Map<CreatedAttributeResponse>(attribute);
            return CustomResponseDto<CreatedAttributeResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}