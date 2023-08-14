using Application.Features.Attributes.Commands.Create;
using Application.Features.Attributes.Commands.Delete;
using Application.Features.Attributes.Commands.Update;
using Application.Features.Attributes.Queries.GetById;
using Application.Features.Attributes.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Core.Application.ResponseTypes.Concrete;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AttributesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAttributeCommand createAttributeCommand)
    {
        CustomResponseDto<CreatedAttributeResponse> response = await Mediator.Send(createAttributeCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAttributeCommand updateAttributeCommand)
    {
        CustomResponseDto<UpdatedAttributeResponse> response = await Mediator.Send(updateAttributeCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] uint id)
    {
        CustomResponseDto<DeletedAttributeResponse> response = await Mediator.Send(new DeleteAttributeCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] uint id)
    {
        CustomResponseDto<GetByIdAttributeResponse> response = await Mediator.Send(new GetByIdAttributeQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAttributeQuery getListAttributeQuery = new() { PageRequest = pageRequest };
       CustomResponseDto<GetListResponse<GetListAttributeListItemDto>> response = await Mediator.Send(getListAttributeQuery);
        return Ok(response);
    }
}