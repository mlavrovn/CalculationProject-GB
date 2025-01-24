using CalculationProject.BusinessLogic.Entities;
using CalculationProject.BusinessLogic.Entities.Responses;
using CalculationProject.BusinessLogic.Interfaces;

namespace CalculationProject.BusinessLogic.CalculationsStrategies
{
    public class CalculationNetAndVATStrategy : ICalculationStrategy
    {
        private readonly decimal _gross;
        private readonly decimal _vatRate;

        public CalculationNetAndVATStrategy(decimal gross, VATRate vatRate)   
        {
            _gross = gross;
            _vatRate = (decimal)vatRate / 100m;
        }

        public  CalculationResponse Calculate()
        {
            var net = _gross / (1 + _vatRate);
            var vat = _gross - net;

            return new NetAndVATResponse
            {
                Net = Math.Round(net, 2),
                VAT = Math.Round(vat, 2)
            };
        }
    }
}