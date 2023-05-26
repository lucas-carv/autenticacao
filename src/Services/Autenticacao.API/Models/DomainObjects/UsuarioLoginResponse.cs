using Microsoft.AspNetCore.Server.IIS.Core;

namespace Autenticacao.API.Models.DomainObjects;

public class UsuarioLoginResponse
{
    public string AcessToken { get; set; }
    public DateTime DataExpiracao { get; set; }
    public List<string> Erros { get; set; } = new();

    public void AdicionarErro(string erro)
    {
        Erros.Add(erro);
    }
}
