using Application.Features.BookingProducts.Commands.Create;
using Application.Features.BookingProducts.Commands.Delete;
using Application.Features.BookingProducts.Commands.Update;
using Application.Features.BookingProducts.Queries.GetById;
using Application.Features.BookingProducts.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.BookingProducts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<BookingProduct, CreateBookingProductCommand>().ReverseMap();
        CreateMap<BookingProduct, CreatedBookingProductResponse>().ReverseMap();
        CreateMap<BookingProduct, UpdateBookingProductCommand>().ReverseMap();
        CreateMap<BookingProduct, UpdatedBookingProductResponse>().ReverseMap();
        CreateMap<BookingProduct, DeleteBookingProductCommand>().ReverseMap();
        CreateMap<BookingProduct, DeletedBookingProductResponse>().ReverseMap();
        CreateMap<BookingProduct, GetByIdBookingProductResponse>().ReverseMap();
        CreateMap<BookingProduct, GetListBookingProductListItemDto>().ReverseMap();
        CreateMap<IPaginate<BookingProduct>, GetListResponse<GetListBookingProductListItemDto>>().ReverseMap();
    }
}