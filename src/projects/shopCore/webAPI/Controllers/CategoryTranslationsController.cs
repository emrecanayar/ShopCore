using Application.Features.CategoryTranslations.Commands.Create;
using Application.Features.CategoryTranslations.Commands.Delete;
using Application.Features.CategoryTranslations.Commands.Update;
using Application.Features.CategoryTranslations.Queries.GetById;
using Application.Features.CategoryTranslations.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Core.Application.ResponseTypes.Concrete;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryTranslationsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCategoryTranslationCommand createCategoryTranslationCommand)
    {
        CustomResponseDto<CreatedCategoryTranslationResponse> response = await Mediator.Send(createCategoryTranslationCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCategoryTranslationCommand updateCategoryTranslationCommand)
    {
        CustomResponseDto<UpdatedCategoryTranslationResponse> response = await Mediator.Send(updateCategoryTranslationCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] uint id)
    {
        CustomResponseDto<DeletedCategoryTranslationResponse> response = await Mediator.Send(new DeleteCategoryTranslationCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] uint id)
    {
        CustomResponseDto<GetByIdCategoryTranslationResponse> response = await Mediator.Send(new GetByIdCategoryTranslationQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCategoryTranslationQuery getListCategoryTranslationQuery = new() { PageRequest = pageRequest };
       CustomResponseDto<GetListResponse<GetListCategoryTranslationListItemDto>> response = await Mediator.Send(getListCategoryTranslationQuery);
        return Ok(response);
    }
}