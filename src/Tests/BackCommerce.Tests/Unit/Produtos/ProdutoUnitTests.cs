using BackCommerce.Domain.Produtos;
using BackCommerce.Domain.Promocoes;
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
        string marca = "JBl";

        // Act
        var produto = new Produto(descricao, valor, imagem, categoria, marca);

        // Assert
        Assert.NotNull(produto);
    }

    [Theory]
    [InlineData(10, TipoDescontoEnum.Porcentagem, 90)]
    [InlineData(20, TipoDescontoEnum.Porcentagem, 80)]
    [InlineData(10, TipoDescontoEnum.ValorFixo, 90)]
    public void Deve_Adicionar_Desconto_Ao_Produto(decimal desconto, TipoDescontoEnum tipoDesconto, decimal resultado)
    {
        // Arrange
        var produto = CriarProduto();

        //Act
        produto.AdicionarDesconto(desconto, tipoDesconto);

        //Assert
        Assert.Equal(resultado, produto.ValorComDesconto);
    }

    private Produto CriarProduto()
    {
        Produto produto = new("Produto 01", 100, "Imagem 01", "Categoria 01", "Marca 01");

        return produto;
    }

}