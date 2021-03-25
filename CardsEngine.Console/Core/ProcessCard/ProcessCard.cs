using CardsEngine.Console.Core.BusinessValidations;
using CardsEngine.Console.Core.Dto;
using CardsEngine.Console.Core.Model;
using CardsEngine.Console.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace CardsEngine.Console.Core.Cards
{
    public abstract class ProcessCard
    {
        public Policy policy;
        public IBusinessValidations businessValidations { get; set; }
        public ICardSettingsRepository cardSettingsRepository { get; set; }
        protected ProcessCard(Policy policy, ILogger logger, ICardSettingsRepository cardSettingsRepository)
        {
            this.policy = policy;
            Logger = logger;
            this.cardSettingsRepository = cardSettingsRepository;
        }
        protected ProcessCard(Policy policy, ILogger logger)
        {
            this.policy = policy;
            Logger = logger;
        }
        public CardSettings CardSettings { get; set; }
        public ILogger Logger { get; set; }
        public abstract decimal GetCommission();
        public abstract GenericReponse<bool> IsValid();
    }
}
