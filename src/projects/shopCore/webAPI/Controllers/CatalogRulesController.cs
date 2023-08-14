using Application.Features.CatalogRules.Commands.Create;
using Application.Features.CatalogRules.Commands.Delete;
using Application.Features.CatalogRules.Commands.Update;
using Application.Features.CatalogRules.Queries.GetById;
using Application.Features.CatalogRules.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Core.Application.ResponseTypes.Concrete;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CatalogRulesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCatalogRuleCommand createCatalogRuleCommand)
    {
        CustomResponseDto<CreatedCatalogRuleResponse> response = await Mediator.Send(createCatalogRuleCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCatalogRuleCommand updateCatalogRuleCommand)
    {
        CustomResponseDto<UpdatedCatalogRuleResponse> response = await Mediator.Send(updateCatalogRuleCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] uint id)
    {
        CustomResponseDto<DeletedCatalogRuleResponse> response = await Mediator.Send(new DeleteCatalogRuleCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] uint id)
    {
        CustomResponseDto<GetByIdCatalogRuleResponse> response = await Mediator.Send(new GetByIdCatalogRuleQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCatalogRuleQuery getListCatalogRuleQuery = new() { PageRequest = pageRequest };
       CustomResponseDto<GetListResponse<GetListCatalogRuleListItemDto>> response = await Mediator.Send(getListCatalogRuleQuery);
        return Ok(response);
    }
}