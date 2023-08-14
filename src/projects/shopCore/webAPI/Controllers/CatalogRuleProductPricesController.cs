using Application.Features.CatalogRuleProductPrices.Commands.Create;
using Application.Features.CatalogRuleProductPrices.Commands.Delete;
using Application.Features.CatalogRuleProductPrices.Commands.Update;
using Application.Features.CatalogRuleProductPrices.Queries.GetById;
using Application.Features.CatalogRuleProductPrices.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Core.Application.ResponseTypes.Concrete;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CatalogRuleProductPricesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCatalogRuleProductPriceCommand createCatalogRuleProductPriceCommand)
    {
        CustomResponseDto<CreatedCatalogRuleProductPriceResponse> response = await Mediator.Send(createCatalogRuleProductPriceCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCatalogRuleProductPriceCommand updateCatalogRuleProductPriceCommand)
    {
        CustomResponseDto<UpdatedCatalogRuleProductPriceResponse> response = await Mediator.Send(updateCatalogRuleProductPriceCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] uint id)
    {
        CustomResponseDto<DeletedCatalogRuleProductPriceResponse> response = await Mediator.Send(new DeleteCatalogRuleProductPriceCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] uint id)
    {
        CustomResponseDto<GetByIdCatalogRuleProductPriceResponse> response = await Mediator.Send(new GetByIdCatalogRuleProductPriceQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCatalogRuleProductPriceQuery getListCatalogRuleProductPriceQuery = new() { PageRequest = pageRequest };
       CustomResponseDto<GetListResponse<GetListCatalogRuleProductPriceListItemDto>> response = await Mediator.Send(getListCatalogRuleProductPriceQuery);
        return Ok(response);
    }
}