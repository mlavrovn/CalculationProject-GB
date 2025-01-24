using CalculationProject.BusinessLogic.Entities;
using CalculationProject.BusinessLogic.Entities.Responses;
using CalculationProject.BusinessLogic.Interfaces;

namespace CalculationProject.BusinessLogic.Services
{
    public class CalculationService : ICalculationService
    {
        private readonly ICalculationStrategyFactory _calculationStrategyFactory;

        public CalculationService(ICalculationStrategyFactory calculationStrategyFactory)
        {
            _calculationStrategyFactory = calculationStrategyFactory;
        }

        public CalculationResponse Calculate(CalculationRequest request)
        {
            var calculationStrategy = _calculationStrategyFactory.Create(request);

            return calculationStrategy.Calculate();
        }
    }
}
