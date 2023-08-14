using Application.Features.CategoryFilterableAttributes.Commands.Create;
using Application.Features.CategoryFilterableAttributes.Commands.Delete;
using Application.Features.CategoryFilterableAttributes.Commands.Update;
using Application.Features.CategoryFilterableAttributes.Queries.GetById;
using Application.Features.CategoryFilterableAttributes.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CategoryFilterableAttributes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CategoryFilterableAttribute, CreateCategoryFilterableAttributeCommand>().ReverseMap();
        CreateMap<CategoryFilterableAttribute, CreatedCategoryFilterableAttributeResponse>().ReverseMap();
        CreateMap<CategoryFilterableAttribute, UpdateCategoryFilterableAttributeCommand>().ReverseMap();
        CreateMap<CategoryFilterableAttribute, UpdatedCategoryFilterableAttributeResponse>().ReverseMap();
        CreateMap<CategoryFilterableAttribute, DeleteCategoryFilterableAttributeCommand>().ReverseMap();
        CreateMap<CategoryFilterableAttribute, DeletedCategoryFilterableAttributeResponse>().ReverseMap();
        CreateMap<CategoryFilterableAttribute, GetByIdCategoryFilterableAttributeResponse>().ReverseMap();
        CreateMap<CategoryFilterableAttribute, GetListCategoryFilterableAttributeListItemDto>().ReverseMap();
        CreateMap<IPaginate<CategoryFilterableAttribute>, GetListResponse<GetListCategoryFilterableAttributeListItemDto>>().ReverseMap();
    }
}