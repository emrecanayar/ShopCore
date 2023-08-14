using Application.Features.BookingProducts.Commands.Create;
using Application.Features.BookingProducts.Commands.Delete;
using Application.Features.BookingProducts.Commands.Update;
using Application.Features.BookingProducts.Queries.GetById;
using Application.Features.BookingProducts.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Core.Application.ResponseTypes.Concrete;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingProductsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBookingProductCommand createBookingProductCommand)
    {
        CustomResponseDto<CreatedBookingProductResponse> response = await Mediator.Send(createBookingProductCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBookingProductCommand updateBookingProductCommand)
    {
        CustomResponseDto<UpdatedBookingProductResponse> response = await Mediator.Send(updateBookingProductCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] uint id)
    {
        CustomResponseDto<DeletedBookingProductResponse> response = await Mediator.Send(new DeleteBookingProductCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] uint id)
    {
        CustomResponseDto<GetByIdBookingProductResponse> response = await Mediator.Send(new GetByIdBookingProductQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBookingProductQuery getListBookingProductQuery = new() { PageRequest = pageRequest };
       CustomResponseDto<GetListResponse<GetListBookingProductListItemDto>> response = await Mediator.Send(getListBookingProductQuery);
        return Ok(response);
    }
}