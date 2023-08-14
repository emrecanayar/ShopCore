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

namespace Application.Features.CategoryFilterableAttributes.Commands.Update;

public class UpdateCategoryFilterableAttributeCommand : IRequest<CustomResponseDto<UpdatedCategoryFilterableAttributeResponse>>, ISecuredRequest
{
    public uint Id { get; set; }
    public uint CategoryId { get; set; }
    public uint AttributeId { get; set; }

    public string[] Roles => new[] { Admin, Write, CategoryFilterableAttributesOperationClaims.Update };

    public class UpdateCategoryFilterableAttributeCommandHandler : IRequestHandler<UpdateCategoryFilterableAttributeCommand, CustomResponseDto<UpdatedCategoryFilterableAttributeResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryFilterableAttributeRepository _categoryFilterableAttributeRepository;
        private readonly CategoryFilterableAttributeBusinessRules _categoryFilterableAttributeBusinessRules;

        public UpdateCategoryFilterableAttributeCommandHandler(IMapper mapper, ICategoryFilterableAttributeRepository categoryFilterableAttributeRepository,
                                         CategoryFilterableAttributeBusinessRules categoryFilterableAttributeBusinessRules)
        {
            _mapper = mapper;
            _categoryFilterableAttributeRepository = categoryFilterableAttributeRepository;
            _categoryFilterableAttributeBusinessRules = categoryFilterableAttributeBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedCategoryFilterableAttributeResponse>> Handle(UpdateCategoryFilterableAttributeCommand request, CancellationToken cancellationToken)
        {
            CategoryFilterableAttribute? categoryFilterableAttribute = await _categoryFilterableAttributeRepository.GetAsync(predicate: cfa => cfa.Id == request.Id, cancellationToken: cancellationToken);
            await _categoryFilterableAttributeBusinessRules.CategoryFilterableAttributeShouldExistWhenSelected(categoryFilterableAttribute);
            categoryFilterableAttribute = _mapper.Map(request, categoryFilterableAttribute);

            await _categoryFilterableAttributeRepository.UpdateAsync(categoryFilterableAttribute!);

            UpdatedCategoryFilterableAttributeResponse response = _mapper.Map<UpdatedCategoryFilterableAttributeResponse>(categoryFilterableAttribute);

          return CustomResponseDto<UpdatedCategoryFilterableAttributeResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}