using FluentValidation;
using Models.DTO;

namespace Models.Validators
{
    public class OwnerDTOValidator : AbstractValidator<OwnerDTO>
    {
        public OwnerDTOValidator()
        {

            string requiredMessage = "This field is required";

            RuleFor(dto => dto.OwnerFirstName)
                .NotNull().WithMessage(requiredMessage)
                .NotEmpty().WithMessage(requiredMessage);

            RuleFor(dto => dto.OwnerLastName)
                .NotNull().WithMessage(requiredMessage)
                .NotEmpty().WithMessage(requiredMessage);
            
        }
    }
}
