using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Application.AuthServices;
using Tactsoft.Application.Models.Auth;

namespace Tactsoft.App.Controllers.Account;

[AllowAnonymous]
public class AccountController : Controller
{
    private readonly IAuthService _authService;

    public AccountController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginModel model)
    {
        return Ok(await _authService.Login(model));
    }

    [HttpPost("register")]
    public async Task<ActionResult<RegistrationResponse>> Register([FromBody] RegistrationModel model)
    {
        return Ok(await _authService.Register(model));
    }
}
