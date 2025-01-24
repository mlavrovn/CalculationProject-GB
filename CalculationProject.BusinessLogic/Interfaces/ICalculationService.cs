using CalculationProject.BusinessLogic.Entities;
using CalculationProject.BusinessLogic.Entities.Responses;

namespace CalculationProject.BusinessLogic.Interfaces
{
    /// <summary>
    /// Defines the contract for a service that performs VAT calculations.
    /// </summary>
    public interface ICalculationService
    {
        /// <summary>
        /// Calculates the missing values (Net, Gross, VAT) based on the provided request.
        /// The input request must contain at least two of the three values (Net, Gross, VAT).
        /// </summary>
        /// <param name="request">The request containing the values (Net, Gross, VAT, VATRate) to be used for calculation.</param>
        /// <returns>A <see cref="CalculationResponse"/> containing the calculated values (Net, Gross, VAT).</returns>
        CalculationResponse Calculate(CalculationRequest request);
    }
}