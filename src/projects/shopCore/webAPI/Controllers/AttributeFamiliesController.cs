using Application.Features.AttributeFamilies.Commands.Create;
using Application.Features.AttributeFamilies.Commands.Delete;
using Application.Features.AttributeFamilies.Commands.Update;
using Application.Features.AttributeFamilies.Queries.GetById;
using Application.Features.AttributeFamilies.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Core.Application.ResponseTypes.Concrete;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AttributeFamiliesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAttributeFamilyCommand createAttributeFamilyCommand)
    {
        CustomResponseDto<CreatedAttributeFamilyResponse> response = await Mediator.Send(createAttributeFamilyCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAttributeFamilyCommand updateAttributeFamilyCommand)
    {
        CustomResponseDto<UpdatedAttributeFamilyResponse> response = await Mediator.Send(updateAttributeFamilyCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] uint id)
    {
        CustomResponseDto<DeletedAttributeFamilyResponse> response = await Mediator.Send(new DeleteAttributeFamilyCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] uint id)
    {
        CustomResponseDto<GetByIdAttributeFamilyResponse> response = await Mediator.Send(new GetByIdAttributeFamilyQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAttributeFamilyQuery getListAttributeFamilyQuery = new() { PageRequest = pageRequest };
       CustomResponseDto<GetListResponse<GetListAttributeFamilyListItemDto>> response = await Mediator.Send(getListAttributeFamilyQuery);
        return Ok(response);
    }
}