using Autenticacao.API.Models.DomainObjects;
using Autenticacao.API.Models.InputModels;
using Autenticacao.API.Services;
using Autenticacao.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Autenticacao.API.Controllers;

[Route("api/autenticacao")]
public class IdentityController : MainController
{
    private readonly IIdentityUsuarioServices _identityUsuarioServices;
    private readonly IAspNetUser _aspNetUser;

    public IdentityController(IIdentityUsuarioServices identityUsuarioServices, IAspNetUser aspNetUser)
    {
        _identityUsuarioServices = identityUsuarioServices;
        _aspNetUser = aspNetUser;
    }

    [HttpPost("autenticar")]
    public async Task<ActionResult> Autenticar(string login, string senha)
    {
        var usuario = await _identityUsuarioServices.Autenticar(login, senha);
        if (usuario != null)
        {
            return Ok(usuario);
        }

        return BadRequest();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="inputModel"></param>
    /// <returns></returns>
    [HttpPost("cadastrar")]
    public async Task<ActionResult> CadastrarNovoUsuario(NovoUsuarioInputModel inputModel)
    {
        var response = await _identityUsuarioServices.CadastrarUsuario(inputModel.Login, inputModel.Senha);

        if (!response)
            return BadRequest();

        return Ok();
    }


}
