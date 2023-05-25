using Autenticacao.API.Models.InputModels;

namespace Autenticacao.API.Services;

public interface IIdentityUsuarioServices
{
    Task<bool> CadastrarUsuario(string login, string senha);
}