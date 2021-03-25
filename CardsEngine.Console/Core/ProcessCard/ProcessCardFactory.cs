using CardsEngine.Console.Core.Model;
using CardsEngine.Console.Core.ProcessCards.Impl;
using CardsEngine.Console.Core.Repositories;
using Microsoft.Extensions.Logging;
using System;

namespace CardsEngine.Console.Core.Cards
{
    public class ProcessCardFactory
    {
        private readonly ILogger logger;
        private readonly ICardSettingsRepository cardSettingsRepository;

        public ProcessCardFactory(ILogger logger, ICardSettingsRepository cardSettingsRepository)
        {
            this.logger = logger;
            this.cardSettingsRepository = cardSettingsRepository;
        }

        public ProcessCard Create(Policy policy)
        {
            try
            {
                return (ProcessCard)Activator.CreateInstance(
                    Type.GetType($"CardsEngine.Console.Core.ProcessCards.Impl.ProcessCard{policy.Brand}"),
                        new object[] { policy, logger, cardSettingsRepository });
            }
            catch
            {
                return new ProcessCardUnknown(policy, logger);
            }
        }
    }
}
