using CalculationProject.BusinessLogic.CalculationsStrategies;
using CalculationProject.BusinessLogic.Entities;
using CalculationProject.BusinessLogic.Interfaces;

namespace CalculationProject.BusinessLogic.Services
{
    public class CalculationStrategyFactory : ICalculationStrategyFactory
    {
        public ICalculationStrategy Create(CalculationRequest request)
        {
            return request.CalculationByType switch
            {
                CalculationByType.Net => new CalculationGrossAndVATStrategy(request.Amount, request.VATRate),
                CalculationByType.Gross => new CalculationNetAndVATStrategy(request.Amount, request.VATRate),
                CalculationByType.VAT => new CalculationNetAndGrossStrategy(request.Amount, request.VATRate),
                _ => throw new ArgumentException("Unsupported request type.")
            };
        }
    }
}
