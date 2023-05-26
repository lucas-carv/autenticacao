using Autenticacao.API.Models.DomainObjects;
using Autenticacao.API.Models.InputModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Autenticacao.API.Services;

public class IdentityUsuarioServices : IIdentityUsuarioServices
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly JwtOptions _jwtOptions;
    public IdentityUsuarioServices(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IOptions<JwtOptions> jwtOptions)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtOptions = jwtOptions.Value;
    }

    public async Task<UsuarioLoginResponse> Autenticar(string login, string senha)
    {
        var result = await _signInManager.PasswordSignInAsync(login, senha, false, true);

        if (!result.Succeeded)
        {
            UsuarioLoginResponse usuarioLogin = new();

            if (result.IsLockedOut)
                usuarioLogin.AdicionarErro("Usuário temporariamente bloqueado");
            else if (result.IsNotAllowed)
                usuarioLogin.AdicionarErro("Essa conta não tem permissão para fazer login");
            else if (result.RequiresTwoFactor)
                usuarioLogin.AdicionarErro("E necessario realizar a segunda validação");
            else
                usuarioLogin.AdicionarErro("Usuário ou senha estão incorretos");

            return usuarioLogin;
        }

        return await GerarJwt(login);
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


    private async Task<UsuarioLoginResponse> GerarJwt(string login)
    {
        var user = await _userManager.FindByNameAsync(login);
        var claims = await ObterClaims(user);
        var dataExpiracao = DateTime.UtcNow.AddMinutes(_jwtOptions.Expiration);

        var jwt = new JwtSecurityToken(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: claims,
            notBefore: DateTime.Now,
            expires: dataExpiracao,
            signingCredentials: _jwtOptions.SigningCredentials);

        var token = new JwtSecurityTokenHandler().WriteToken(jwt);

        return new UsuarioLoginResponse
        {
            AcessToken = token,
            DataExpiracao = dataExpiracao
        };
    }

    private async Task<IList<Claim>> ObterClaims(IdentityUser user)
    {
        var claims = await _userManager.GetClaimsAsync(user);
        var roles = await _userManager.GetRolesAsync(user);
        claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
        claims.Add(new Claim(JwtRegisteredClaimNames.Name, user.UserName));
        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()));
        foreach (var role in roles)
        {
            claims.Add(new Claim("role", role));
        }

        return claims;
    }
}
