using Application.Features.Attributes.Commands.Create;
using Application.Features.Attributes.Commands.Delete;
using Application.Features.Attributes.Commands.Update;
using Application.Features.Attributes.Queries.GetById;
using Application.Features.Attributes.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Attribute = Core.Domain.Entities.Attribute;

namespace Application.Features.Attributes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Attribute, CreateAttributeCommand>().ReverseMap();
        CreateMap<Attribute, CreatedAttributeResponse>().ReverseMap();
        CreateMap<Attribute, UpdateAttributeCommand>().ReverseMap();
        CreateMap<Attribute, UpdatedAttributeResponse>().ReverseMap();
        CreateMap<Attribute, DeleteAttributeCommand>().ReverseMap();
        CreateMap<Attribute, DeletedAttributeResponse>().ReverseMap();
        CreateMap<Attribute, GetByIdAttributeResponse>().ReverseMap();
        CreateMap<Attribute, GetListAttributeListItemDto>().ReverseMap();
        CreateMap<IPaginate<Attribute>, GetListResponse<GetListAttributeListItemDto>>().ReverseMap();
    }
}