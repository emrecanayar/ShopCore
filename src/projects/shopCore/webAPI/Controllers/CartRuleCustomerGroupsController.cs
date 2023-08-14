using Application.Features.CartRuleCustomerGroups.Commands.Create;
using Application.Features.CartRuleCustomerGroups.Commands.Delete;
using Application.Features.CartRuleCustomerGroups.Commands.Update;
using Application.Features.CartRuleCustomerGroups.Queries.GetById;
using Application.Features.CartRuleCustomerGroups.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Core.Application.ResponseTypes.Concrete;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartRuleCustomerGroupsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCartRuleCustomerGroupCommand createCartRuleCustomerGroupCommand)
    {
        CustomResponseDto<CreatedCartRuleCustomerGroupResponse> response = await Mediator.Send(createCartRuleCustomerGroupCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCartRuleCustomerGroupCommand updateCartRuleCustomerGroupCommand)
    {
        CustomResponseDto<UpdatedCartRuleCustomerGroupResponse> response = await Mediator.Send(updateCartRuleCustomerGroupCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] uint id)
    {
        CustomResponseDto<DeletedCartRuleCustomerGroupResponse> response = await Mediator.Send(new DeleteCartRuleCustomerGroupCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] uint id)
    {
        CustomResponseDto<GetByIdCartRuleCustomerGroupResponse> response = await Mediator.Send(new GetByIdCartRuleCustomerGroupQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCartRuleCustomerGroupQuery getListCartRuleCustomerGroupQuery = new() { PageRequest = pageRequest };
       CustomResponseDto<GetListResponse<GetListCartRuleCustomerGroupListItemDto>> response = await Mediator.Send(getListCartRuleCustomerGroupQuery);
        return Ok(response);
    }
}