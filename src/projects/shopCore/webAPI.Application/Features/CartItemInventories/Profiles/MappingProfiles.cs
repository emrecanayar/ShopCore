using Application.Features.CartItemInventories.Commands.Create;
using Application.Features.CartItemInventories.Commands.Delete;
using Application.Features.CartItemInventories.Commands.Update;
using Application.Features.CartItemInventories.Queries.GetById;
using Application.Features.CartItemInventories.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CartItemInventories.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CartItemInventory, CreateCartItemInventoryCommand>().ReverseMap();
        CreateMap<CartItemInventory, CreatedCartItemInventoryResponse>().ReverseMap();
        CreateMap<CartItemInventory, UpdateCartItemInventoryCommand>().ReverseMap();
        CreateMap<CartItemInventory, UpdatedCartItemInventoryResponse>().ReverseMap();
        CreateMap<CartItemInventory, DeleteCartItemInventoryCommand>().ReverseMap();
        CreateMap<CartItemInventory, DeletedCartItemInventoryResponse>().ReverseMap();
        CreateMap<CartItemInventory, GetByIdCartItemInventoryResponse>().ReverseMap();
        CreateMap<CartItemInventory, GetListCartItemInventoryListItemDto>().ReverseMap();
        CreateMap<IPaginate<CartItemInventory>, GetListResponse<GetListCartItemInventoryListItemDto>>().ReverseMap();
    }
}