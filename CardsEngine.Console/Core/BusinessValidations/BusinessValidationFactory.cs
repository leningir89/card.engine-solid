using CardsEngine.Console.Core.BusinessValidations.Impl;
using CardsEngine.Console.Core.Model;
using System;

namespace CardsEngine.Console.Core.BusinessValidations
{
    public class BusinessValidationFactory
    {
        public BusinessValidationFactory()
        {
        }

        public IBusinessValidations Create(Policy policy)
        {
            try
            {
                return (IBusinessValidations)Activator.CreateInstance(
                    Type.GetType($"CardsEngine.Console.Core.BusinessValidations.Impl.BusinessValidations{policy.Brand}"),
                        new object[] {  });
            }
            catch
            {
                return new BusinessValidationUnknown();
            }
        }
    }
}
