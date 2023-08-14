using Application.Features.CartPayments.Commands.Create;
using Application.Features.CartPayments.Commands.Delete;
using Application.Features.CartPayments.Commands.Update;
using Application.Features.CartPayments.Queries.GetById;
using Application.Features.CartPayments.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CartPayments.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CartPayment, CreateCartPaymentCommand>().ReverseMap();
        CreateMap<CartPayment, CreatedCartPaymentResponse>().ReverseMap();
        CreateMap<CartPayment, UpdateCartPaymentCommand>().ReverseMap();
        CreateMap<CartPayment, UpdatedCartPaymentResponse>().ReverseMap();
        CreateMap<CartPayment, DeleteCartPaymentCommand>().ReverseMap();
        CreateMap<CartPayment, DeletedCartPaymentResponse>().ReverseMap();
        CreateMap<CartPayment, GetByIdCartPaymentResponse>().ReverseMap();
        CreateMap<CartPayment, GetListCartPaymentListItemDto>().ReverseMap();
        CreateMap<IPaginate<CartPayment>, GetListResponse<GetListCartPaymentListItemDto>>().ReverseMap();
    }
}