using Application.Features.CartRules.Commands.Create;
using Application.Features.CartRules.Commands.Delete;
using Application.Features.CartRules.Commands.Update;
using Application.Features.CartRules.Queries.GetById;
using Application.Features.CartRules.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Core.Application.ResponseTypes.Concrete;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartRulesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCartRuleCommand createCartRuleCommand)
    {
        CustomResponseDto<CreatedCartRuleResponse> response = await Mediator.Send(createCartRuleCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCartRuleCommand updateCartRuleCommand)
    {
        CustomResponseDto<UpdatedCartRuleResponse> response = await Mediator.Send(updateCartRuleCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] uint id)
    {
        CustomResponseDto<DeletedCartRuleResponse> response = await Mediator.Send(new DeleteCartRuleCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] uint id)
    {
        CustomResponseDto<GetByIdCartRuleResponse> response = await Mediator.Send(new GetByIdCartRuleQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCartRuleQuery getListCartRuleQuery = new() { PageRequest = pageRequest };
       CustomResponseDto<GetListResponse<GetListCartRuleListItemDto>> response = await Mediator.Send(getListCartRuleQuery);
        return Ok(response);
    }
}