using Application.Features.BookingProductTableSlots.Commands.Create;
using Application.Features.BookingProductTableSlots.Commands.Delete;
using Application.Features.BookingProductTableSlots.Commands.Update;
using Application.Features.BookingProductTableSlots.Queries.GetById;
using Application.Features.BookingProductTableSlots.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.BookingProductTableSlots.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<BookingProductTableSlot, CreateBookingProductTableSlotCommand>().ReverseMap();
        CreateMap<BookingProductTableSlot, CreatedBookingProductTableSlotResponse>().ReverseMap();
        CreateMap<BookingProductTableSlot, UpdateBookingProductTableSlotCommand>().ReverseMap();
        CreateMap<BookingProductTableSlot, UpdatedBookingProductTableSlotResponse>().ReverseMap();
        CreateMap<BookingProductTableSlot, DeleteBookingProductTableSlotCommand>().ReverseMap();
        CreateMap<BookingProductTableSlot, DeletedBookingProductTableSlotResponse>().ReverseMap();
        CreateMap<BookingProductTableSlot, GetByIdBookingProductTableSlotResponse>().ReverseMap();
        CreateMap<BookingProductTableSlot, GetListBookingProductTableSlotListItemDto>().ReverseMap();
        CreateMap<IPaginate<BookingProductTableSlot>, GetListResponse<GetListBookingProductTableSlotListItemDto>>().ReverseMap();
    }
}