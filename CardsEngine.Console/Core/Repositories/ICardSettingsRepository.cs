using CardsEngine.Console.DataContext.Models;

namespace CardsEngine.Console.Core.Repositories
{
    public interface ICardSettingsRepository
    {
        CardSettingByBrands GetByBrand(string brand); 
    }
}
