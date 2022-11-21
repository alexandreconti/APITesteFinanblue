using ApiTeste.Models;
using FluentValidation;

namespace ApiTeste.Validators;

public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
    {
        RuleFor(x => x.amount)
            .Empty()
            .WithMessage("Amount can not have empty");
    }
}