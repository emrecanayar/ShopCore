using Application.Features.AttributeGroupMappings.Commands.Create;
using Application.Features.AttributeGroupMappings.Commands.Delete;
using Application.Features.AttributeGroupMappings.Commands.Update;
using Application.Features.AttributeGroupMappings.Queries.GetById;
using Application.Features.AttributeGroupMappings.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Core.Application.ResponseTypes.Concrete;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AttributeGroupMappingsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAttributeGroupMappingCommand createAttributeGroupMappingCommand)
    {
        CustomResponseDto<CreatedAttributeGroupMappingResponse> response = await Mediator.Send(createAttributeGroupMappingCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAttributeGroupMappingCommand updateAttributeGroupMappingCommand)
    {
        CustomResponseDto<UpdatedAttributeGroupMappingResponse> response = await Mediator.Send(updateAttributeGroupMappingCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] uint id)
    {
        CustomResponseDto<DeletedAttributeGroupMappingResponse> response = await Mediator.Send(new DeleteAttributeGroupMappingCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] uint id)
    {
        CustomResponseDto<GetByIdAttributeGroupMappingResponse> response = await Mediator.Send(new GetByIdAttributeGroupMappingQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAttributeGroupMappingQuery getListAttributeGroupMappingQuery = new() { PageRequest = pageRequest };
       CustomResponseDto<GetListResponse<GetListAttributeGroupMappingListItemDto>> response = await Mediator.Send(getListAttributeGroupMappingQuery);
        return Ok(response);
    }
}