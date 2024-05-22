using FluentValidation;
using Models.DTO;

namespace Models.Validators
{
    public class EmployeeDTOValidator : AbstractValidator<EmployeeDTO>
    {
        public EmployeeDTOValidator()
        {

            string requiredMessage = "This field is required";

            RuleFor(dto => dto.EmpFirstName)
                .NotNull().WithMessage(requiredMessage)
                .NotEmpty().WithMessage(requiredMessage);

            RuleFor(dto => dto.EmpLastName)
                .NotNull().WithMessage(requiredMessage)
                .NotEmpty().WithMessage(requiredMessage);
            
            RuleFor(dto => dto.SalesOfficeId)
                .NotNull().WithMessage(requiredMessage)
                .NotEmpty().WithMessage(requiredMessage);
        }
    }
}
