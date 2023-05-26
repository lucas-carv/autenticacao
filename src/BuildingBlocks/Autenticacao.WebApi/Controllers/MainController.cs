using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Autenticacao.WebApi.Controllers;

[ApiController]
public class MainController : ControllerBase
{
    protected ICollection<string> Erros = new List<string>();
    protected ActionResult CustomResponse(object result = null)
    {
        if (OperacaoValida())
            return Ok(result);

        return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Mensagens", Erros.ToArray() }
            }));

    }

    protected bool OperacaoValida()
    {
        return !Erros.Any();
    }

    protected void AdicionarErroProcessamento(string erro)
    {
        Erros.Add(erro);
    }
}