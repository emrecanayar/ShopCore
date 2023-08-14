using Application.Features.AttributeOptions.Commands.Create;
using Application.Features.AttributeOptions.Commands.Delete;
using Application.Features.AttributeOptions.Commands.Update;
using Application.Features.AttributeOptions.Queries.GetById;
using Application.Features.AttributeOptions.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.AttributeOptions.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AttributeOption, CreateAttributeOptionCommand>().ReverseMap();
        CreateMap<AttributeOption, CreatedAttributeOptionResponse>().ReverseMap();
        CreateMap<AttributeOption, UpdateAttributeOptionCommand>().ReverseMap();
        CreateMap<AttributeOption, UpdatedAttributeOptionResponse>().ReverseMap();
        CreateMap<AttributeOption, DeleteAttributeOptionCommand>().ReverseMap();
        CreateMap<AttributeOption, DeletedAttributeOptionResponse>().ReverseMap();
        CreateMap<AttributeOption, GetByIdAttributeOptionResponse>().ReverseMap();
        CreateMap<AttributeOption, GetListAttributeOptionListItemDto>().ReverseMap();
        CreateMap<IPaginate<AttributeOption>, GetListResponse<GetListAttributeOptionListItemDto>>().ReverseMap();
    }
}