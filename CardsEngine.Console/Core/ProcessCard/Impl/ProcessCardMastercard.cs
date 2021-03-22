using CardsEngine.Console.Core.BusinessValidations;
using CardsEngine.Console.Core.Cards;
using CardsEngine.Console.Core.Dto;
using CardsEngine.Console.Core.Helpers;
using CardsEngine.Console.Core.Model;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace CardsEngine.Console.Core.ProcessCards.Impl
{
    public class ProcessCardMastercard : ProcessCard
    {
        public ProcessCardMastercard(Policy policy, ILogger logger) : base(policy, logger)
        {
            this.businessValidations = new BusinessValidationFactory().Create(policy);
        }

        public override decimal GetCommission()
        {
            var commission = CardSettings.PromotionCommission??CardSettings.BaseCommission;
            return (commission * policy.Amount);
        }

        public override GenericReponse<bool> IsValid()
        {
            var response = new GenericReponse<bool>(false, 
                GenerateErrorHelper.SetError("Error en la validación del request."));

            var resultReferral = businessValidations.IsValidDeferralPayment(policy.DeferPayment);
            if (!resultReferral.Data)
            {
                response.Error.ValidationErrors.Add(resultReferral.Error.ValidationErrors[0]);
            }

            var resultAmount = businessValidations.IsValidAmount(policy.DeferPayment,policy.Amount);
            if (!resultAmount.Data)
            {
                response.Error.ValidationErrors.Add(resultAmount.Error.ValidationErrors[0]);
            }
            if (response.Error.ValidationErrors.Any()) return response;

            return new GenericReponse<bool>(true, null);
        }
    }
}
