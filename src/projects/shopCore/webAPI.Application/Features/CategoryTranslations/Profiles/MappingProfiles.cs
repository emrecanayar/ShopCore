using Application.Features.CategoryTranslations.Commands.Create;
using Application.Features.CategoryTranslations.Commands.Delete;
using Application.Features.CategoryTranslations.Commands.Update;
using Application.Features.CategoryTranslations.Queries.GetById;
using Application.Features.CategoryTranslations.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CategoryTranslations.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CategoryTranslation, CreateCategoryTranslationCommand>().ReverseMap();
        CreateMap<CategoryTranslation, CreatedCategoryTranslationResponse>().ReverseMap();
        CreateMap<CategoryTranslation, UpdateCategoryTranslationCommand>().ReverseMap();
        CreateMap<CategoryTranslation, UpdatedCategoryTranslationResponse>().ReverseMap();
        CreateMap<CategoryTranslation, DeleteCategoryTranslationCommand>().ReverseMap();
        CreateMap<CategoryTranslation, DeletedCategoryTranslationResponse>().ReverseMap();
        CreateMap<CategoryTranslation, GetByIdCategoryTranslationResponse>().ReverseMap();
        CreateMap<CategoryTranslation, GetListCategoryTranslationListItemDto>().ReverseMap();
        CreateMap<IPaginate<CategoryTranslation>, GetListResponse<GetListCategoryTranslationListItemDto>>().ReverseMap();
    }
}