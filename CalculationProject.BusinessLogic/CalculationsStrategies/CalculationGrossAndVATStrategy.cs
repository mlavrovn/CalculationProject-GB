using CalculationProject.BusinessLogic.Entities;
using CalculationProject.BusinessLogic.Entities.Responses;
using CalculationProject.BusinessLogic.Interfaces;

namespace CalculationProject.BusinessLogic.CalculationsStrategies
{
    public class CalculationGrossAndVATStrategy : ICalculationStrategy
    {
        private readonly decimal _net;
        private readonly decimal _vatRate;

        public CalculationGrossAndVATStrategy(decimal net, VATRate vatRate)
        {
            _net = net;
            _vatRate = (decimal)vatRate / 100m;
        }

        public CalculationResponse Calculate()
        {
            var gross = _net * (1 + _vatRate);
            var vat = gross - _net;

            return new GrossAndVATResponse
            {
                Gross = Math.Round(gross, 2),
                VAT = Math.Round(vat, 2),
            };
        }
    }
}