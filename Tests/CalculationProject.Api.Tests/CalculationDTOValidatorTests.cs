using CalculationProject.Api.DTOs;
using CalculationProject.Api.DTOs.Validators;
using CalculationProject.BusinessLogic.Entities;
using FluentAssertions;
using FluentValidation.TestHelper;

namespace CalculationProject.Api.Tests
{
    public class CalculationDTOValidatorTests
    {
        private CalculationDTOValidator _validator;

        [SetUp]
        public void SetUp()
        {
            // Initialize the validator before each test
            _validator = new CalculationDTOValidator();
        }

        [Test]
        public void Should_Have_Error_When_VATRate_Is_Invalid()
        {
            // Arrange
            var dto = new CalculationDTO { VATRate = (VATRate)999 };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.VATRate);
            result.Errors.Should().ContainSingle(e => e.ErrorMessage == "Invalid VAT rate");
        }

        [Test]
        public void Should_Not_Have_Error_When_VATRate_Is_Valid()
        {
            // Arrange
            var dto = new CalculationDTO { VATRate = VATRate.Standard };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.VATRate);
        }

        [Test]
        public void Should_Have_Error_When_More_Than_One_Amount_Is_Provided()
        {
            // Arrange
            var dto = new CalculationDTO
            {
                Net = 100,
                Gross = 200,
                VAT = 10
            };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => new { x.Net, x.Gross, x.VAT });
            result.Errors.Should().ContainSingle(e => e.ErrorMessage == "You must provide exactly one amount (Net, Gross, or VAT).");
        }

        [Test]
        public void Should_Have_Error_When_No_Amount_Is_Provided()
        {
            // Arrange
            var dto = new CalculationDTO
            {
                Net = null,
                Gross = null,
                VAT = null
            };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => new { x.Net, x.Gross, x.VAT });
            result.Errors.Should().ContainSingle(e => e.ErrorMessage == "You must provide exactly one amount (Net, Gross, or VAT).");
        }

        [Test]
        public void Should_Have_Error_When_Net_Is_Provided_Without_Valid_Values()
        {
            // Arrange
            var dto = new CalculationDTO
            {
                Net = -10,
                Gross = null,
                VAT = null
            };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Net);
            result.Errors.Should().ContainSingle(e => e.ErrorMessage == "Net must be a positive number.");
        }

        [Test]
        public void Should_Have_Error_When_Gross_Is_Provided_Without_Valid_Values()
        {
            // Arrange
            var dto = new CalculationDTO
            {
                Net = null,
                Gross = -50,
                VAT = null
            };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Gross);
            result.Errors.Should().ContainSingle(e => e.ErrorMessage == "Gross must be a positive number.");
        }

        [Test]
        public void Should_Not_Have_Error_When_Only_Net_Is_Provided_With_Valid_Value()
        {
            // Arrange
            var dto = new CalculationDTO
            {
                Net = 100,
                Gross = null,
                VAT = null
            };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Net);
        }

        [Test]
        public void Should_Not_Have_Error_When_Only_VAT_Is_Provided_With_Valid_Value()
        {
            // Arrange
            var dto = new CalculationDTO
            {
                Net = null,
                Gross = null,
                VAT = 10
            };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.VAT);
        }

        [Test]
        public void Should_Not_Have_Error_When_Only_Gross_Is_Provided_With_Valid_Value()
        {
            // Arrange
            var dto = new CalculationDTO
            {
                Net = null,
                Gross = 200,
                VAT = null
            };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Gross);
        }
    }
}