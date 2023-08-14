using Application.Features.AttributeFamilies.Commands.Create;
using Application.Features.AttributeFamilies.Commands.Delete;
using Application.Features.AttributeFamilies.Commands.Update;
using Application.Features.AttributeFamilies.Queries.GetById;
using Application.Features.AttributeFamilies.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.AttributeFamilies.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AttributeFamily, CreateAttributeFamilyCommand>().ReverseMap();
        CreateMap<AttributeFamily, CreatedAttributeFamilyResponse>().ReverseMap();
        CreateMap<AttributeFamily, UpdateAttributeFamilyCommand>().ReverseMap();
        CreateMap<AttributeFamily, UpdatedAttributeFamilyResponse>().ReverseMap();
        CreateMap<AttributeFamily, DeleteAttributeFamilyCommand>().ReverseMap();
        CreateMap<AttributeFamily, DeletedAttributeFamilyResponse>().ReverseMap();
        CreateMap<AttributeFamily, GetByIdAttributeFamilyResponse>().ReverseMap();
        CreateMap<AttributeFamily, GetListAttributeFamilyListItemDto>().ReverseMap();
        CreateMap<IPaginate<AttributeFamily>, GetListResponse<GetListAttributeFamilyListItemDto>>().ReverseMap();
    }
}