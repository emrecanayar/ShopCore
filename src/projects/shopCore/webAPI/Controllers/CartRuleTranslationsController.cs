using Application.Features.CartRuleTranslations.Commands.Create;
using Application.Features.CartRuleTranslations.Commands.Delete;
using Application.Features.CartRuleTranslations.Commands.Update;
using Application.Features.CartRuleTranslations.Queries.GetById;
using Application.Features.CartRuleTranslations.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Core.Application.ResponseTypes.Concrete;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartRuleTranslationsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCartRuleTranslationCommand createCartRuleTranslationCommand)
    {
        CustomResponseDto<CreatedCartRuleTranslationResponse> response = await Mediator.Send(createCartRuleTranslationCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCartRuleTranslationCommand updateCartRuleTranslationCommand)
    {
        CustomResponseDto<UpdatedCartRuleTranslationResponse> response = await Mediator.Send(updateCartRuleTranslationCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] uint id)
    {
        CustomResponseDto<DeletedCartRuleTranslationResponse> response = await Mediator.Send(new DeleteCartRuleTranslationCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] uint id)
    {
        CustomResponseDto<GetByIdCartRuleTranslationResponse> response = await Mediator.Send(new GetByIdCartRuleTranslationQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCartRuleTranslationQuery getListCartRuleTranslationQuery = new() { PageRequest = pageRequest };
       CustomResponseDto<GetListResponse<GetListCartRuleTranslationListItemDto>> response = await Mediator.Send(getListCartRuleTranslationQuery);
        return Ok(response);
    }
}