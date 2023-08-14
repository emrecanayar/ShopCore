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

namespace Application.Features.AttributeOptions.Queries.GetById;

public class GetByIdAttributeOptionQuery : IRequest<CustomResponseDto<GetByIdAttributeOptionResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdAttributeOptionQueryHandler : IRequestHandler<GetByIdAttributeOptionQuery, CustomResponseDto<GetByIdAttributeOptionResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IAttributeOptionRepository _attributeOptionRepository;
        private readonly AttributeOptionBusinessRules _attributeOptionBusinessRules;

        public GetByIdAttributeOptionQueryHandler(IMapper mapper, IAttributeOptionRepository attributeOptionRepository, AttributeOptionBusinessRules attributeOptionBusinessRules)
        {
            _mapper = mapper;
            _attributeOptionRepository = attributeOptionRepository;
            _attributeOptionBusinessRules = attributeOptionBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdAttributeOptionResponse>> Handle(GetByIdAttributeOptionQuery request, CancellationToken cancellationToken)
        {
            AttributeOption? attributeOption = await _attributeOptionRepository.GetAsync(predicate: ao => ao.Id == request.Id, cancellationToken: cancellationToken);
            await _attributeOptionBusinessRules.AttributeOptionShouldExistWhenSelected(attributeOption);

            GetByIdAttributeOptionResponse response = _mapper.Map<GetByIdAttributeOptionResponse>(attributeOption);

          return CustomResponseDto<GetByIdAttributeOptionResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}