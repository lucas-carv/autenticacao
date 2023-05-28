namespace BackCommerce.Domain.Promocoes;

public class Cupom 
{
    public string NomeCupom { get; set; }
    public decimal Valor { get; set; }
    public TiposCupomEnum TipoCupom { get; set; }
    public TipoValorCupom TipoValor { get; set; }
    public Cupom(string nomeCupom, decimal valor, TiposCupomEnum tipoCupom, TipoValorCupom tipoValor)
    {
        NomeCupom = nomeCupom;
        Valor = valor;
        TipoCupom = tipoCupom;
        TipoValor = tipoValor;
    }
}
