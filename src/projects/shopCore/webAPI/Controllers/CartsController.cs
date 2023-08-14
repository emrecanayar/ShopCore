using Application.Features.Carts.Commands.Create;
using Application.Features.Carts.Commands.Delete;
using Application.Features.Carts.Commands.Update;
using Application.Features.Carts.Queries.GetById;
using Application.Features.Carts.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Core.Application.ResponseTypes.Concrete;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCartCommand createCartCommand)
    {
        CustomResponseDto<CreatedCartResponse> response = await Mediator.Send(createCartCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCartCommand updateCartCommand)
    {
        CustomResponseDto<UpdatedCartResponse> response = await Mediator.Send(updateCartCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] uint id)
    {
        CustomResponseDto<DeletedCartResponse> response = await Mediator.Send(new DeleteCartCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] uint id)
    {
        CustomResponseDto<GetByIdCartResponse> response = await Mediator.Send(new GetByIdCartQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCartQuery getListCartQuery = new() { PageRequest = pageRequest };
       CustomResponseDto<GetListResponse<GetListCartListItemDto>> response = await Mediator.Send(getListCartQuery);
        return Ok(response);
    }
}