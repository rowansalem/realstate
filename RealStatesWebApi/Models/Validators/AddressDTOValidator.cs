using FluentValidation;
using Models.DTO;

namespace Models.Validators
{
    public class AddressDTOValidator : AbstractValidator<AddressDTO>
    {
        public AddressDTOValidator()
        {

            string requiredMessage = "This field is required";

            RuleFor(dto => dto.AddressLine)
                .NotNull().WithMessage(requiredMessage)
                .NotEmpty().WithMessage(requiredMessage);

            RuleFor(dto => dto.City)
                .NotNull().WithMessage(requiredMessage)
                .NotEmpty().WithMessage(requiredMessage);

            RuleFor(dto => dto.State)
                .NotNull().WithMessage(requiredMessage)
                .NotEmpty().WithMessage(requiredMessage);

            RuleFor(dto => dto.ZipCode)
                .NotNull().WithMessage(requiredMessage)
                .NotEmpty().WithMessage(requiredMessage);
        }
    }
}
