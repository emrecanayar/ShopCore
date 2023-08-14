using Application.Features.CartRuleCustomers.Commands.Create;
using Application.Features.CartRuleCustomers.Commands.Delete;
using Application.Features.CartRuleCustomers.Commands.Update;
using Application.Features.CartRuleCustomers.Queries.GetById;
using Application.Features.CartRuleCustomers.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CartRuleCustomers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CartRuleCustomer, CreateCartRuleCustomerCommand>().ReverseMap();
        CreateMap<CartRuleCustomer, CreatedCartRuleCustomerResponse>().ReverseMap();
        CreateMap<CartRuleCustomer, UpdateCartRuleCustomerCommand>().ReverseMap();
        CreateMap<CartRuleCustomer, UpdatedCartRuleCustomerResponse>().ReverseMap();
        CreateMap<CartRuleCustomer, DeleteCartRuleCustomerCommand>().ReverseMap();
        CreateMap<CartRuleCustomer, DeletedCartRuleCustomerResponse>().ReverseMap();
        CreateMap<CartRuleCustomer, GetByIdCartRuleCustomerResponse>().ReverseMap();
        CreateMap<CartRuleCustomer, GetListCartRuleCustomerListItemDto>().ReverseMap();
        CreateMap<IPaginate<CartRuleCustomer>, GetListResponse<GetListCartRuleCustomerListItemDto>>().ReverseMap();
    }
}