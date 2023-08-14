using Application.Features.CartRuleCustomers.Commands.Create;
using Application.Features.CartRuleCustomers.Commands.Delete;
using Application.Features.CartRuleCustomers.Commands.Update;
using Application.Features.CartRuleCustomers.Queries.GetById;
using Application.Features.CartRuleCustomers.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Core.Application.ResponseTypes.Concrete;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartRuleCustomersController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCartRuleCustomerCommand createCartRuleCustomerCommand)
    {
        CustomResponseDto<CreatedCartRuleCustomerResponse> response = await Mediator.Send(createCartRuleCustomerCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCartRuleCustomerCommand updateCartRuleCustomerCommand)
    {
        CustomResponseDto<UpdatedCartRuleCustomerResponse> response = await Mediator.Send(updateCartRuleCustomerCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] uint id)
    {
        CustomResponseDto<DeletedCartRuleCustomerResponse> response = await Mediator.Send(new DeleteCartRuleCustomerCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] uint id)
    {
        CustomResponseDto<GetByIdCartRuleCustomerResponse> response = await Mediator.Send(new GetByIdCartRuleCustomerQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCartRuleCustomerQuery getListCartRuleCustomerQuery = new() { PageRequest = pageRequest };
       CustomResponseDto<GetListResponse<GetListCartRuleCustomerListItemDto>> response = await Mediator.Send(getListCartRuleCustomerQuery);
        return Ok(response);
    }
}