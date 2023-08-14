using Application.Features.CatalogRuleProducts.Commands.Create;
using Application.Features.CatalogRuleProducts.Commands.Delete;
using Application.Features.CatalogRuleProducts.Commands.Update;
using Application.Features.CatalogRuleProducts.Queries.GetById;
using Application.Features.CatalogRuleProducts.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Core.Application.ResponseTypes.Concrete;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CatalogRuleProductsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCatalogRuleProductCommand createCatalogRuleProductCommand)
    {
        CustomResponseDto<CreatedCatalogRuleProductResponse> response = await Mediator.Send(createCatalogRuleProductCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCatalogRuleProductCommand updateCatalogRuleProductCommand)
    {
        CustomResponseDto<UpdatedCatalogRuleProductResponse> response = await Mediator.Send(updateCatalogRuleProductCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] uint id)
    {
        CustomResponseDto<DeletedCatalogRuleProductResponse> response = await Mediator.Send(new DeleteCatalogRuleProductCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] uint id)
    {
        CustomResponseDto<GetByIdCatalogRuleProductResponse> response = await Mediator.Send(new GetByIdCatalogRuleProductQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCatalogRuleProductQuery getListCatalogRuleProductQuery = new() { PageRequest = pageRequest };
       CustomResponseDto<GetListResponse<GetListCatalogRuleProductListItemDto>> response = await Mediator.Send(getListCatalogRuleProductQuery);
        return Ok(response);
    }
}