using Autenticacao.API.Infrastructure;
using Autenticacao.API.Models.Domain;
using Autenticacao.API.Services;
using Microsoft.AspNetCore.Identity;

namespace Autenticacao.API.Extensions;

public static class ServicesConfiguration
{
    public static void AddServicesConfiguration(this IServiceCollection services)
    {
        //services.AddDbContext<AutenticacaoContext>();

        services.AddScoped<IIdentityUsuarioServices, IdentityUsuarioServices>();
        services.AddScoped<HttpContextAccessor>();
    }
}
