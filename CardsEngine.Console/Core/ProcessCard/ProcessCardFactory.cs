using CardsEngine.Console.Core.Model;
using CardsEngine.Console.Core.ProcessCards.Impl;
using Microsoft.Extensions.Logging;
using System;

namespace CardsEngine.Console.Core.Cards
{
    public class ProcessCardFactory
    {
        private readonly ILogger logger;

        public ProcessCardFactory(ILogger logger)
        {
            this.logger = logger;
        }

        public ProcessCard Create(Policy policy)
        {
            try
            {
                return (ProcessCard)Activator.CreateInstance(
                    Type.GetType($"CardsEngine.Console.Core.ProcessCards.Impl.ProcessCard{policy.Brand}"),
                        new object[] { policy, logger });
            }
            catch
            {
                return new ProcessCardUnknown(policy, logger);
            }
        }
    }
}
