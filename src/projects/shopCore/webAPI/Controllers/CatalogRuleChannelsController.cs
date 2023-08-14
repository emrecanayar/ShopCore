using Application.Features.CatalogRuleChannels.Commands.Create;
using Application.Features.CatalogRuleChannels.Commands.Delete;
using Application.Features.CatalogRuleChannels.Commands.Update;
using Application.Features.CatalogRuleChannels.Queries.GetById;
using Application.Features.CatalogRuleChannels.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Core.Application.ResponseTypes.Concrete;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CatalogRuleChannelsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCatalogRuleChannelCommand createCatalogRuleChannelCommand)
    {
        CustomResponseDto<CreatedCatalogRuleChannelResponse> response = await Mediator.Send(createCatalogRuleChannelCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCatalogRuleChannelCommand updateCatalogRuleChannelCommand)
    {
        CustomResponseDto<UpdatedCatalogRuleChannelResponse> response = await Mediator.Send(updateCatalogRuleChannelCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] uint id)
    {
        CustomResponseDto<DeletedCatalogRuleChannelResponse> response = await Mediator.Send(new DeleteCatalogRuleChannelCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] uint id)
    {
        CustomResponseDto<GetByIdCatalogRuleChannelResponse> response = await Mediator.Send(new GetByIdCatalogRuleChannelQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCatalogRuleChannelQuery getListCatalogRuleChannelQuery = new() { PageRequest = pageRequest };
       CustomResponseDto<GetListResponse<GetListCatalogRuleChannelListItemDto>> response = await Mediator.Send(getListCatalogRuleChannelQuery);
        return Ok(response);
    }
}