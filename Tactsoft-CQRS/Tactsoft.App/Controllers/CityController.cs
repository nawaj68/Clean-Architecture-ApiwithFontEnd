using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Application.Common;
using Tactsoft.Application.Features.CityOperation.Command;
using Tactsoft.Application.Features.CityOperation.Query;
using Tactsoft.Application.Models.Entities;

namespace Tactsoft.App.Controllers;
[AllowAnonymous]
public class CityController : BaseController
{
    [HttpGet("id")]
    public async Task<ActionResult<CityVM>> GetById(int id)
    {
        return await Mediator.Send(new GetSignalCity(id));
    }
    [HttpGet]
public async Task<ActionResult<CityVM>> GetAllCity()
    {
        return Ok(await Mediator.Send(new GetCityList()));
    }

    [HttpPost]
    public async Task<ActionResult<CityVM>> CreateCity([FromBody]CityVM model)
    {
        return await Mediator.Send(new CreateCity(model));
    }
    [HttpPut("id")]
    public async Task<ActionResult<CityVM>> UpdateCity(int id,CityVM model)
    {
        return await Mediator.Send(new UpdateCity(id, model));
    }
    [HttpDelete("id")]
    public async Task<ActionResult<CityVM>> DeleteCity(int id)
    {
        return await Mediator.Send(new DeleteCity(id));
    }
}
