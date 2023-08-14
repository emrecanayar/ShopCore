using Application.Features.AttributeGroups.Commands.Create;
using Application.Features.AttributeGroups.Commands.Delete;
using Application.Features.AttributeGroups.Commands.Update;
using Application.Features.AttributeGroups.Queries.GetById;
using Application.Features.AttributeGroups.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.AttributeGroups.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AttributeGroup, CreateAttributeGroupCommand>().ReverseMap();
        CreateMap<AttributeGroup, CreatedAttributeGroupResponse>().ReverseMap();
        CreateMap<AttributeGroup, UpdateAttributeGroupCommand>().ReverseMap();
        CreateMap<AttributeGroup, UpdatedAttributeGroupResponse>().ReverseMap();
        CreateMap<AttributeGroup, DeleteAttributeGroupCommand>().ReverseMap();
        CreateMap<AttributeGroup, DeletedAttributeGroupResponse>().ReverseMap();
        CreateMap<AttributeGroup, GetByIdAttributeGroupResponse>().ReverseMap();
        CreateMap<AttributeGroup, GetListAttributeGroupListItemDto>().ReverseMap();
        CreateMap<IPaginate<AttributeGroup>, GetListResponse<GetListAttributeGroupListItemDto>>().ReverseMap();
    }
}