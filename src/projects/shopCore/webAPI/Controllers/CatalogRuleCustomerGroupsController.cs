using Application.Features.CatalogRuleCustomerGroups.Commands.Create;
using Application.Features.CatalogRuleCustomerGroups.Commands.Delete;
using Application.Features.CatalogRuleCustomerGroups.Commands.Update;
using Application.Features.CatalogRuleCustomerGroups.Queries.GetById;
using Application.Features.CatalogRuleCustomerGroups.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Core.Application.ResponseTypes.Concrete;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CatalogRuleCustomerGroupsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCatalogRuleCustomerGroupCommand createCatalogRuleCustomerGroupCommand)
    {
        CustomResponseDto<CreatedCatalogRuleCustomerGroupResponse> response = await Mediator.Send(createCatalogRuleCustomerGroupCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCatalogRuleCustomerGroupCommand updateCatalogRuleCustomerGroupCommand)
    {
        CustomResponseDto<UpdatedCatalogRuleCustomerGroupResponse> response = await Mediator.Send(updateCatalogRuleCustomerGroupCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] uint id)
    {
        CustomResponseDto<DeletedCatalogRuleCustomerGroupResponse> response = await Mediator.Send(new DeleteCatalogRuleCustomerGroupCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] uint id)
    {
        CustomResponseDto<GetByIdCatalogRuleCustomerGroupResponse> response = await Mediator.Send(new GetByIdCatalogRuleCustomerGroupQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCatalogRuleCustomerGroupQuery getListCatalogRuleCustomerGroupQuery = new() { PageRequest = pageRequest };
       CustomResponseDto<GetListResponse<GetListCatalogRuleCustomerGroupListItemDto>> response = await Mediator.Send(getListCatalogRuleCustomerGroupQuery);
        return Ok(response);
    }
}