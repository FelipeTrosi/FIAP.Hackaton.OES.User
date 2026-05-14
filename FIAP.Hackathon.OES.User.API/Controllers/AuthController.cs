using FIAP.Hackathon.OES.User.API.Services;
using FIAP.Hackathon.OES.User.Service.Dto.User;
using FIAP.Hackathon.OES.User.Service.Interfaces;
using FIAP.Hackathon.OES.User.Service.ServiceToken;
using IAP.Hackathon.OES.User.Service.Dto.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FIAP.FCG.User.API.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController(IAuthService service) : ControllerBase
{
    private readonly IAuthService _service = service;

    /// <summary>
    /// Realiza login do serviço e retorna um token JWT.
    /// </summary>
    /// <param name="request">Credenciais de login.</param>
    /// <returns>Token JWT para autenticação.</returns>
    /// <response code="200">Login realizado com sucesso.</response>
    /// <response code="401">Credenciais inválidas.</response>
    [HttpPost("service-token")]
    public IActionResult GenerateServiceToken([FromBody] ServiceTokenRequest request) => Ok(_service.WorkerLogin(request));
}
