using Application.Features.AttributeFamilies.Constants;
using Application.Features.AttributeFamilies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.AttributeFamilies.Constants.AttributeFamiliesOperationClaims;

namespace Application.Features.AttributeFamilies.Commands.Update;

public class UpdateAttributeFamilyCommand : IRequest<CustomResponseDto<UpdatedAttributeFamilyResponse>>, ISecuredRequest
{
    public uint Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public bool Status { get; set; }
    public bool? IsUserDefined { get; set; }

    public string[] Roles => new[] { Admin, Write, AttributeFamiliesOperationClaims.Update };

    public class UpdateAttributeFamilyCommandHandler : IRequestHandler<UpdateAttributeFamilyCommand, CustomResponseDto<UpdatedAttributeFamilyResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IAttributeFamilyRepository _attributeFamilyRepository;
        private readonly AttributeFamilyBusinessRules _attributeFamilyBusinessRules;

        public UpdateAttributeFamilyCommandHandler(IMapper mapper, IAttributeFamilyRepository attributeFamilyRepository,
                                         AttributeFamilyBusinessRules attributeFamilyBusinessRules)
        {
            _mapper = mapper;
            _attributeFamilyRepository = attributeFamilyRepository;
            _attributeFamilyBusinessRules = attributeFamilyBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedAttributeFamilyResponse>> Handle(UpdateAttributeFamilyCommand request, CancellationToken cancellationToken)
        {
            AttributeFamily? attributeFamily = await _attributeFamilyRepository.GetAsync(predicate: af => af.Id == request.Id, cancellationToken: cancellationToken);
            await _attributeFamilyBusinessRules.AttributeFamilyShouldExistWhenSelected(attributeFamily);
            attributeFamily = _mapper.Map(request, attributeFamily);

            await _attributeFamilyRepository.UpdateAsync(attributeFamily!);

            UpdatedAttributeFamilyResponse response = _mapper.Map<UpdatedAttributeFamilyResponse>(attributeFamily);

          return CustomResponseDto<UpdatedAttributeFamilyResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}