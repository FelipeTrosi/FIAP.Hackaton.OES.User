using FIAP.Hackathon.OES.User.API.Services;
using FIAP.Hackathon.OES.User.Service.Dto.User;
using FIAP.Hackathon.OES.User.Service.Interfaces;
using IAP.Hackathon.OES.User.Service.Dto.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.FCG.User.API.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController(IUserService service, IAuthService authService) : ControllerBase
{
    private readonly IUserService _service = service;
    private readonly IAuthService _authService = authService;

    /// <summary>
    /// Realiza login do usuário e retorna um token JWT.
    /// </summary>
    /// <param name="input">Credenciais de login.</param>
    /// <returns>Token JWT para autenticação.</returns>
    /// <response code="200">Login realizado com sucesso.</response>
    /// <response code="401">Credenciais inválidas.</response>
    [HttpPost("Login")]
    public IActionResult Login([FromBody] LoginDto input)
    {
        return Ok(new { token = _authService.Login(input) });
    }

    /// <summary>
    /// Cria um novo usuário.
    /// </summary>
    /// <param name="input">Dados do usuário a ser criado.</param>
    /// <response code="200">Usuário criado com sucesso.</response>
    /// <response code="400">Dados inválidos.</response>
    [HttpPost]
    public IActionResult Post([FromBody] UserCreateDto input)
    {
        _service.Create(input);
        return Ok();
    }

    /// <summary>
    /// Atualiza um usuário existente.
    /// </summary>
    /// <param name="input">Dados do usuário para atualização.</param>
    /// <response code="200">Usuário atualizado com sucesso.</response>
    /// <response code="404">Usuário não encontrado.</response>
    [HttpPut]
    [Authorize(Policy = "MANAGER")]
    public IActionResult Put([FromBody] UserUpdateDto input)
    {
        _service.Update(input);
        return Ok();
    }

    /// <summary>
    /// Remove um usuário pelo ID.
    /// </summary>
    /// <param name="id">ID do usuário.</param>
    /// <response code="200">Usuário removido com sucesso.</response>
    /// <response code="404">Usuário não encontrado.</response>
    [HttpDelete("{id:long}")]
    [Authorize(Policy = "MANAGER")]
    public IActionResult Delete(long id)
    {
        _service.DeleteById(id);
        return Ok();
    }

    /// <summary>
    /// Obtém um usuário pelo ID.
    /// </summary>
    /// <param name="id">ID do usuário.</param>
    /// <response code="200">Usuário encontrado.</response>
    /// <response code="404">Usuário não encontrado.</response>
    [HttpGet("GetById/{id:long}")]
    [Authorize(Policy = "MANAGER")]
    public IActionResult GetById(long id)
    {
        return Ok(_service.GetById(id));
    }

    /// <summary>
    /// Lista todos os usuários.
    /// </summary>
    /// <response code="200">Lista de usuários retornada com sucesso.</response>
    [HttpGet("GetAll")]
    [Authorize(Policy = "MANAGER")]
    public IActionResult GetAll()
    {
        return Ok(_service.GetAll());
    }

}
