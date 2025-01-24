using CalculationProject.BusinessLogic.Entities;

namespace CalculationProject.BusinessLogic.Interfaces
{
    /// <summary>
    /// Defines the contract for a factory responsible for creating calculation strategies.
    /// </summary>
    /// <remarks>
    /// The factory is responsible for selecting and creating the appropriate calculation strategy 
    /// based on the provided <see cref="CalculationRequest"/>.
    /// Each strategy handles a different calculation method depending on the type of request received.
    /// </remarks>
    public interface ICalculationStrategyFactory
    {
        /// <summary>
        /// Creates and returns an instance of a calculation strategy based on the provided request.
        /// </summary>
        /// <param name="request">The request containing the necessary information for selecting the strategy.</param>
        /// <returns>An instance of <see cref="ICalculationStrategy"/> to perform the calculation.</returns>
        ICalculationStrategy Create(CalculationRequest request);
    }
}