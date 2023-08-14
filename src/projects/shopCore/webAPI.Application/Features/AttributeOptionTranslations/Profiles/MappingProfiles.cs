using Application.Features.AttributeOptionTranslations.Commands.Create;
using Application.Features.AttributeOptionTranslations.Commands.Delete;
using Application.Features.AttributeOptionTranslations.Commands.Update;
using Application.Features.AttributeOptionTranslations.Queries.GetById;
using Application.Features.AttributeOptionTranslations.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.AttributeOptionTranslations.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AttributeOptionTranslation, CreateAttributeOptionTranslationCommand>().ReverseMap();
        CreateMap<AttributeOptionTranslation, CreatedAttributeOptionTranslationResponse>().ReverseMap();
        CreateMap<AttributeOptionTranslation, UpdateAttributeOptionTranslationCommand>().ReverseMap();
        CreateMap<AttributeOptionTranslation, UpdatedAttributeOptionTranslationResponse>().ReverseMap();
        CreateMap<AttributeOptionTranslation, DeleteAttributeOptionTranslationCommand>().ReverseMap();
        CreateMap<AttributeOptionTranslation, DeletedAttributeOptionTranslationResponse>().ReverseMap();
        CreateMap<AttributeOptionTranslation, GetByIdAttributeOptionTranslationResponse>().ReverseMap();
        CreateMap<AttributeOptionTranslation, GetListAttributeOptionTranslationListItemDto>().ReverseMap();
        CreateMap<IPaginate<AttributeOptionTranslation>, GetListResponse<GetListAttributeOptionTranslationListItemDto>>().ReverseMap();
    }
}