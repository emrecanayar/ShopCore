using Application.Features.AttributeOptions.Commands.Create;
using Application.Features.AttributeOptions.Commands.Delete;
using Application.Features.AttributeOptions.Commands.Update;
using Application.Features.AttributeOptions.Queries.GetById;
using Application.Features.AttributeOptions.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Core.Application.ResponseTypes.Concrete;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AttributeOptionsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAttributeOptionCommand createAttributeOptionCommand)
    {
        CustomResponseDto<CreatedAttributeOptionResponse> response = await Mediator.Send(createAttributeOptionCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAttributeOptionCommand updateAttributeOptionCommand)
    {
        CustomResponseDto<UpdatedAttributeOptionResponse> response = await Mediator.Send(updateAttributeOptionCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] uint id)
    {
        CustomResponseDto<DeletedAttributeOptionResponse> response = await Mediator.Send(new DeleteAttributeOptionCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] uint id)
    {
        CustomResponseDto<GetByIdAttributeOptionResponse> response = await Mediator.Send(new GetByIdAttributeOptionQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAttributeOptionQuery getListAttributeOptionQuery = new() { PageRequest = pageRequest };
       CustomResponseDto<GetListResponse<GetListAttributeOptionListItemDto>> response = await Mediator.Send(getListAttributeOptionQuery);
        return Ok(response);
    }
}