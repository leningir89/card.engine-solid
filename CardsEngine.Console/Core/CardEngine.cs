using CardsEngine.Console.Core.BusinessValidations;
using CardsEngine.Console.Core.Cards;
using CardsEngine.Console.Core.Dto;
using CardsEngine.Console.Core.Model;
using Microsoft.Extensions.Logging;

namespace CardsEngine.Console.Core
{
    public class CardEngine
    {
        private readonly ILogger logger;
        private readonly ProcessCardFactory cardFactory;
        private readonly ProcessCard processCard;

        public CardEngine(ILogger logger, ProcessCardFactory cardFactory, Policy policy)
        {
            this.logger = logger;
            this.cardFactory = cardFactory;
            this.processCard = cardFactory.Create(policy);

        }

        public GenericReponse<PaymentResponse> CreatePayment()
        {
            var resultValid = processCard.IsValid();
            if (!resultValid.Data)
            {
                return new GenericReponse<PaymentResponse>
                {
                    Data = null,
                    Error = resultValid.Error
                };
            }
            var commission = processCard.GetCommission();
            return new GenericReponse<PaymentResponse>
            {
                Data = new PaymentResponse
                {
                    Commission = commission
                }
                //Total = commission + processCard.Amount
            };
        }
    }
}
