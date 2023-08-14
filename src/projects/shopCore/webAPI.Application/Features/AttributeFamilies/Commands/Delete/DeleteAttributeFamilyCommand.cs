using Application.Features.AttributeFamilies.Constants;
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

namespace Application.Features.AttributeFamilies.Commands.Delete;

public class DeleteAttributeFamilyCommand : IRequest<CustomResponseDto<DeletedAttributeFamilyResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Write, AttributeFamiliesOperationClaims.Delete };

    public class DeleteAttributeFamilyCommandHandler : IRequestHandler<DeleteAttributeFamilyCommand, CustomResponseDto<DeletedAttributeFamilyResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IAttributeFamilyRepository _attributeFamilyRepository;
        private readonly AttributeFamilyBusinessRules _attributeFamilyBusinessRules;

        public DeleteAttributeFamilyCommandHandler(IMapper mapper, IAttributeFamilyRepository attributeFamilyRepository,
                                         AttributeFamilyBusinessRules attributeFamilyBusinessRules)
        {
            _mapper = mapper;
            _attributeFamilyRepository = attributeFamilyRepository;
            _attributeFamilyBusinessRules = attributeFamilyBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedAttributeFamilyResponse>> Handle(DeleteAttributeFamilyCommand request, CancellationToken cancellationToken)
        {
            AttributeFamily? attributeFamily = await _attributeFamilyRepository.GetAsync(predicate: af => af.Id == request.Id, cancellationToken: cancellationToken);
            await _attributeFamilyBusinessRules.AttributeFamilyShouldExistWhenSelected(attributeFamily);

            await _attributeFamilyRepository.DeleteAsync(attributeFamily!);

            DeletedAttributeFamilyResponse response = _mapper.Map<DeletedAttributeFamilyResponse>(attributeFamily);

             return CustomResponseDto<DeletedAttributeFamilyResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}