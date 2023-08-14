using Application.Features.BookingProductEventTickets.Commands.Create;
using Application.Features.BookingProductEventTickets.Commands.Delete;
using Application.Features.BookingProductEventTickets.Commands.Update;
using Application.Features.BookingProductEventTickets.Queries.GetById;
using Application.Features.BookingProductEventTickets.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Core.Application.ResponseTypes.Concrete;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingProductEventTicketsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBookingProductEventTicketCommand createBookingProductEventTicketCommand)
    {
        CustomResponseDto<CreatedBookingProductEventTicketResponse> response = await Mediator.Send(createBookingProductEventTicketCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBookingProductEventTicketCommand updateBookingProductEventTicketCommand)
    {
        CustomResponseDto<UpdatedBookingProductEventTicketResponse> response = await Mediator.Send(updateBookingProductEventTicketCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] uint id)
    {
        CustomResponseDto<DeletedBookingProductEventTicketResponse> response = await Mediator.Send(new DeleteBookingProductEventTicketCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] uint id)
    {
        CustomResponseDto<GetByIdBookingProductEventTicketResponse> response = await Mediator.Send(new GetByIdBookingProductEventTicketQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBookingProductEventTicketQuery getListBookingProductEventTicketQuery = new() { PageRequest = pageRequest };
       CustomResponseDto<GetListResponse<GetListBookingProductEventTicketListItemDto>> response = await Mediator.Send(getListBookingProductEventTicketQuery);
        return Ok(response);
    }
}