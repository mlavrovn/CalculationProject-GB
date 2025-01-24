using CalculationProject.BusinessLogic.Entities.Responses;

namespace CalculationProject.BusinessLogic.Interfaces
{
    /// <summary>
    /// Defines the contract for a calculation strategy.
    /// </summary>
    /// <remarks>
    /// The strategy is responsible for performing a specific type of calculation based on the provided data.
    /// The <see cref="Calculate"/> method will implement the logic to compute the result based on the strategy's context.
    /// </remarks>
    public interface ICalculationStrategy
    {
        /// <summary>
        /// Performs the calculation and returns the result.
        /// </summary>
        /// <returns>A <see cref="CalculationResponse"/> containing the results of the calculation.</returns>
        CalculationResponse Calculate();
    }
}