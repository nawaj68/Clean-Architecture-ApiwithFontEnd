using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;
using Tactsoft.Application.Common;
using Tactsoft.Application.Features.CityOperation.Query;
using Tactsoft.Application.Features.StateOperation.Command;
using Tactsoft.Application.Features.StateOperation.Query;
using Tactsoft.Application.Models.Entities;

namespace Tactsoft.App.Controllers;
[AllowAnonymous]
public class StateController : BaseController
{
    [HttpGet("id")]
    public async Task<ActionResult<StateVM>> GetById(int id)
    {
        return await Mediator.Send(new GetSingleState(id));
    }

    [HttpGet]
    public async Task<ActionResult<StateVM>> GetAll()
    {
        return Ok(await Mediator.Send(new GetStateList()));
    }
    [HttpPost]
    public async Task<ActionResult<StateVM>> CreateState([FromQuery]StateVM model)
    {
        return await Mediator.Send(new CreateState(model));
    }
    [HttpPut("id")]
    public async Task<ActionResult<StateVM>> UpdateCity(int id,StateVM model)
    {
        return await Mediator.Send(new UpdateState(id,model));
    }

    [HttpDelete("id")]
    public async Task<ActionResult<StateVM>> DeleteState(int id)
    {
        return await Mediator.Send(new DeleteState(id));
    }
}
