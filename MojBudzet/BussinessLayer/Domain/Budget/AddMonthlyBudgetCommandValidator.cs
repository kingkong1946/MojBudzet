using FluentValidation;
using MojBudzet.BussinessLayer.Application.Budget;

namespace MojBudzet.BussinessLayer.Domain.Budget
{
    public class AddMonthlyBudgetCommandValidator : AbstractValidator<AddMonthlyBudgetCommand>
    {
        public AddMonthlyBudgetCommandValidator()
        {
            RuleFor(command => command.Month)
                .GreaterThan(0)
                .LessThan(13);
        }
    }
}
