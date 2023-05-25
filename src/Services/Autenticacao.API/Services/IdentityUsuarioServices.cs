using Autenticacao.API.Models.InputModels;
using Microsoft.AspNetCore.Identity;

namespace Autenticacao.API.Services;

public class IdentityUsuarioServices : IIdentityUsuarioServices
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    public IdentityUsuarioServices(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<bool> Autenticar(string login, string senha)
    {
        IdentityUser user = new(login);

        var result = await _signInManager.PasswordSignInAsync(user, senha, false, true);

        if (!result.Succeeded)
            return false;

        return true;
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
