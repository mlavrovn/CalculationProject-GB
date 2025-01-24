
namespace CalculationProject.BusinessLogic.Entities
{
    public class CalculationRequest
    { 
        public CalculationByType CalculationByType { get; set; }
        public decimal Amount { get; set; }
        public VATRate VATRate { get; set; }
    }
}
