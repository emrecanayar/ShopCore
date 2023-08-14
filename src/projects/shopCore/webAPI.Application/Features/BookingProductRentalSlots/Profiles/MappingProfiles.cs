using Application.Features.BookingProductRentalSlots.Commands.Create;
using Application.Features.BookingProductRentalSlots.Commands.Delete;
using Application.Features.BookingProductRentalSlots.Commands.Update;
using Application.Features.BookingProductRentalSlots.Queries.GetById;
using Application.Features.BookingProductRentalSlots.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.BookingProductRentalSlots.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<BookingProductRentalSlot, CreateBookingProductRentalSlotCommand>().ReverseMap();
        CreateMap<BookingProductRentalSlot, CreatedBookingProductRentalSlotResponse>().ReverseMap();
        CreateMap<BookingProductRentalSlot, UpdateBookingProductRentalSlotCommand>().ReverseMap();
        CreateMap<BookingProductRentalSlot, UpdatedBookingProductRentalSlotResponse>().ReverseMap();
        CreateMap<BookingProductRentalSlot, DeleteBookingProductRentalSlotCommand>().ReverseMap();
        CreateMap<BookingProductRentalSlot, DeletedBookingProductRentalSlotResponse>().ReverseMap();
        CreateMap<BookingProductRentalSlot, GetByIdBookingProductRentalSlotResponse>().ReverseMap();
        CreateMap<BookingProductRentalSlot, GetListBookingProductRentalSlotListItemDto>().ReverseMap();
        CreateMap<IPaginate<BookingProductRentalSlot>, GetListResponse<GetListBookingProductRentalSlotListItemDto>>().ReverseMap();
    }
}