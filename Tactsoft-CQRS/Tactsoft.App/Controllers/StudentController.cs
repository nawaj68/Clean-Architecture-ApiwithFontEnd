using Microsoft.AspNetCore.Mvc;
using Tactsoft.Application.Features.StudentOperation.Command;
using Tactsoft.Application.Features.StudentOperation.Query;
using Tactsoft.Application.Models.Entities;

namespace Tactsoft.App.Controllers;


public class StudentController : BaseController
{
    [HttpGet("id")]
    public async Task<ActionResult<StudentVM>> Get(int id)
    {
        return await Mediator.Send(new GetStudentById(id));
    }

    [HttpGet]
    public async Task<ActionResult<List<StudentVM>>> GetList()
    {
        return Ok(await Mediator.Send(new GetStudentList()));
    }

    [HttpPost]
    public async Task<ActionResult<StudentVM>> PustAsync(StudentVM model)
    {
        return await Mediator.Send(new CreateStudent(model));
    }

    [HttpPut("id")]
    public async Task<ActionResult<StudentVM>> PutAsync(int id, StudentVM model)
    {
        return await Mediator.Send(new UpdateStudent(id, model));
    }

    [HttpDelete("id")]
    public async Task<ActionResult<StudentVM>> DeleteAsync(int id)
    {
        return await Mediator.Send(new DeleteStudent(id));
    }
}
