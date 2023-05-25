using Autenticacao.API.Models.InputModels;
using Autenticacao.API.Services;
using Autenticacao.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Autenticacao.API.Controllers;

[Route("api/autenticacao")]
public class IdentityController : MainController
{
    private readonly IIdentityUsuarioServices _identityUsuarioServices;

    public IdentityController(IIdentityUsuarioServices identityUsuarioServices)
    {
        _identityUsuarioServices = identityUsuarioServices;
    }

    [HttpPost("autenticar")]
    public async Task<ActionResult> Autenticar(string login, string senha)
    {
        var response = await _identityUsuarioServices.Autenticar(login, senha);
        if (!response)
            return BadRequest();

        return Ok();
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
