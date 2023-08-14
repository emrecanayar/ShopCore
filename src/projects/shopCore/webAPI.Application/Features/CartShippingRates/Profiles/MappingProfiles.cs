using Application.Features.CartShippingRates.Commands.Create;
using Application.Features.CartShippingRates.Commands.Delete;
using Application.Features.CartShippingRates.Commands.Update;
using Application.Features.CartShippingRates.Queries.GetById;
using Application.Features.CartShippingRates.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CartShippingRates.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CartShippingRate, CreateCartShippingRateCommand>().ReverseMap();
        CreateMap<CartShippingRate, CreatedCartShippingRateResponse>().ReverseMap();
        CreateMap<CartShippingRate, UpdateCartShippingRateCommand>().ReverseMap();
        CreateMap<CartShippingRate, UpdatedCartShippingRateResponse>().ReverseMap();
        CreateMap<CartShippingRate, DeleteCartShippingRateCommand>().ReverseMap();
        CreateMap<CartShippingRate, DeletedCartShippingRateResponse>().ReverseMap();
        CreateMap<CartShippingRate, GetByIdCartShippingRateResponse>().ReverseMap();
        CreateMap<CartShippingRate, GetListCartShippingRateListItemDto>().ReverseMap();
        CreateMap<IPaginate<CartShippingRate>, GetListResponse<GetListCartShippingRateListItemDto>>().ReverseMap();
    }
}