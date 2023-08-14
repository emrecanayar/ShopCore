using Application.Features.Categories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Commands.Create;

public class CreateCategoryCommand : IRequest<CustomResponseDto<CreatedCategoryResponse>>
{
    public int Position { get; set; }
    public string? Image { get; set; }
    public bool Status { get; set; }
    public uint Lft { get; set; }
    public uint Rgt { get; set; }
    public uint? ParentId { get; set; }
    public string? DisplayMode { get; set; }
    public string? CategoryIconPath { get; set; }
    public string? Additional { get; set; }

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CustomResponseDto<CreatedCategoryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly CategoryBusinessRules _categoryBusinessRules;

        public CreateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository,
                                         CategoryBusinessRules categoryBusinessRules)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _categoryBusinessRules = categoryBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedCategoryResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = _mapper.Map<Category>(request);

            await _categoryRepository.AddAsync(category);

            CreatedCategoryResponse response = _mapper.Map<CreatedCategoryResponse>(category);
         return CustomResponseDto<CreatedCategoryResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}