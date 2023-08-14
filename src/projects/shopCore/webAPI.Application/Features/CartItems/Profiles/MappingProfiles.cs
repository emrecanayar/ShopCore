using Application.Features.CartItems.Commands.Create;
using Application.Features.CartItems.Commands.Delete;
using Application.Features.CartItems.Commands.Update;
using Application.Features.CartItems.Queries.GetById;
using Application.Features.CartItems.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CartItems.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CartItem, CreateCartItemCommand>().ReverseMap();
        CreateMap<CartItem, CreatedCartItemResponse>().ReverseMap();
        CreateMap<CartItem, UpdateCartItemCommand>().ReverseMap();
        CreateMap<CartItem, UpdatedCartItemResponse>().ReverseMap();
        CreateMap<CartItem, DeleteCartItemCommand>().ReverseMap();
        CreateMap<CartItem, DeletedCartItemResponse>().ReverseMap();
        CreateMap<CartItem, GetByIdCartItemResponse>().ReverseMap();
        CreateMap<CartItem, GetListCartItemListItemDto>().ReverseMap();
        CreateMap<IPaginate<CartItem>, GetListResponse<GetListCartItemListItemDto>>().ReverseMap();
    }
}