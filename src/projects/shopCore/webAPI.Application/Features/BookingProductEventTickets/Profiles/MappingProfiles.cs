using Application.Features.BookingProductEventTickets.Commands.Create;
using Application.Features.BookingProductEventTickets.Commands.Delete;
using Application.Features.BookingProductEventTickets.Commands.Update;
using Application.Features.BookingProductEventTickets.Queries.GetById;
using Application.Features.BookingProductEventTickets.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.BookingProductEventTickets.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<BookingProductEventTicket, CreateBookingProductEventTicketCommand>().ReverseMap();
        CreateMap<BookingProductEventTicket, CreatedBookingProductEventTicketResponse>().ReverseMap();
        CreateMap<BookingProductEventTicket, UpdateBookingProductEventTicketCommand>().ReverseMap();
        CreateMap<BookingProductEventTicket, UpdatedBookingProductEventTicketResponse>().ReverseMap();
        CreateMap<BookingProductEventTicket, DeleteBookingProductEventTicketCommand>().ReverseMap();
        CreateMap<BookingProductEventTicket, DeletedBookingProductEventTicketResponse>().ReverseMap();
        CreateMap<BookingProductEventTicket, GetByIdBookingProductEventTicketResponse>().ReverseMap();
        CreateMap<BookingProductEventTicket, GetListBookingProductEventTicketListItemDto>().ReverseMap();
        CreateMap<IPaginate<BookingProductEventTicket>, GetListResponse<GetListBookingProductEventTicketListItemDto>>().ReverseMap();
    }
}