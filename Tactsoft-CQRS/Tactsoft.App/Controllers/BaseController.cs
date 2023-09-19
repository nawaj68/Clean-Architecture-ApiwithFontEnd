using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Application.Common;

namespace Tactsoft.App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    private ISender _sender;
    protected ISender Mediator => _sender ??= HttpContext.RequestServices.GetService<ISender>();

    protected async Task<ActionResult> HandelCommandAsync<T>(IRequest<CommandResult<T>> command)
    {
        var result = await Mediator.Send(command);
        return result.Type switch
        {
            CommandResultTypeEnum.InvalidInput => new BadRequestResult(),
            CommandResultTypeEnum.NotFound => new NotFoundResult(),
            CommandResultTypeEnum.Created => new CreatedResult("", result.Result),
            _ => new OkObjectResult(result.Result)
        };
    }

    protected async Task<ActionResult> HandelQueryAsync<T>(IRequest<QueryResult<T>> query)
    {
        var result = await Mediator.Send(query);
        return result.Type switch
        {
            QueryResultTypeEnum.InvalidInput => new BadRequestResult(),
            QueryResultTypeEnum.NotFound => new NotFoundResult(),
            _ => new OkObjectResult(result.Result)
        };
    }
}
