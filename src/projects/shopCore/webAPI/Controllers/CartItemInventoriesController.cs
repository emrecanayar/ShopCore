using Application.Features.CartItemInventories.Commands.Create;
using Application.Features.CartItemInventories.Commands.Delete;
using Application.Features.CartItemInventories.Commands.Update;
using Application.Features.CartItemInventories.Queries.GetById;
using Application.Features.CartItemInventories.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Core.Application.ResponseTypes.Concrete;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartItemInventoriesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCartItemInventoryCommand createCartItemInventoryCommand)
    {
        CustomResponseDto<CreatedCartItemInventoryResponse> response = await Mediator.Send(createCartItemInventoryCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCartItemInventoryCommand updateCartItemInventoryCommand)
    {
        CustomResponseDto<UpdatedCartItemInventoryResponse> response = await Mediator.Send(updateCartItemInventoryCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] uint id)
    {
        CustomResponseDto<DeletedCartItemInventoryResponse> response = await Mediator.Send(new DeleteCartItemInventoryCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] uint id)
    {
        CustomResponseDto<GetByIdCartItemInventoryResponse> response = await Mediator.Send(new GetByIdCartItemInventoryQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCartItemInventoryQuery getListCartItemInventoryQuery = new() { PageRequest = pageRequest };
       CustomResponseDto<GetListResponse<GetListCartItemInventoryListItemDto>> response = await Mediator.Send(getListCartItemInventoryQuery);
        return Ok(response);
    }
}