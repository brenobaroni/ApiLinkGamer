using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiLinkGamer.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost]
    [Route("Login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] User user)
    {
        //if (user == null) return new LinkGamerResult(System.Net.HttpStatusCode.BadRequest, false, "Usuário ou senha inválidos");

        return Ok();
    }
}
