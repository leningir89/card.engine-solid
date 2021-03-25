using CardsEngine.Console.Core;
using CardsEngine.Console.Core.Cards;
using CardsEngine.Console.Core.Enums;
using CardsEngine.Console.Core.Model;
using CardsEngine.Console.Core.Repositories;
using CardsEngine.Console.Core.Repositories.Impl;
using CardsEngine.Console.DataContext;
using CardsEngine.Console.DataContext.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Text.Json;

namespace CardsEngine.Consoles
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var context = serviceProvider.GetRequiredService<AppDbContext>();
            DbInitializer.Initialize(serviceProvider);

            var engine = new CardEngine(null, new ProcessCardFactory(null, new CardSettingsRepository(context)), new Policy { Brand = BrandType.Mastercard, Amount = 40, 
                DeferPayment = DeferPaymentType.OnePayment });
            try
            {
                var response =  engine.CreatePayment();
                System.Console.WriteLine(JsonSerializer.Serialize(response));
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);

            }
            System.Console.ReadLine();
        }

        private static void ConfigureServices(ServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICardSettingsRepository, CardSettingsRepository>()
                .AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("test"));
        }
    }
}
