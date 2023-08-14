using Application.Features.Carts.Commands.Create;
using Application.Features.Carts.Commands.Delete;
using Application.Features.Carts.Commands.Update;
using Application.Features.Carts.Queries.GetById;
using Application.Features.Carts.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Carts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Cart, CreateCartCommand>().ReverseMap();
        CreateMap<Cart, CreatedCartResponse>().ReverseMap();
        CreateMap<Cart, UpdateCartCommand>().ReverseMap();
        CreateMap<Cart, UpdatedCartResponse>().ReverseMap();
        CreateMap<Cart, DeleteCartCommand>().ReverseMap();
        CreateMap<Cart, DeletedCartResponse>().ReverseMap();
        CreateMap<Cart, GetByIdCartResponse>().ReverseMap();
        CreateMap<Cart, GetListCartListItemDto>().ReverseMap();
        CreateMap<IPaginate<Cart>, GetListResponse<GetListCartListItemDto>>().ReverseMap();
    }
}