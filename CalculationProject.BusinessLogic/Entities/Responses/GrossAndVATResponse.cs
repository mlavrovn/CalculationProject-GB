namespace CalculationProject.BusinessLogic.Entities.Responses
{
    public class GrossAndVATResponse : CalculationResponse
    {
        public decimal Gross { get; set; }
        public decimal VAT { get; set; }
    }
}
