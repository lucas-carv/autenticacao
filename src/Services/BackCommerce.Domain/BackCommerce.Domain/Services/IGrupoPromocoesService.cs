using BackCommerce.Domain.Promocoes;

namespace BackCommerce.Domain.Services;

public interface IGrupoPromocoesService
{
    void CalcularPromocao();
}

public class GrupoPromocoesService : IGrupoPromocoesService
{
    public void CalcularPromocao()
    {
        throw new NotImplementedException();
    }
}