using Application.Features.BookingProductAppointmentSlots.Commands.Create;
using Application.Features.BookingProductAppointmentSlots.Commands.Delete;
using Application.Features.BookingProductAppointmentSlots.Commands.Update;
using Application.Features.BookingProductAppointmentSlots.Queries.GetById;
using Application.Features.BookingProductAppointmentSlots.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Core.Application.ResponseTypes.Concrete;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingProductAppointmentSlotsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBookingProductAppointmentSlotCommand createBookingProductAppointmentSlotCommand)
    {
        CustomResponseDto<CreatedBookingProductAppointmentSlotResponse> response = await Mediator.Send(createBookingProductAppointmentSlotCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBookingProductAppointmentSlotCommand updateBookingProductAppointmentSlotCommand)
    {
        CustomResponseDto<UpdatedBookingProductAppointmentSlotResponse> response = await Mediator.Send(updateBookingProductAppointmentSlotCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] uint id)
    {
        CustomResponseDto<DeletedBookingProductAppointmentSlotResponse> response = await Mediator.Send(new DeleteBookingProductAppointmentSlotCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] uint id)
    {
        CustomResponseDto<GetByIdBookingProductAppointmentSlotResponse> response = await Mediator.Send(new GetByIdBookingProductAppointmentSlotQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBookingProductAppointmentSlotQuery getListBookingProductAppointmentSlotQuery = new() { PageRequest = pageRequest };
       CustomResponseDto<GetListResponse<GetListBookingProductAppointmentSlotListItemDto>> response = await Mediator.Send(getListBookingProductAppointmentSlotQuery);
        return Ok(response);
    }
}