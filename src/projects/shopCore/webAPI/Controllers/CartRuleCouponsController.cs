using Application.Features.CartRuleCoupons.Commands.Create;
using Application.Features.CartRuleCoupons.Commands.Delete;
using Application.Features.CartRuleCoupons.Commands.Update;
using Application.Features.CartRuleCoupons.Queries.GetById;
using Application.Features.CartRuleCoupons.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Core.Application.ResponseTypes.Concrete;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartRuleCouponsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCartRuleCouponCommand createCartRuleCouponCommand)
    {
        CustomResponseDto<CreatedCartRuleCouponResponse> response = await Mediator.Send(createCartRuleCouponCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCartRuleCouponCommand updateCartRuleCouponCommand)
    {
        CustomResponseDto<UpdatedCartRuleCouponResponse> response = await Mediator.Send(updateCartRuleCouponCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] uint id)
    {
        CustomResponseDto<DeletedCartRuleCouponResponse> response = await Mediator.Send(new DeleteCartRuleCouponCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] uint id)
    {
        CustomResponseDto<GetByIdCartRuleCouponResponse> response = await Mediator.Send(new GetByIdCartRuleCouponQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCartRuleCouponQuery getListCartRuleCouponQuery = new() { PageRequest = pageRequest };
       CustomResponseDto<GetListResponse<GetListCartRuleCouponListItemDto>> response = await Mediator.Send(getListCartRuleCouponQuery);
        return Ok(response);
    }
}