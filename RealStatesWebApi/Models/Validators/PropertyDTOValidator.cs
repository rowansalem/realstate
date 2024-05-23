using FluentValidation;
using Models.DTO;

namespace Models.Validators
{
    public class PropertyDTOValidator : AbstractValidator<PropertyDTO>
    {
        public PropertyDTOValidator()
        {

            string requiredMessage = "This field is required";

            RuleFor(dto => dto.ListPrice)
                .NotNull().WithMessage(requiredMessage)
                .NotEmpty().WithMessage(requiredMessage);

            RuleFor(dto => dto.NoBedrooms)
                .NotNull().WithMessage(requiredMessage)
                .NotEmpty().WithMessage(requiredMessage);

            RuleFor(dto => dto.NoOfBathrooms)
                .NotNull().WithMessage(requiredMessage)
                .NotEmpty().WithMessage(requiredMessage);

            RuleFor(dto => dto.Status)
                .NotNull().WithMessage(requiredMessage)
                .NotEmpty().WithMessage(requiredMessage);


            RuleFor(dto => dto.City)
                .NotNull().WithMessage(requiredMessage)
                .NotEmpty().WithMessage(requiredMessage);

        }
    }
}
