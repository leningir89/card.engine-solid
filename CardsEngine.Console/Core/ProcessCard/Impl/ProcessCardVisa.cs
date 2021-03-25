using CardsEngine.Console.Core.BusinessValidations;
using CardsEngine.Console.Core.Cards;
using CardsEngine.Console.Core.Dto;
using CardsEngine.Console.Core.Helpers;
using CardsEngine.Console.Core.Model;
using CardsEngine.Console.Core.Repositories;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace CardsEngine.Console.Core.ProcessCards.Impl
{
    public class ProcessCardVisa : ProcessCard
    {
        public ProcessCardVisa(Policy policy, ILogger logger, ICardSettingsRepository cardSettingsRepository) : 
            base(policy, logger, cardSettingsRepository)
        {
            this.businessValidations = new BusinessValidationFactory().Create(policy);

        }

        public override decimal GetCommission()
        {
            decimal commission = 4.9m;
            var result = this.cardSettingsRepository.GetByBrand(policy.Brand.ToString());
            if(result != null)
            {
                commission = result.PromotionCommission ?? result.BaseCommission;
            }
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
