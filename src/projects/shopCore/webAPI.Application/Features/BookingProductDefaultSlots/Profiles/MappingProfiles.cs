using Application.Features.BookingProductDefaultSlots.Commands.Create;
using Application.Features.BookingProductDefaultSlots.Commands.Delete;
using Application.Features.BookingProductDefaultSlots.Commands.Update;
using Application.Features.BookingProductDefaultSlots.Queries.GetById;
using Application.Features.BookingProductDefaultSlots.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.BookingProductDefaultSlots.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<BookingProductDefaultSlot, CreateBookingProductDefaultSlotCommand>().ReverseMap();
        CreateMap<BookingProductDefaultSlot, CreatedBookingProductDefaultSlotResponse>().ReverseMap();
        CreateMap<BookingProductDefaultSlot, UpdateBookingProductDefaultSlotCommand>().ReverseMap();
        CreateMap<BookingProductDefaultSlot, UpdatedBookingProductDefaultSlotResponse>().ReverseMap();
        CreateMap<BookingProductDefaultSlot, DeleteBookingProductDefaultSlotCommand>().ReverseMap();
        CreateMap<BookingProductDefaultSlot, DeletedBookingProductDefaultSlotResponse>().ReverseMap();
        CreateMap<BookingProductDefaultSlot, GetByIdBookingProductDefaultSlotResponse>().ReverseMap();
        CreateMap<BookingProductDefaultSlot, GetListBookingProductDefaultSlotListItemDto>().ReverseMap();
        CreateMap<IPaginate<BookingProductDefaultSlot>, GetListResponse<GetListBookingProductDefaultSlotListItemDto>>().ReverseMap();
    }
}