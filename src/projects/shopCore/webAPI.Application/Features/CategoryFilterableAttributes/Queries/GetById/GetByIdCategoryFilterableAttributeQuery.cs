using Application.Features.CategoryFilterableAttributes.Constants;
using Application.Features.CategoryFilterableAttributes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CategoryFilterableAttributes.Constants.CategoryFilterableAttributesOperationClaims;

namespace Application.Features.CategoryFilterableAttributes.Queries.GetById;

public class GetByIdCategoryFilterableAttributeQuery : IRequest<CustomResponseDto<GetByIdCategoryFilterableAttributeResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCategoryFilterableAttributeQueryHandler : IRequestHandler<GetByIdCategoryFilterableAttributeQuery, CustomResponseDto<GetByIdCategoryFilterableAttributeResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryFilterableAttributeRepository _categoryFilterableAttributeRepository;
        private readonly CategoryFilterableAttributeBusinessRules _categoryFilterableAttributeBusinessRules;

        public GetByIdCategoryFilterableAttributeQueryHandler(IMapper mapper, ICategoryFilterableAttributeRepository categoryFilterableAttributeRepository, CategoryFilterableAttributeBusinessRules categoryFilterableAttributeBusinessRules)
        {
            _mapper = mapper;
            _categoryFilterableAttributeRepository = categoryFilterableAttributeRepository;
            _categoryFilterableAttributeBusinessRules = categoryFilterableAttributeBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdCategoryFilterableAttributeResponse>> Handle(GetByIdCategoryFilterableAttributeQuery request, CancellationToken cancellationToken)
        {
            CategoryFilterableAttribute? categoryFilterableAttribute = await _categoryFilterableAttributeRepository.GetAsync(predicate: cfa => cfa.Id == request.Id, cancellationToken: cancellationToken);
            await _categoryFilterableAttributeBusinessRules.CategoryFilterableAttributeShouldExistWhenSelected(categoryFilterableAttribute);

            GetByIdCategoryFilterableAttributeResponse response = _mapper.Map<GetByIdCategoryFilterableAttributeResponse>(categoryFilterableAttribute);

          return CustomResponseDto<GetByIdCategoryFilterableAttributeResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}