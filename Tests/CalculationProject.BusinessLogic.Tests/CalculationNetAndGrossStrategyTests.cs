using CalculationProject.BusinessLogic.CalculationsStrategies;
using CalculationProject.BusinessLogic.Entities;
using CalculationProject.BusinessLogic.Entities.Responses;
using FluentAssertions;

namespace CalculationProject.BusinessLogic.Tests
{
    public class CalculationNetAndGrossStrategyTests
    {
        [TestCase(100, VATRate.SuperReduced, 1100, 1000)]
        [TestCase(130, VATRate.Reduced, 1130, 1000)]
        [TestCase(200, VATRate.Standard, 1200, 1000)]
        [TestCase(400, VATRate.Standard, 2400, 2000)]
        public void Calculate_ShouldReturnCorrectNetAndGross(decimal vat, VATRate vatRate, decimal expectedGross, decimal expectedNet)
        {
            // Arrange
            var strategy = new CalculationNetAndGrossStrategy(vat, vatRate);

            // Act
            var result = strategy.Calculate();

            // Assert
            result.Should().BeOfType<GrossAndNetResponse>();
            var response = (GrossAndNetResponse)result;
            response.Gross.Should().Be(expectedGross);
            response.Net.Should().Be(expectedNet);
        }
    }
}