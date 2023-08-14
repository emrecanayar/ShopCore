using Application.Features.BookingProductRentalSlots.Commands.Create;
using Application.Features.BookingProductRentalSlots.Commands.Delete;
using Application.Features.BookingProductRentalSlots.Commands.Update;
using Application.Features.BookingProductRentalSlots.Queries.GetById;
using Application.Features.BookingProductRentalSlots.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Core.Application.ResponseTypes.Concrete;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingProductRentalSlotsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBookingProductRentalSlotCommand createBookingProductRentalSlotCommand)
    {
        CustomResponseDto<CreatedBookingProductRentalSlotResponse> response = await Mediator.Send(createBookingProductRentalSlotCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBookingProductRentalSlotCommand updateBookingProductRentalSlotCommand)
    {
        CustomResponseDto<UpdatedBookingProductRentalSlotResponse> response = await Mediator.Send(updateBookingProductRentalSlotCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] uint id)
    {
        CustomResponseDto<DeletedBookingProductRentalSlotResponse> response = await Mediator.Send(new DeleteBookingProductRentalSlotCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] uint id)
    {
        CustomResponseDto<GetByIdBookingProductRentalSlotResponse> response = await Mediator.Send(new GetByIdBookingProductRentalSlotQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBookingProductRentalSlotQuery getListBookingProductRentalSlotQuery = new() { PageRequest = pageRequest };
       CustomResponseDto<GetListResponse<GetListBookingProductRentalSlotListItemDto>> response = await Mediator.Send(getListBookingProductRentalSlotQuery);
        return Ok(response);
    }
}