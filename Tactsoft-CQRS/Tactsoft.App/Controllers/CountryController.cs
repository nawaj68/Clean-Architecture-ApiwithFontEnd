using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Application.Common;
using Tactsoft.Application.Features.CountryOperation.Commend;
using Tactsoft.Application.Features.CountryOperation.Query;
using Tactsoft.Application.Models.Entities;

namespace Tactsoft.App.Controllers;
[AllowAnonymous]
public class CountryController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<CountryVM>> Getbylist()
    {
        return Ok(await Mediator.Send(new GetCountryList()));
    }

    [HttpGet("id")]
    public async Task<ActionResult<CountryVM>> GetlistId(int id)
    {
        return Ok(await Mediator.Send(new GetSingleCountry(id)));
    }
    [HttpPost]
    public async Task<ActionResult<CountryVM>> CreateCountry([FromBody] CountryVM model)
    {
        return Ok(await Mediator.Send(new CreateCountry(model)));
    }
    [HttpPut("id")]
    public async Task<ActionResult<CountryVM>> UpdateCountry(int id,CountryVM model)
    {
        return Ok(await Mediator.Send(new UpdateCountry(id,model)));
    }
    [HttpDelete("id")]
    public async Task<ActionResult<CountryVM>> DeleteCountry(int id)
    {
        return await Mediator.Send(new DeleteCountry(id));
    }
}
