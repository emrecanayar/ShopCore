using Application.Features.CategoryFilterableAttributes.Constants;
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

namespace Application.Features.CategoryFilterableAttributes.Commands.Delete;

public class DeleteCategoryFilterableAttributeCommand : IRequest<CustomResponseDto<DeletedCategoryFilterableAttributeResponse>>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CategoryFilterableAttributesOperationClaims.Delete };

    public class DeleteCategoryFilterableAttributeCommandHandler : IRequestHandler<DeleteCategoryFilterableAttributeCommand, CustomResponseDto<DeletedCategoryFilterableAttributeResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryFilterableAttributeRepository _categoryFilterableAttributeRepository;
        private readonly CategoryFilterableAttributeBusinessRules _categoryFilterableAttributeBusinessRules;

        public DeleteCategoryFilterableAttributeCommandHandler(IMapper mapper, ICategoryFilterableAttributeRepository categoryFilterableAttributeRepository,
                                         CategoryFilterableAttributeBusinessRules categoryFilterableAttributeBusinessRules)
        {
            _mapper = mapper;
            _categoryFilterableAttributeRepository = categoryFilterableAttributeRepository;
            _categoryFilterableAttributeBusinessRules = categoryFilterableAttributeBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedCategoryFilterableAttributeResponse>> Handle(DeleteCategoryFilterableAttributeCommand request, CancellationToken cancellationToken)
        {
            CategoryFilterableAttribute? categoryFilterableAttribute = await _categoryFilterableAttributeRepository.GetAsync(predicate: cfa => cfa.Id == request.Id, cancellationToken: cancellationToken);
            await _categoryFilterableAttributeBusinessRules.CategoryFilterableAttributeShouldExistWhenSelected(categoryFilterableAttribute);

            await _categoryFilterableAttributeRepository.DeleteAsync(categoryFilterableAttribute!);

            DeletedCategoryFilterableAttributeResponse response = _mapper.Map<DeletedCategoryFilterableAttributeResponse>(categoryFilterableAttribute);

             return CustomResponseDto<DeletedCategoryFilterableAttributeResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}