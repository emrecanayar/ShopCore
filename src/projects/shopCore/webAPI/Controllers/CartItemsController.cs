using Application.Features.CartItems.Commands.Create;
using Application.Features.CartItems.Commands.Delete;
using Application.Features.CartItems.Commands.Update;
using Application.Features.CartItems.Queries.GetById;
using Application.Features.CartItems.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Core.Application.ResponseTypes.Concrete;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartItemsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCartItemCommand createCartItemCommand)
    {
        CustomResponseDto<CreatedCartItemResponse> response = await Mediator.Send(createCartItemCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCartItemCommand updateCartItemCommand)
    {
        CustomResponseDto<UpdatedCartItemResponse> response = await Mediator.Send(updateCartItemCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] uint id)
    {
        CustomResponseDto<DeletedCartItemResponse> response = await Mediator.Send(new DeleteCartItemCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] uint id)
    {
        CustomResponseDto<GetByIdCartItemResponse> response = await Mediator.Send(new GetByIdCartItemQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCartItemQuery getListCartItemQuery = new() { PageRequest = pageRequest };
       CustomResponseDto<GetListResponse<GetListCartItemListItemDto>> response = await Mediator.Send(getListCartItemQuery);
        return Ok(response);
    }
}