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

namespace Application.Features.CategoryFilterableAttributes.Commands.Create;

public class CreateCategoryFilterableAttributeCommand : IRequest<CustomResponseDto<CreatedCategoryFilterableAttributeResponse>>, ISecuredRequest
{
    public uint CategoryId { get; set; }
    public uint AttributeId { get; set; }

    public string[] Roles => new[] { Admin, Write, CategoryFilterableAttributesOperationClaims.Create };

    public class CreateCategoryFilterableAttributeCommandHandler : IRequestHandler<CreateCategoryFilterableAttributeCommand, CustomResponseDto<CreatedCategoryFilterableAttributeResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryFilterableAttributeRepository _categoryFilterableAttributeRepository;
        private readonly CategoryFilterableAttributeBusinessRules _categoryFilterableAttributeBusinessRules;

        public CreateCategoryFilterableAttributeCommandHandler(IMapper mapper, ICategoryFilterableAttributeRepository categoryFilterableAttributeRepository,
                                         CategoryFilterableAttributeBusinessRules categoryFilterableAttributeBusinessRules)
        {
            _mapper = mapper;
            _categoryFilterableAttributeRepository = categoryFilterableAttributeRepository;
            _categoryFilterableAttributeBusinessRules = categoryFilterableAttributeBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedCategoryFilterableAttributeResponse>> Handle(CreateCategoryFilterableAttributeCommand request, CancellationToken cancellationToken)
        {
            CategoryFilterableAttribute categoryFilterableAttribute = _mapper.Map<CategoryFilterableAttribute>(request);

            await _categoryFilterableAttributeRepository.AddAsync(categoryFilterableAttribute);

            CreatedCategoryFilterableAttributeResponse response = _mapper.Map<CreatedCategoryFilterableAttributeResponse>(categoryFilterableAttribute);
         return CustomResponseDto<CreatedCategoryFilterableAttributeResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}