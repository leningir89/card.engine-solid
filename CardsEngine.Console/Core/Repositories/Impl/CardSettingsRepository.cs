using CardsEngine.Console.DataContext;
using CardsEngine.Console.DataContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardsEngine.Console.Core.Repositories.Impl
{
    public class CardSettingsRepository : ICardSettingsRepository
    {
        private readonly AppDbContext context;
        public CardSettingsRepository(AppDbContext ctx)
        {
            context = ctx;
        }
        public CardSettingByBrands GetByBrand(string brand)
        {
            return this.context.CardSettingByBrands.Where(x => x.Brand == brand).FirstOrDefault();
        }
    }
}
