using Application.Features.CartRuleCouponUsages.Commands.Create;
using Application.Features.CartRuleCouponUsages.Commands.Delete;
using Application.Features.CartRuleCouponUsages.Commands.Update;
using Application.Features.CartRuleCouponUsages.Queries.GetById;
using Application.Features.CartRuleCouponUsages.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Core.Application.ResponseTypes.Concrete;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartRuleCouponUsagesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCartRuleCouponUsageCommand createCartRuleCouponUsageCommand)
    {
        CustomResponseDto<CreatedCartRuleCouponUsageResponse> response = await Mediator.Send(createCartRuleCouponUsageCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCartRuleCouponUsageCommand updateCartRuleCouponUsageCommand)
    {
        CustomResponseDto<UpdatedCartRuleCouponUsageResponse> response = await Mediator.Send(updateCartRuleCouponUsageCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] uint id)
    {
        CustomResponseDto<DeletedCartRuleCouponUsageResponse> response = await Mediator.Send(new DeleteCartRuleCouponUsageCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] uint id)
    {
        CustomResponseDto<GetByIdCartRuleCouponUsageResponse> response = await Mediator.Send(new GetByIdCartRuleCouponUsageQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCartRuleCouponUsageQuery getListCartRuleCouponUsageQuery = new() { PageRequest = pageRequest };
       CustomResponseDto<GetListResponse<GetListCartRuleCouponUsageListItemDto>> response = await Mediator.Send(getListCartRuleCouponUsageQuery);
        return Ok(response);
    }
}