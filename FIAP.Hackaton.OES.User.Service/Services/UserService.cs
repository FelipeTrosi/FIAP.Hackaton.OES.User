using FIAP.Hackaton.OES.User.Infra.Logger;
using FIAP.Hackaton.OES.User.Infra.Repository.Interfaces;
using FIAP.Hackaton.OES.User.Service.Dto.User;
using FIAP.Hackaton.OES.User.Service.Exceptions;
using FIAP.Hackaton.OES.User.Service.Interfaces;
using FIAP.Hackaton.OES.User.Service.Util;

namespace FIAP.Hackaton.OES.User.Service.Services;

public class UserService(IBaseLogger<UserService> logger, IUserRepository repository) : IUserService
{
    private readonly IUserRepository _repository = repository;
    private readonly IBaseLogger<UserService> _logger = logger;

    public async Task Create(UserCreateDto entity)
    {
        var errors = new Dictionary<string, string[]>();

        _logger.LogInformation("Iniciando serviço 'CREATE' de usuário !");

        if (!ValidatorService.IsValidEmail(entity.Email))
        {
            _logger.LogError("Email inválido");
            errors["Email"] = ["Email inválido"];
        }

        if (_repository.GetByEmail(entity.Email) != null)
        {
            _logger.LogError("Já existe um usuário com esse email cadastrado");
            errors["Email"] = ["Já existe um usuário com esse email cadastrado"];
        }

        if (!ValidatorService.IsValidPassword(entity.Password))
        {
            _logger.LogError("Senha deve conter letras, números e caracteres especiais, com pelo menos 8 caracteres.");
            errors["Senha"] = ["Senha deve conter letras, números e caracteres especiais, com pelo menos 8 caracteres."];
        }

        if (errors.Any())
            throw new BadRequestException("Erro de validação", errors);

        var createdUser = _repository.Create(new()
        {
            AccessLevel = entity.AccessLevel,
            CreatedAt = DateTime.Now,
            Email = entity.Email.Trim().ToLower(),
            Name = entity.Name,
            Password = PasswordHasher.Hash(entity.Password),
            CPF = entity.CPF
        });

        _logger.LogInformation("Usuário cadastrado com sucesso !");


    }

    public void DeleteById(long id)
    {
        _logger.LogInformation($"Iniciando serviço 'DELETE' por Id: {id} de usuário !");

        var entity = _repository.GetById(id);

        if (entity == null)
        {
            _logger.LogWarning($"Registro não encontrado para o id: {id}");
            throw new NotFoundException($"Registro não encontrado para o id: {id}");
        }

        _repository.DeleteById(id);

        _logger.LogInformation($"Usuário com id {id} removido com sucesso !");
    }

    public ICollection<UserOutputDto> GetAll()
    {
        _logger.LogInformation("Iniciando serviço 'GETALL' de usuário !");

        return ParseModel.Map<ICollection<UserOutputDto>>(_repository.GetAll());
    }

    public UserOutputDto? GetById(long id)
    {
        _logger.LogInformation($"Iniciando serviço 'GET' por Id: {id} de usuário !");

        var result = _repository.GetById(id);

        if (result != null)
            return ParseModel.Map<UserOutputDto>(result);
        else
        {
            _logger.LogWarning($"Usuário com Id: {id} não encontrado !");
            throw new NotFoundException($"Registro não encontrado para o id: {id}"); ;
        }
    }

    public void Update(UserUpdateDto entity)
    {
        var errors = new Dictionary<string, string[]>();

        _logger.LogInformation($"Iniciando serviço 'UPDATE' de usuário com Id {entity.Id}!");

        if (!ValidatorService.IsValidEmail(entity.Email))
        {
            _logger.LogError("Email inválido");
            errors["Email"] = ["Email inválido"];
        }

        if (!ValidatorService.IsValidPassword(entity.Password))
        {
            _logger.LogError("Senha deve conter letras, números e caracteres especiais, com pelo menos 8 caracteres.");
            errors["Senha"] = ["Senha deve conter letras, números e caracteres especiais, com pelo menos 8 caracteres."];
        }

        if (errors.Any())
            throw new BadRequestException("Erro de validação", errors);

        _repository.Update(new()
        {
            Id = entity.Id,
            AccessLevel = entity.AccessLevel,
            CreatedAt = entity.CreatedAt,
            Email = entity.Email.Trim().ToLower(),
            Name = entity.Name,
            Password = PasswordHasher.Hash(entity.Password),
            CPF = entity.CPF,
        });

        _logger.LogInformation($"Usuário com Id {entity.Id} atualizado com sucesso !");
    }

    public UserOutputDto GetByUserAndPassword(string email, string password)
    {
        var result = _repository.GetByEmail(email);

        if (result == null || !PasswordHasher.Verify(password, result.Password))
            throw new UnauthorizedException("Login inválido !");
        
        return ParseModel.Map<UserOutputDto>(result);
    }


}
