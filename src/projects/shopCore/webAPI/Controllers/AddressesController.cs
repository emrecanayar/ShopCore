using Application.Features.Addresses.Commands.Create;
using Application.Features.Addresses.Commands.Delete;
using Application.Features.Addresses.Commands.Update;
using Application.Features.Addresses.Queries.GetById;
using Application.Features.Addresses.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using Microsoft.AspNetCore.Mvc;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AddressesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAddressCommand createAddressCommand)
    {
        CustomResponseDto<CreatedAddressResponse> response = await Mediator.Send(createAddressCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAddressCommand updateAddressCommand)
    {
        CustomResponseDto<UpdatedAddressResponse> response = await Mediator.Send(updateAddressCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] uint id)
    {
        CustomResponseDto<DeletedAddressResponse> response = await Mediator.Send(new DeleteAddressCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] uint id)
    {
        CustomResponseDto<GetByIdAddressResponse> response = await Mediator.Send(new GetByIdAddressQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAddressQuery getListAddressQuery = new() { PageRequest = pageRequest };
        CustomResponseDto<GetListResponse<GetListAddressListItemDto>> response = await Mediator.Send(getListAddressQuery);
        return Ok(response);
    }
}