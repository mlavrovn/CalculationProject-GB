using CalculationProject.BusinessLogic.Entities;
using CalculationProject.BusinessLogic.Entities.Responses;
using CalculationProject.BusinessLogic.Interfaces;

namespace CalculationProject.BusinessLogic.CalculationsStrategies
{
    public class CalculationNetAndGrossStrategy : ICalculationStrategy
    {
        private readonly decimal _vat;
        private readonly decimal _vatRate;   

        public CalculationNetAndGrossStrategy(decimal VAT, VATRate vatRate)
        {
            _vat = VAT;
            _vatRate = (decimal)vatRate / 100m;
        }

        public CalculationResponse Calculate()
        {
            var net = _vat / _vatRate;
            var gross = net + _vat;

            return new GrossAndNetResponse
            {
                Net = Math.Round(net, 2),
                Gross = Math.Round(gross, 2),
            };
        }
    }
}