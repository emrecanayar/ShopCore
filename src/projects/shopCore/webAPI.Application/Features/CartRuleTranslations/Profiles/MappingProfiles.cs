using Application.Features.CartRuleTranslations.Commands.Create;
using Application.Features.CartRuleTranslations.Commands.Delete;
using Application.Features.CartRuleTranslations.Commands.Update;
using Application.Features.CartRuleTranslations.Queries.GetById;
using Application.Features.CartRuleTranslations.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CartRuleTranslations.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CartRuleTranslation, CreateCartRuleTranslationCommand>().ReverseMap();
        CreateMap<CartRuleTranslation, CreatedCartRuleTranslationResponse>().ReverseMap();
        CreateMap<CartRuleTranslation, UpdateCartRuleTranslationCommand>().ReverseMap();
        CreateMap<CartRuleTranslation, UpdatedCartRuleTranslationResponse>().ReverseMap();
        CreateMap<CartRuleTranslation, DeleteCartRuleTranslationCommand>().ReverseMap();
        CreateMap<CartRuleTranslation, DeletedCartRuleTranslationResponse>().ReverseMap();
        CreateMap<CartRuleTranslation, GetByIdCartRuleTranslationResponse>().ReverseMap();
        CreateMap<CartRuleTranslation, GetListCartRuleTranslationListItemDto>().ReverseMap();
        CreateMap<IPaginate<CartRuleTranslation>, GetListResponse<GetListCartRuleTranslationListItemDto>>().ReverseMap();
    }
}