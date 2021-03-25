using CardsEngine.Console.DataContext.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardsEngine.Console.DataContext.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var _context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());
            //if (_context.CardSettingByBrands != null)
            //{
            //    return;
            //}

            _context.CardSettingByBrands.AddRange(
                new CardSettingByBrands { CardSettingByBrandsID = 1, BaseCommission = 0.39m, PromotionCommission = null, Brand = "Visa" },
                new CardSettingByBrands { CardSettingByBrandsID = 2, BaseCommission = 0.42m, PromotionCommission = null, Brand = "AmericanExpress" },
                new CardSettingByBrands { CardSettingByBrandsID = 3, BaseCommission = 0.38m, PromotionCommission = 0.29m, Brand = "Mastercard" }
             );


            _context.SaveChanges();
        }
    }
}
