using Application.Features.CartPayments.Commands.Create;
using Application.Features.CartPayments.Commands.Delete;
using Application.Features.CartPayments.Commands.Update;
using Application.Features.CartPayments.Queries.GetById;
using Application.Features.CartPayments.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Core.Application.ResponseTypes.Concrete;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartPaymentsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCartPaymentCommand createCartPaymentCommand)
    {
        CustomResponseDto<CreatedCartPaymentResponse> response = await Mediator.Send(createCartPaymentCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCartPaymentCommand updateCartPaymentCommand)
    {
        CustomResponseDto<UpdatedCartPaymentResponse> response = await Mediator.Send(updateCartPaymentCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] uint id)
    {
        CustomResponseDto<DeletedCartPaymentResponse> response = await Mediator.Send(new DeleteCartPaymentCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] uint id)
    {
        CustomResponseDto<GetByIdCartPaymentResponse> response = await Mediator.Send(new GetByIdCartPaymentQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCartPaymentQuery getListCartPaymentQuery = new() { PageRequest = pageRequest };
       CustomResponseDto<GetListResponse<GetListCartPaymentListItemDto>> response = await Mediator.Send(getListCartPaymentQuery);
        return Ok(response);
    }
}