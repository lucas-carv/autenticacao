using BackCommerce.Domain.Produtos;
using Xunit;

namespace BackCommerce.Tests.Unit.Produtos;

public class ProdutoUnitTests
{
    [Fact]
    public void Deve_Cadastrar_Produto()
    {
        // Arrange
        string descricao = "Fone de ouvido";
        decimal valor = 100;
        string imagem = "Imagem";
        string categoria = "Eletronico";
        int quantidadeEmEstoque = 1;

        // Act
        var produto = new Produto(descricao, valor, imagem, categoria, quantidadeEmEstoque);

        // Assert
        Assert.NotNull(produto);
    }
}