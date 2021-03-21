using CardsEngine.Console.Core.Cards;
using CardsEngine.Console.Core.Dto;
using CardsEngine.Console.Core.Model;
using Microsoft.Extensions.Logging;
using System;

namespace CardsEngine.Console.Core.ProcessCards.Impl
{
    public class ProcessCardUnknown : ProcessCard
    {
        public ProcessCardUnknown(Policy policy, ILogger logger) : base(policy, logger)
        {
        }

        public override decimal GetCommission() => throw new Exception("Unknown type");

        public override GenericReponse<bool> IsValid() => throw new Exception("Unknown type");
    }
}
