using Application.Features.AttributeGroupMappings.Commands.Create;
using Application.Features.AttributeGroupMappings.Commands.Delete;
using Application.Features.AttributeGroupMappings.Commands.Update;
using Application.Features.AttributeGroupMappings.Queries.GetById;
using Application.Features.AttributeGroupMappings.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.AttributeGroupMappings.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AttributeGroupMapping, CreateAttributeGroupMappingCommand>().ReverseMap();
        CreateMap<AttributeGroupMapping, CreatedAttributeGroupMappingResponse>().ReverseMap();
        CreateMap<AttributeGroupMapping, UpdateAttributeGroupMappingCommand>().ReverseMap();
        CreateMap<AttributeGroupMapping, UpdatedAttributeGroupMappingResponse>().ReverseMap();
        CreateMap<AttributeGroupMapping, DeleteAttributeGroupMappingCommand>().ReverseMap();
        CreateMap<AttributeGroupMapping, DeletedAttributeGroupMappingResponse>().ReverseMap();
        CreateMap<AttributeGroupMapping, GetByIdAttributeGroupMappingResponse>().ReverseMap();
        CreateMap<AttributeGroupMapping, GetListAttributeGroupMappingListItemDto>().ReverseMap();
        CreateMap<IPaginate<AttributeGroupMapping>, GetListResponse<GetListAttributeGroupMappingListItemDto>>().ReverseMap();
    }
}