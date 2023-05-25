using Autenticacao.API.Models.InputModels;
using Autenticacao.API.Services;
using Autenticacao.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Autenticacao.API.Controllers;

[ApiController]
public class IdentityController : MainController
{
    private readonly IIdentityUsuarioServices _identityUsuarioServices;

    public IdentityController(IIdentityUsuarioServices identityUsuarioServices)
    {
        _identityUsuarioServices = identityUsuarioServices;
    }

    [HttpPost("cadastrar")]

    public async Task<ActionResult> CadastrarNovoUsuario(NovoUsuarioInputModel inputModel)
    {
        var response = await _identityUsuarioServices.CadastrarUsuario(inputModel.Login, inputModel.Senha);

        if (!response)
            return BadRequest();

        return Ok();
    }


}
