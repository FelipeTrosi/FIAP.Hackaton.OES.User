namespace IAP.Hackaton.OES.User.Service.Dto.Login;

/// <summary>
/// DTO usado para autenticação de usuários no sistema.
/// </summary>
public class LoginDto
{
    /// <summary>
    /// Email utilizado no login.
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// Senha de acesso do usuário.
    /// </summary>
    public string Password { get; set; } = null!;
}
