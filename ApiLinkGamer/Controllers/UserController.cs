using Domain.Entities;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Service;
using Service.Service.Interfaces;

namespace ApiLinkGamer.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    public readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }


    [HttpPost]
    [Route("Login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] UserLoginModel userLoginModel)
    {
        try
        {
                if (userLoginModel == null) return BadRequest(new ApiLinkGamerResponse(false, "Usuário ou senha inválidos."));

            var response = await _userService.Login(userLoginModel);

            if (response.Success)
                return Ok(response);
            else
                return BadRequest(response);

        }
        catch (Exception)
        {
            return BadRequest(new ApiLinkGamerResponse(false, "Erro ao tentar logar-se. Contate nosso suporte. 'link do suporte.'")); 
        }
    }

    [HttpPost]
    [Route("Insert")]
    [AllowAnonymous]
    public async Task<IActionResult> Insert([FromBody] UserInsertModel userModel)
    {
        if (userModel == null) return BadRequest(new ApiLinkGamerResponse(false, "Erro ao inserir usuário."));

        var usrValid = userModel.isValid();

        if (!usrValid.Valid)
        {
            return BadRequest(new ApiLinkGamerResponse(false, usrValid.Message));
        }

        try
        {
            var result = await _userService.InsertUser(userModel);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
        catch (Exception)
        {

            throw;
        }

    }
}
