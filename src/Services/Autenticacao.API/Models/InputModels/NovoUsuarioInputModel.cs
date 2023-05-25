using System.ComponentModel.DataAnnotations;

namespace Autenticacao.API.Models.InputModels;

public class NovoUsuarioInputModel
{
    public string Login { get; set; }
    public string Senha { get; set; }
    [Compare(nameof(Senha), ErrorMessage = "As senhas devem ser iguais")]
    public string ConfirmacaoSenha { get; set; }

}
