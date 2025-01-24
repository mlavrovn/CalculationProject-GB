using CalculationProject.BusinessLogic.CalculationsStrategies;
using CalculationProject.BusinessLogic.Entities;
using CalculationProject.BusinessLogic.Entities.Responses;
using FluentAssertions;

namespace CalculationProject.BusinessLogic.Tests
{
    public class CalculationGrossAndVATStrategyTests
    {
        [TestCase(1000, VATRate.SuperReduced, 1100, 100)]
        [TestCase(1000, VATRate.Reduced, 1130, 130)]
        [TestCase(1010, VATRate.Reduced, 1141.30, 131.30)]
        [TestCase(1000, VATRate.Standard, 1200, 200)]
        [TestCase(2000, VATRate.Standard, 2400, 400)]
        public void Calculate_ShouldReturnCorrectGrossAndVAT(decimal net, VATRate vatRate, decimal expectedGross, decimal expectedVAT)
        {
            // Arrange
            var strategy = new CalculationGrossAndVATStrategy(net, vatRate);

            // Act
            var result = strategy.Calculate();

            // Assert
            result.Should().BeOfType<GrossAndVATResponse>();
            var response = (GrossAndVATResponse)result;
            response.Gross.Should().Be(expectedGross);
            response.VAT.Should().Be(expectedVAT);
        }
    }
}