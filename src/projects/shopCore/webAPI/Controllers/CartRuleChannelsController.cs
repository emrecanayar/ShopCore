using Application.Features.CartRuleChannels.Commands.Create;
using Application.Features.CartRuleChannels.Commands.Delete;
using Application.Features.CartRuleChannels.Commands.Update;
using Application.Features.CartRuleChannels.Queries.GetById;
using Application.Features.CartRuleChannels.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Core.Application.ResponseTypes.Concrete;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartRuleChannelsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCartRuleChannelCommand createCartRuleChannelCommand)
    {
        CustomResponseDto<CreatedCartRuleChannelResponse> response = await Mediator.Send(createCartRuleChannelCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCartRuleChannelCommand updateCartRuleChannelCommand)
    {
        CustomResponseDto<UpdatedCartRuleChannelResponse> response = await Mediator.Send(updateCartRuleChannelCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] uint id)
    {
        CustomResponseDto<DeletedCartRuleChannelResponse> response = await Mediator.Send(new DeleteCartRuleChannelCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] uint id)
    {
        CustomResponseDto<GetByIdCartRuleChannelResponse> response = await Mediator.Send(new GetByIdCartRuleChannelQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCartRuleChannelQuery getListCartRuleChannelQuery = new() { PageRequest = pageRequest };
       CustomResponseDto<GetListResponse<GetListCartRuleChannelListItemDto>> response = await Mediator.Send(getListCartRuleChannelQuery);
        return Ok(response);
    }
}