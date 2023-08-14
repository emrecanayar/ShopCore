using Application.Features.CategoryFilterableAttributes.Commands.Create;
using Application.Features.CategoryFilterableAttributes.Commands.Delete;
using Application.Features.CategoryFilterableAttributes.Commands.Update;
using Application.Features.CategoryFilterableAttributes.Queries.GetById;
using Application.Features.CategoryFilterableAttributes.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Core.Application.ResponseTypes.Concrete;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryFilterableAttributesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCategoryFilterableAttributeCommand createCategoryFilterableAttributeCommand)
    {
        CustomResponseDto<CreatedCategoryFilterableAttributeResponse> response = await Mediator.Send(createCategoryFilterableAttributeCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCategoryFilterableAttributeCommand updateCategoryFilterableAttributeCommand)
    {
        CustomResponseDto<UpdatedCategoryFilterableAttributeResponse> response = await Mediator.Send(updateCategoryFilterableAttributeCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] uint id)
    {
        CustomResponseDto<DeletedCategoryFilterableAttributeResponse> response = await Mediator.Send(new DeleteCategoryFilterableAttributeCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] uint id)
    {
        CustomResponseDto<GetByIdCategoryFilterableAttributeResponse> response = await Mediator.Send(new GetByIdCategoryFilterableAttributeQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCategoryFilterableAttributeQuery getListCategoryFilterableAttributeQuery = new() { PageRequest = pageRequest };
       CustomResponseDto<GetListResponse<GetListCategoryFilterableAttributeListItemDto>> response = await Mediator.Send(getListCategoryFilterableAttributeQuery);
        return Ok(response);
    }
}