using BackCommerce.Domain.Produtos;

namespace BackCommerce.Domain.Promocoes;

public class Desconto
{
    public Produto Produto { get; set; }
    public decimal ValorBaseDoProduto { get; set; }
    public decimal ValorDoDesconto { get; set; }
    public decimal ValorFinal { get; set; }
    public TipoDescontoEnum TipoDescontoEnum { get; set; }

    public Desconto(Produto produto, decimal valorDoDesconto, TipoDescontoEnum tipoDescontoEnum)
    {
        ValorBaseDoProduto = produto.ValorTotal;
        ValorDoDesconto = valorDoDesconto;
        TipoDescontoEnum = tipoDescontoEnum;

        switch (tipoDescontoEnum)
        {
            case TipoDescontoEnum.ValorFixo:
                ValorFinal = produto.ValorTotal - valorDoDesconto;
                break;
            case TipoDescontoEnum.Porcentagem:
                ValorFinal = produto.ValorTotal - (produto.ValorTotal * (valorDoDesconto / 100));
                break;
            default:
                break;
        }
    }
}
