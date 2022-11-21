using ApiTeste.Models;
using FluentValidation;

namespace ApiTeste.Validators;

public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
    {
        RuleFor(x => x.Amount)
            .NotEmpty()
            .WithMessage("Amount can not have empty");
    }
}