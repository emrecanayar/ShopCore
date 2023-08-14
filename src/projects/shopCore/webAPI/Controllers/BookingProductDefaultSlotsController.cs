using Application.Features.BookingProductDefaultSlots.Commands.Create;
using Application.Features.BookingProductDefaultSlots.Commands.Delete;
using Application.Features.BookingProductDefaultSlots.Commands.Update;
using Application.Features.BookingProductDefaultSlots.Queries.GetById;
using Application.Features.BookingProductDefaultSlots.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Core.Application.ResponseTypes.Concrete;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingProductDefaultSlotsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBookingProductDefaultSlotCommand createBookingProductDefaultSlotCommand)
    {
        CustomResponseDto<CreatedBookingProductDefaultSlotResponse> response = await Mediator.Send(createBookingProductDefaultSlotCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBookingProductDefaultSlotCommand updateBookingProductDefaultSlotCommand)
    {
        CustomResponseDto<UpdatedBookingProductDefaultSlotResponse> response = await Mediator.Send(updateBookingProductDefaultSlotCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] uint id)
    {
        CustomResponseDto<DeletedBookingProductDefaultSlotResponse> response = await Mediator.Send(new DeleteBookingProductDefaultSlotCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] uint id)
    {
        CustomResponseDto<GetByIdBookingProductDefaultSlotResponse> response = await Mediator.Send(new GetByIdBookingProductDefaultSlotQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBookingProductDefaultSlotQuery getListBookingProductDefaultSlotQuery = new() { PageRequest = pageRequest };
       CustomResponseDto<GetListResponse<GetListBookingProductDefaultSlotListItemDto>> response = await Mediator.Send(getListBookingProductDefaultSlotQuery);
        return Ok(response);
    }
}