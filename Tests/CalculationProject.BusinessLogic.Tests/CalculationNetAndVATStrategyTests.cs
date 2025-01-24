using CalculationProject.BusinessLogic.CalculationsStrategies;
using CalculationProject.BusinessLogic.Entities;
using CalculationProject.BusinessLogic.Entities.Responses;
using FluentAssertions;

namespace CalculationProject.BusinessLogic.Tests
{
    public class CalculationNetAndVATStrategyTests
    {
        [TestCase(1100, VATRate.SuperReduced, 100, 1000)]
        [TestCase(1130, VATRate.Reduced, 130, 1000)]
        [TestCase(1100, VATRate.Standard, 183.33, 916.67)]
        [TestCase(1200, VATRate.Standard, 200, 1000)]
        [TestCase(2400, VATRate.Standard, 400, 2000)]
        public void Calculate_ShouldReturnCorrectNetAndVAT(decimal gross, VATRate vatRate, decimal expectedVAT, decimal expectedNet)
        {
            // Arrange
            var strategy = new CalculationNetAndVATStrategy(gross, vatRate);

            // Act
            var result = strategy.Calculate();

            // Assert
            result.Should().BeOfType<NetAndVATResponse>();
            var response = (NetAndVATResponse)result;
            response.VAT.Should().Be(expectedVAT);
            response.Net.Should().Be(expectedNet);
        }
    }
}