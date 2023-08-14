using Application.Features.CatalogRuleChannels.Commands.Create;
using Application.Features.CatalogRuleChannels.Commands.Delete;
using Application.Features.CatalogRuleChannels.Commands.Update;
using Application.Features.CatalogRuleChannels.Queries.GetById;
using Application.Features.CatalogRuleChannels.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CatalogRuleChannels.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CatalogRuleChannel, CreateCatalogRuleChannelCommand>().ReverseMap();
        CreateMap<CatalogRuleChannel, CreatedCatalogRuleChannelResponse>().ReverseMap();
        CreateMap<CatalogRuleChannel, UpdateCatalogRuleChannelCommand>().ReverseMap();
        CreateMap<CatalogRuleChannel, UpdatedCatalogRuleChannelResponse>().ReverseMap();
        CreateMap<CatalogRuleChannel, DeleteCatalogRuleChannelCommand>().ReverseMap();
        CreateMap<CatalogRuleChannel, DeletedCatalogRuleChannelResponse>().ReverseMap();
        CreateMap<CatalogRuleChannel, GetByIdCatalogRuleChannelResponse>().ReverseMap();
        CreateMap<CatalogRuleChannel, GetListCatalogRuleChannelListItemDto>().ReverseMap();
        CreateMap<IPaginate<CatalogRuleChannel>, GetListResponse<GetListCatalogRuleChannelListItemDto>>().ReverseMap();
    }
}