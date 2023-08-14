using Application.Features.Attributes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.ResponseTypes.Concrete;
using MediatR;
using System.Net;
using static Application.Features.Attributes.Constants.AttributesOperationClaims;

namespace Application.Features.Attributes.Queries.GetById;

public class GetByIdAttributeQuery : IRequest<CustomResponseDto<GetByIdAttributeResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdAttributeQueryHandler : IRequestHandler<GetByIdAttributeQuery, CustomResponseDto<GetByIdAttributeResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IAttributeRepository _attributeRepository;
        private readonly AttributeBusinessRules _attributeBusinessRules;

        public GetByIdAttributeQueryHandler(IMapper mapper, IAttributeRepository attributeRepository, AttributeBusinessRules attributeBusinessRules)
        {
            _mapper = mapper;
            _attributeRepository = attributeRepository;
            _attributeBusinessRules = attributeBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdAttributeResponse>> Handle(GetByIdAttributeQuery request, CancellationToken cancellationToken)
        {
            Core.Domain.Entities.Attribute? attribute = await _attributeRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _attributeBusinessRules.AttributeShouldExistWhenSelected(attribute);

            GetByIdAttributeResponse response = _mapper.Map<GetByIdAttributeResponse>(attribute);

            return CustomResponseDto<GetByIdAttributeResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}