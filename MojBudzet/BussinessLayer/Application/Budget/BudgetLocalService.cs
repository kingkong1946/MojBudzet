namespace MojBudzet.BussinessLayer.Application.Budget
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MojBudzet.BussinessLayer.Application.Budget;
    using MojBudzet.BussinessLayer.Domain.Budget;
    using MojBudzet.BussinessLayer.Infrastructure.Budget;

    public class BudgetLocalService : BudgetService
    {
        private readonly MonthlyBudgetFactory monthlyBudgetFactory;
        private readonly Repository<MonthlyBudgetAggregate> repository;

        public BudgetLocalService(MonthlyBudgetFactory monthlyBudgetFactory, Repository<MonthlyBudgetAggregate> repository)
        {
            this.monthlyBudgetFactory = monthlyBudgetFactory;
            this.repository = repository;
        }

        public async Task<string> AddMonthlyBudgetAsync(AddMonthlyBudgetCommand command)
        {
            var budget = await this.monthlyBudgetFactory.Create(command);

            await this.repository.AddAsync(budget);

            return budget.Id;
        }
    }
}
