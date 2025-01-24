using CalculationProject.BusinessLogic.Entities;

namespace CalculationProject.Api.DTOs
{
    public class CalculationDTO
    {
        public decimal? Net { get; set; }
        public decimal? VAT { get; set; }
        public decimal? Gross { get; set; }
        public VATRate VATRate { get; set; }
    }
}
