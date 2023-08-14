using Application.Features.BookingProductEventTicketTranslations.Commands.Create;
using Application.Features.BookingProductEventTicketTranslations.Commands.Delete;
using Application.Features.BookingProductEventTicketTranslations.Commands.Update;
using Application.Features.BookingProductEventTicketTranslations.Queries.GetById;
using Application.Features.BookingProductEventTicketTranslations.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Core.Application.ResponseTypes.Concrete;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingProductEventTicketTranslationsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBookingProductEventTicketTranslationCommand createBookingProductEventTicketTranslationCommand)
    {
        CustomResponseDto<CreatedBookingProductEventTicketTranslationResponse> response = await Mediator.Send(createBookingProductEventTicketTranslationCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBookingProductEventTicketTranslationCommand updateBookingProductEventTicketTranslationCommand)
    {
        CustomResponseDto<UpdatedBookingProductEventTicketTranslationResponse> response = await Mediator.Send(updateBookingProductEventTicketTranslationCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] uint id)
    {
        CustomResponseDto<DeletedBookingProductEventTicketTranslationResponse> response = await Mediator.Send(new DeleteBookingProductEventTicketTranslationCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] uint id)
    {
        CustomResponseDto<GetByIdBookingProductEventTicketTranslationResponse> response = await Mediator.Send(new GetByIdBookingProductEventTicketTranslationQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBookingProductEventTicketTranslationQuery getListBookingProductEventTicketTranslationQuery = new() { PageRequest = pageRequest };
       CustomResponseDto<GetListResponse<GetListBookingProductEventTicketTranslationListItemDto>> response = await Mediator.Send(getListBookingProductEventTicketTranslationQuery);
        return Ok(response);
    }
}