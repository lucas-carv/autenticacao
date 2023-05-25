namespace Autenticacao.API.Models.DomainObjects;

public class AspNetUser : IAspNetUser
{
    private readonly HttpContextAccessor _contextAccessor;

    public AspNetUser(HttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public bool EstaAutenticado()
    {
        return _contextAccessor.HttpContext.User.Identity.IsAuthenticated;
    }
}
