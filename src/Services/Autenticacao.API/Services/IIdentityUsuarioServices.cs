using Autenticacao.API.Models.DomainObjects;
using Autenticacao.API.Models.InputModels;

namespace Autenticacao.API.Services;

public interface IIdentityUsuarioServices
{
    Task<UsuarioLoginResponse> Autenticar(string login, string senha);
    Task<bool> CadastrarUsuario(string login, string senha);
}