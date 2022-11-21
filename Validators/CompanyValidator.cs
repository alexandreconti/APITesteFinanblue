using ApiTeste.Models;
using FluentValidation;

namespace ApiTeste.Validators;

public class CompanyValidator : AbstractValidator<Company>
{
    public CompanyValidator()
    {
        RuleFor(x => x.Name)
            .Length(3, 40)
            .WithMessage("Name must be between 3 and 40 characters");
    }
}