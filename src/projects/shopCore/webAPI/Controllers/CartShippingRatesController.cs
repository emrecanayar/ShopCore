using Application.Features.CartShippingRates.Commands.Create;
using Application.Features.CartShippingRates.Commands.Delete;
using Application.Features.CartShippingRates.Commands.Update;
using Application.Features.CartShippingRates.Queries.GetById;
using Application.Features.CartShippingRates.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Core.Application.ResponseTypes.Concrete;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartShippingRatesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCartShippingRateCommand createCartShippingRateCommand)
    {
        CustomResponseDto<CreatedCartShippingRateResponse> response = await Mediator.Send(createCartShippingRateCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCartShippingRateCommand updateCartShippingRateCommand)
    {
        CustomResponseDto<UpdatedCartShippingRateResponse> response = await Mediator.Send(updateCartShippingRateCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] uint id)
    {
        CustomResponseDto<DeletedCartShippingRateResponse> response = await Mediator.Send(new DeleteCartShippingRateCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] uint id)
    {
        CustomResponseDto<GetByIdCartShippingRateResponse> response = await Mediator.Send(new GetByIdCartShippingRateQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCartShippingRateQuery getListCartShippingRateQuery = new() { PageRequest = pageRequest };
       CustomResponseDto<GetListResponse<GetListCartShippingRateListItemDto>> response = await Mediator.Send(getListCartShippingRateQuery);
        return Ok(response);
    }
}