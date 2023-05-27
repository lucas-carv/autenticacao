namespace BackCommerce.Domain.Produtos;

public class Produto
{
    public string Descricao { get;private set; }
    public decimal Valor { get;private set; }
    public string Imagem { get; private set; }
    public string Categoria { get; private set; }
    public int QuantidadeEmEstoque { get; private set; }
    public Produto(string descricao, decimal valor, string imagem, string categoria, int quantidadeEmEstoque)
    {
        if (string.IsNullOrEmpty(descricao))
            throw new Exception("O produto deve ter uma descrição");
        if (valor <= 0)
            throw new Exception("O valor do produto deve ser maior que zero");
        if (string.IsNullOrEmpty(imagem))
            throw new Exception("O produto deve ter uma imagem");
        if (string.IsNullOrEmpty(categoria))
            throw new Exception("O produto deve ter uma categoria");
        if(quantidadeEmEstoque <= 0)
            throw new Exception("O produto deve ter um estoque de no mínimo 1");

        Descricao = descricao;
        Valor = valor;
        Imagem = imagem;
        Categoria = categoria;
        QuantidadeEmEstoque = quantidadeEmEstoque;
    }
}