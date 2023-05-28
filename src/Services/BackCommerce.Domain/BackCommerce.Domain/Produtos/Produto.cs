using BackCommerce.Domain.Promocoes;

namespace BackCommerce.Domain.Produtos;

public class Produto
{
    public string Descricao { get; private set; }
    public decimal ValorTotal { get; private set; }
    public decimal ValorComDesconto { get; set; }
    public string Imagem { get; private set; }
    public string Categoria { get; private set; }
    public int QuantidadeEmEstoque { get; private set; }
    public string Marca { get; set; }
    public Desconto Desconto { get; set; }
    public Produto(string descricao, decimal valor, string imagem, string categoria, string marca)
    {
        if (string.IsNullOrEmpty(descricao))
            throw new Exception("O produto deve ter uma descrição");
        if (valor <= 0)
            throw new Exception("O valor do produto deve ser maior que zero");
        if (string.IsNullOrEmpty(imagem))
            throw new Exception("O produto deve ter uma imagem");
        if (string.IsNullOrEmpty(categoria))
            throw new Exception("O produto deve ter uma categoria");

        Descricao = descricao;
        ValorTotal = valor;
        Imagem = imagem;
        Categoria = categoria;
        Marca = marca;
    }

    public void AdicionarEstoque(int quantidade)
    {
        QuantidadeEmEstoque += quantidade;
    }

    public void AdicionarDesconto(decimal valorDesconto, TipoDescontoEnum tipoDesconto)
    {
        Desconto desconto = new(this, valorDesconto, tipoDesconto);

        Desconto = desconto;
        ValorComDesconto = Desconto.ValorFinal;
    }
}