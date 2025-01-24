using FluentValidation;

namespace CalculationProject.Api.DTOs.Validators
{
    public class CalculationDTOValidator : AbstractValidator<CalculationDTO>
    {
        public CalculationDTOValidator()
        {
            RuleFor(x => x.VATRate)
                .IsInEnum()
                .WithMessage("Invalid VAT rate");

            RuleFor(x => new { x.Net, x.Gross, x.VAT })
              .Must(x =>
                  x.Net.HasValue && !x.Gross.HasValue && !x.VAT.HasValue ||
                  !x.Net.HasValue && x.Gross.HasValue && !x.VAT.HasValue ||
                  !x.Net.HasValue && !x.Gross.HasValue && x.VAT.HasValue)
              .WithMessage("You must provide exactly one amount (Net, Gross, or VAT).");

            RuleFor(x => x.Net)
                .Must(x => x.HasValue && x.Value > 0 || !x.HasValue)
                .WithMessage("Net must be a positive number.")
                .When(x => x.Net.HasValue && !x.Gross.HasValue && !x.VAT.HasValue);

            RuleFor(x => x.VAT)
                .Must(x => x.HasValue && x.Value > 0 || !x.HasValue)
                .WithMessage("VAT must be a positive number.")
                .When(x => x.VAT.HasValue && !x.Gross.HasValue && !x.Net.HasValue);

            RuleFor(x => x.Gross)
                .Must(x => x.HasValue && x.Value > 0 || !x.HasValue)
                .WithMessage("Gross must be a positive number.")
                .When(x => x.Gross.HasValue && !x.Net.HasValue && !x.VAT.HasValue);
        }
    }
}
