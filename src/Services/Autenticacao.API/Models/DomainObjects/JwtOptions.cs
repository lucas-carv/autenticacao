using Microsoft.IdentityModel.Tokens;

namespace Autenticacao.API.Models.DomainObjects;

public class JwtOptions
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public SigningCredentials SigningCredentials { get; set; }
    public double Expiration { get; set; }
}
