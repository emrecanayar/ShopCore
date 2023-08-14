using Application.Features.AttributeOptions.Constants;
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

namespace Application.Features.AttributeOptions.Commands.Delete;

public class DeleteAttributeOptionCommand : IRequest<CustomResponseDto<DeletedAttributeOptionResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Write, AttributeOptionsOperationClaims.Delete };

    public class DeleteAttributeOptionCommandHandler : IRequestHandler<DeleteAttributeOptionCommand, CustomResponseDto<DeletedAttributeOptionResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IAttributeOptionRepository _attributeOptionRepository;
        private readonly AttributeOptionBusinessRules _attributeOptionBusinessRules;

        public DeleteAttributeOptionCommandHandler(IMapper mapper, IAttributeOptionRepository attributeOptionRepository,
                                         AttributeOptionBusinessRules attributeOptionBusinessRules)
        {
            _mapper = mapper;
            _attributeOptionRepository = attributeOptionRepository;
            _attributeOptionBusinessRules = attributeOptionBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedAttributeOptionResponse>> Handle(DeleteAttributeOptionCommand request, CancellationToken cancellationToken)
        {
            AttributeOption? attributeOption = await _attributeOptionRepository.GetAsync(predicate: ao => ao.Id == request.Id, cancellationToken: cancellationToken);
            await _attributeOptionBusinessRules.AttributeOptionShouldExistWhenSelected(attributeOption);

            await _attributeOptionRepository.DeleteAsync(attributeOption!);

            DeletedAttributeOptionResponse response = _mapper.Map<DeletedAttributeOptionResponse>(attributeOption);

             return CustomResponseDto<DeletedAttributeOptionResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}