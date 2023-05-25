namespace Autenticacao.API.Models.DomainObjects;

public class UsuarioLoginResponse
{
    public string AcessToken { get; set; }
    public DateTime DataExpiracao { get; set; }
}
