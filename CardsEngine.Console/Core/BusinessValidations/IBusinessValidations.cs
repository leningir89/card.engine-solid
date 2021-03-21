using CardsEngine.Console.Core.Dto;
using CardsEngine.Console.Core.Enums;

namespace CardsEngine.Console.Core.BusinessValidations
{
    public interface IBusinessValidations
    {
        public abstract GenericReponse<bool> IsValidDeferralPayment(DeferPaymentType deferralPayment);
        public abstract GenericReponse<bool> IsValidAmount(DeferPaymentType deferralPayment, decimal amount);

    }
}
