using Application.Features.AttributeGroups.Commands.Create;
using Application.Features.AttributeGroups.Commands.Delete;
using Application.Features.AttributeGroups.Commands.Update;
using Application.Features.AttributeGroups.Queries.GetById;
using Application.Features.AttributeGroups.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Core.Application.ResponseTypes.Concrete;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AttributeGroupsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAttributeGroupCommand createAttributeGroupCommand)
    {
        CustomResponseDto<CreatedAttributeGroupResponse> response = await Mediator.Send(createAttributeGroupCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAttributeGroupCommand updateAttributeGroupCommand)
    {
        CustomResponseDto<UpdatedAttributeGroupResponse> response = await Mediator.Send(updateAttributeGroupCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] uint id)
    {
        CustomResponseDto<DeletedAttributeGroupResponse> response = await Mediator.Send(new DeleteAttributeGroupCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] uint id)
    {
        CustomResponseDto<GetByIdAttributeGroupResponse> response = await Mediator.Send(new GetByIdAttributeGroupQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAttributeGroupQuery getListAttributeGroupQuery = new() { PageRequest = pageRequest };
       CustomResponseDto<GetListResponse<GetListAttributeGroupListItemDto>> response = await Mediator.Send(getListAttributeGroupQuery);
        return Ok(response);
    }
}