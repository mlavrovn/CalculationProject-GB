namespace CalculationProject.BusinessLogic.Entities
{
    /// <summary>
    /// Represents the different types of values that can be used for calculation.
    /// </summary>
    /// <remarks>
    /// This enum is used to specify which value (Gross, Net, or VAT) should be the starting point 
    /// for the calculation. It helps determine which input value is provided, allowing the system 
    /// to calculate the missing values (Net, Gross, or VAT) based on the specified type.
    /// </remarks>
    public enum CalculationByType
    {
        Gross,
        Net,
        VAT
    }
}