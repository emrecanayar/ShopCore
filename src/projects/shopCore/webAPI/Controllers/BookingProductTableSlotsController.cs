using Application.Features.BookingProductTableSlots.Commands.Create;
using Application.Features.BookingProductTableSlots.Commands.Delete;
using Application.Features.BookingProductTableSlots.Commands.Update;
using Application.Features.BookingProductTableSlots.Queries.GetById;
using Application.Features.BookingProductTableSlots.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Core.Application.ResponseTypes.Concrete;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingProductTableSlotsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBookingProductTableSlotCommand createBookingProductTableSlotCommand)
    {
        CustomResponseDto<CreatedBookingProductTableSlotResponse> response = await Mediator.Send(createBookingProductTableSlotCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBookingProductTableSlotCommand updateBookingProductTableSlotCommand)
    {
        CustomResponseDto<UpdatedBookingProductTableSlotResponse> response = await Mediator.Send(updateBookingProductTableSlotCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] uint id)
    {
        CustomResponseDto<DeletedBookingProductTableSlotResponse> response = await Mediator.Send(new DeleteBookingProductTableSlotCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] uint id)
    {
        CustomResponseDto<GetByIdBookingProductTableSlotResponse> response = await Mediator.Send(new GetByIdBookingProductTableSlotQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBookingProductTableSlotQuery getListBookingProductTableSlotQuery = new() { PageRequest = pageRequest };
       CustomResponseDto<GetListResponse<GetListBookingProductTableSlotListItemDto>> response = await Mediator.Send(getListBookingProductTableSlotQuery);
        return Ok(response);
    }
}