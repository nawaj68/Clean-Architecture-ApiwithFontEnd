using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Application.Common;
using Tactsoft.Application.Features.EmployeeOperation.Command;
using Tactsoft.Application.Features.EmployeeOperation.Query;
using Tactsoft.Application.Models.Entities;

namespace Tactsoft.App.Controllers;

[AllowAnonymous]
public class EmployeeController : BaseController
{
    [HttpGet("search")]
    public async Task<ActionResult<EmployeeVM>> GetListAsync(int pageIndex = CommonVariables.pageIndex, int pageSize = CommonVariables.pageSize, string searchText = null)
    {
        return Ok(await Mediator.Send(new GetEmployeeList(pageIndex, pageSize, searchText)));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EmployeeVM>> GetByIdAsync(int id)
    {
        return await Mediator.Send(new GetSingleEmployee(id));
    }

    [HttpPost]
    public async Task<ActionResult<EmployeeVM>> PostAsync([FromForm]EmployeeVM model, [FromServices] IMediator mediator)
    {
        return await mediator.Send(new CreateEmployee(model));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<EmployeeVM>> PutAsync(int id, [FromForm] EmployeeVM model, [FromServices]IMediator mediator)
    {
        return await mediator.Send(new UpdateEmployee(id, model));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<EmployeeVM>> DeleteAsync(int id)
    {
        return await Mediator.Send(new DeleteEmployee(id));
    }
}
