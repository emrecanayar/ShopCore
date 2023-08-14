using Application.Features.BookingProductEventTicketTranslations.Commands.Create;
using Application.Features.BookingProductEventTicketTranslations.Commands.Delete;
using Application.Features.BookingProductEventTicketTranslations.Commands.Update;
using Application.Features.BookingProductEventTicketTranslations.Queries.GetById;
using Application.Features.BookingProductEventTicketTranslations.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.BookingProductEventTicketTranslations.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<BookingProductEventTicketTranslation, CreateBookingProductEventTicketTranslationCommand>().ReverseMap();
        CreateMap<BookingProductEventTicketTranslation, CreatedBookingProductEventTicketTranslationResponse>().ReverseMap();
        CreateMap<BookingProductEventTicketTranslation, UpdateBookingProductEventTicketTranslationCommand>().ReverseMap();
        CreateMap<BookingProductEventTicketTranslation, UpdatedBookingProductEventTicketTranslationResponse>().ReverseMap();
        CreateMap<BookingProductEventTicketTranslation, DeleteBookingProductEventTicketTranslationCommand>().ReverseMap();
        CreateMap<BookingProductEventTicketTranslation, DeletedBookingProductEventTicketTranslationResponse>().ReverseMap();
        CreateMap<BookingProductEventTicketTranslation, GetByIdBookingProductEventTicketTranslationResponse>().ReverseMap();
        CreateMap<BookingProductEventTicketTranslation, GetListBookingProductEventTicketTranslationListItemDto>().ReverseMap();
        CreateMap<IPaginate<BookingProductEventTicketTranslation>, GetListResponse<GetListBookingProductEventTicketTranslationListItemDto>>().ReverseMap();
    }
}