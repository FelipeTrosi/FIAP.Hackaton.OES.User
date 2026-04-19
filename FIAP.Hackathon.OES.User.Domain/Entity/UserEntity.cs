using FIAP.Hackathon.OES.User.Domain.Entity.Abstracts;
using FIAP.Hackathon.OES.User.Domain.Enums.User;

namespace FIAP.Hackathon.OES.User.Domain.Entity;

public class UserEntity : EntityBase
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string CPF { get; set; } = null!;
    public string Password { get; set; } = null!;
    public AccessLevelEnum AccessLevel { get; set; }
}
