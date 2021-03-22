using CardsEngine.Console.Core.Dto;
using CardsEngine.Console.Core.Enums;
using System;

namespace CardsEngine.Console.Core.BusinessValidations.Impl
{
    public class BusinessValidationUnknown : IBusinessValidations
    {
        public GenericReponse<bool> IsValidAmount(DeferPaymentType deferralPayment, decimal amount) => throw new Exception("BusinessValidation Unknown type");

        public GenericReponse<bool> IsValidDeferralPayment(DeferPaymentType deferralPayment) => throw new Exception("BusinessValidation Unknown type");
    }
}
