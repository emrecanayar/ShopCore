using Application.Features.AttributeOptionTranslations.Commands.Create;
using Application.Features.AttributeOptionTranslations.Commands.Delete;
using Application.Features.AttributeOptionTranslations.Commands.Update;
using Application.Features.AttributeOptionTranslations.Queries.GetById;
using Application.Features.AttributeOptionTranslations.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Core.Application.ResponseTypes.Concrete;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AttributeOptionTranslationsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAttributeOptionTranslationCommand createAttributeOptionTranslationCommand)
    {
        CustomResponseDto<CreatedAttributeOptionTranslationResponse> response = await Mediator.Send(createAttributeOptionTranslationCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAttributeOptionTranslationCommand updateAttributeOptionTranslationCommand)
    {
        CustomResponseDto<UpdatedAttributeOptionTranslationResponse> response = await Mediator.Send(updateAttributeOptionTranslationCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] uint id)
    {
        CustomResponseDto<DeletedAttributeOptionTranslationResponse> response = await Mediator.Send(new DeleteAttributeOptionTranslationCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] uint id)
    {
        CustomResponseDto<GetByIdAttributeOptionTranslationResponse> response = await Mediator.Send(new GetByIdAttributeOptionTranslationQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAttributeOptionTranslationQuery getListAttributeOptionTranslationQuery = new() { PageRequest = pageRequest };
       CustomResponseDto<GetListResponse<GetListAttributeOptionTranslationListItemDto>> response = await Mediator.Send(getListAttributeOptionTranslationQuery);
        return Ok(response);
    }
}