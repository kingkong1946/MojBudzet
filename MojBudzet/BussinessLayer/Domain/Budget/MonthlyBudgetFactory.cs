namespace MojBudzet.BussinessLayer.Domain.Budget
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using FluentValidation;
    using MojBudzet.BussinessLayer.Application.Budget;

    public class MonthlyBudgetFactory
    {
        private readonly IValidator<AddMonthlyBudgetCommand> addMonthlyBudgetCommandValidator;

        public MonthlyBudgetFactory(IValidator<AddMonthlyBudgetCommand> addMonthlyBudgetCommandValidator)
        {
            this.addMonthlyBudgetCommandValidator = addMonthlyBudgetCommandValidator;
        }

        public async Task<MonthlyBudgetAggregate> Create(AddMonthlyBudgetCommand command)
        {
            var result = await this.addMonthlyBudgetCommandValidator.ValidateAsync(command);

            if (!result.IsValid)
            {
                throw new InvalidMonthException(result.Errors.FirstOrDefault().ErrorMessage);
            }

            return new MonthlyBudgetAggregate(command.Month);
        }
    }
}
