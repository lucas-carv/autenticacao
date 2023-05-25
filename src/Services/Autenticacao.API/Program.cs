using Autenticacao.API.Extensions;
using Autenticacao.API.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

if (IsDevelopment())
{
    configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.development.json")
    .Build();
}

//var stringDeConexao = configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
var stringDeConexao = configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AutenticacaoContext>(opt => opt.UseMySql(stringDeConexao, ServerVersion.AutoDetect(stringDeConexao)));
builder.Services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AutenticacaoContext>()
                .AddDefaultTokenProviders();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddServicesConfiguration();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();


bool IsDevelopment()
{
    return string.Compare(System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"), "development", true) == 0;
}


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
