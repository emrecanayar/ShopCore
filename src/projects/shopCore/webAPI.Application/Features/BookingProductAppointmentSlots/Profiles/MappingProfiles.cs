using Application.Features.BookingProductAppointmentSlots.Commands.Create;
using Application.Features.BookingProductAppointmentSlots.Commands.Delete;
using Application.Features.BookingProductAppointmentSlots.Commands.Update;
using Application.Features.BookingProductAppointmentSlots.Queries.GetById;
using Application.Features.BookingProductAppointmentSlots.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.BookingProductAppointmentSlots.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<BookingProductAppointmentSlot, CreateBookingProductAppointmentSlotCommand>().ReverseMap();
        CreateMap<BookingProductAppointmentSlot, CreatedBookingProductAppointmentSlotResponse>().ReverseMap();
        CreateMap<BookingProductAppointmentSlot, UpdateBookingProductAppointmentSlotCommand>().ReverseMap();
        CreateMap<BookingProductAppointmentSlot, UpdatedBookingProductAppointmentSlotResponse>().ReverseMap();
        CreateMap<BookingProductAppointmentSlot, DeleteBookingProductAppointmentSlotCommand>().ReverseMap();
        CreateMap<BookingProductAppointmentSlot, DeletedBookingProductAppointmentSlotResponse>().ReverseMap();
        CreateMap<BookingProductAppointmentSlot, GetByIdBookingProductAppointmentSlotResponse>().ReverseMap();
        CreateMap<BookingProductAppointmentSlot, GetListBookingProductAppointmentSlotListItemDto>().ReverseMap();
        CreateMap<IPaginate<BookingProductAppointmentSlot>, GetListResponse<GetListBookingProductAppointmentSlotListItemDto>>().ReverseMap();
    }
}