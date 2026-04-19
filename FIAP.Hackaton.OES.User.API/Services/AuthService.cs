using FIAP.Hackaton.OES.User.Domain.Enums.User;
using FIAP.Hackaton.OES.User.Service.Interfaces;
using IAP.Hackaton.OES.User.Service.Dto.Login;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FIAP.Hackaton.OES.User.API.Services;

public class AuthService(IConfiguration configuration, IUserService service) : IAuthService
{
    private readonly IUserService _service = service;
    private readonly IConfiguration _configuration = configuration;

    public string Login(LoginDto input)
    {
        var result = _service.GetByUserAndPassword(input.Email, input.Password);

        switch (result.AccessLevel)
        {
            case AccessLevelEnum.DONOR:
                return GenerateJwtToken(input.Email, "DONOR");
            case AccessLevelEnum.MANAGER:
                return GenerateJwtToken(input.Email, "MANAGER");
            default:
                return GenerateJwtToken(input.Email, "DONOR");
        }

    }

    private string GenerateJwtToken(string userId, string role)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId),
            new Claim(ClaimTypes.Role, role),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!)), SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}
