using Application.Features.AttributeOptions.Constants;
using Application.Features.AttributeOptions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.AttributeOptions.Constants.AttributeOptionsOperationClaims;

namespace Application.Features.AttributeOptions.Commands.Update;

public class UpdateAttributeOptionCommand : IRequest<CustomResponseDto<UpdatedAttributeOptionResponse>>, ISecuredRequest
{
    public uint Id { get; set; }
    public string? AdminName { get; set; }
    public int? SortOrder { get; set; }
    public uint AttributeId { get; set; }
    public string? SwatchValue { get; set; }

    public string[] Roles => new[] { Admin, Write, AttributeOptionsOperationClaims.Update };

    public class UpdateAttributeOptionCommandHandler : IRequestHandler<UpdateAttributeOptionCommand, CustomResponseDto<UpdatedAttributeOptionResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IAttributeOptionRepository _attributeOptionRepository;
        private readonly AttributeOptionBusinessRules _attributeOptionBusinessRules;

        public UpdateAttributeOptionCommandHandler(IMapper mapper, IAttributeOptionRepository attributeOptionRepository,
                                         AttributeOptionBusinessRules attributeOptionBusinessRules)
        {
            _mapper = mapper;
            _attributeOptionRepository = attributeOptionRepository;
            _attributeOptionBusinessRules = attributeOptionBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedAttributeOptionResponse>> Handle(UpdateAttributeOptionCommand request, CancellationToken cancellationToken)
        {
            AttributeOption? attributeOption = await _attributeOptionRepository.GetAsync(predicate: ao => ao.Id == request.Id, cancellationToken: cancellationToken);
            await _attributeOptionBusinessRules.AttributeOptionShouldExistWhenSelected(attributeOption);
            attributeOption = _mapper.Map(request, attributeOption);

            await _attributeOptionRepository.UpdateAsync(attributeOption!);

            UpdatedAttributeOptionResponse response = _mapper.Map<UpdatedAttributeOptionResponse>(attributeOption);

          return CustomResponseDto<UpdatedAttributeOptionResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}