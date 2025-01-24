using AutoMapper;
using CalculationProject.BusinessLogic.Entities;

namespace CalculationProject.Api.DTOs.MappingProfiles
{
    public class CalculationProfile : Profile
    {
        public CalculationProfile()
        {
            CreateMap<CalculationDTO, CalculationRequest>()
             .AfterMap((src, dest) =>
             {
                 if (src.Net.HasValue)
                 {
                     dest.Amount = src.Net.Value;
                     dest.CalculationByType = CalculationByType.Net;
                 }

                 if (src.Gross.HasValue)
                 {
                     dest.Amount = src.Gross.Value;
                     dest.CalculationByType = CalculationByType.Gross;
                 }

                 if (src.VAT.HasValue)
                 {
                     dest.Amount = src.VAT.Value;
                     dest.CalculationByType = CalculationByType.VAT;
                 }
             });
        }
    }
}
