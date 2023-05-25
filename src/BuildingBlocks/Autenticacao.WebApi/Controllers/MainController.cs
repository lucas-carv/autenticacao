using Microsoft.AspNetCore.Mvc;

namespace Autenticacao.WebApi.Controllers;

[ApiController]
public class MainController : ControllerBase
{

    public bool CustomResponse()
    {
        return true;
    }

}