using Autenticacao.API.Models.InputModels;
using Microsoft.AspNetCore.Identity;

namespace Autenticacao.API.Services;

public class IdentityUsuarioServices : IIdentityUsuarioServices
{
    private readonly UserManager<IdentityUser> _userManager;
    public IdentityUsuarioServices(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<bool> CadastrarUsuario(string login, string senha)
    {
        IdentityUser user = new(login)
        {
            EmailConfirmed = true
        };

        var result = await _userManager.CreateAsync(user, senha);

        if (!result.Succeeded)
            return false;

        return true;

    }
}
