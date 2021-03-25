using CardsEngine.Console.Core.Dto;
using CardsEngine.Console.Core.Enums;
using System.Collections.Generic;

namespace CardsEngine.Console.Core.BusinessValidations.Impl
{
    public class BusinessValidationsVisa : IBusinessValidations
    {
        public GenericReponse<bool> IsValidAmount(DeferPaymentType deferralPayment, decimal amount)
        {
            switch (deferralPayment)
            {
                case DeferPaymentType.OnePayment:
                    break;
                case DeferPaymentType.ThreeMonths:
                    return new GenericReponse<bool> { Data = false, Error = new Model.Error { ValidationErrors = new List<string> { "El Pago minimo es de $300.00 MXN." } } };                   
                case DeferPaymentType.SixMonths:
                    break;
                case DeferPaymentType.NineMonths:                   
                    break;
                case DeferPaymentType.TwelveMonths:                    
                    break;               
                default:
                    return new GenericReponse<bool> { Data = false, Error = new Model.Error { ValidationErrors = new List<string> { "Valores permitidos 1, 3, 6 y 12.." } } };
            }
            return new GenericReponse<bool> { Data = true };

        }

        public virtual GenericReponse<bool> IsValidDeferralPayment(DeferPaymentType deferralPayment)
        {
            switch (deferralPayment)
            {
                case DeferPaymentType.OnePayment:
                    break;
                case DeferPaymentType.ThreeMonths:
                    break;
                case DeferPaymentType.SixMonths:
                    return new GenericReponse<bool> { Data = false, Error = new Model.Error { ValidationErrors = new List<string> { "No puedes pagar a 6 meses con esta marca de tarjeta" } } };
                case DeferPaymentType.NineMonths:
                    return new GenericReponse<bool> { Data = false, Error = new Model.Error { ValidationErrors = new List<string> { "No puedes pagar a 9 meses con esta marca de tarjeta" } } };
                case DeferPaymentType.TwelveMonths:
                    return new GenericReponse<bool> { Data = false, Error = new Model.Error { ValidationErrors = new List<string> { "No puedes pagar a 12 meses con esta marca de tarjeta" } } };

            }

            return new GenericReponse<bool> { Data = true};
        }
    }
}
