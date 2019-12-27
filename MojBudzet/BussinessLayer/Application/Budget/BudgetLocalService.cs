namespace MojBudzet.BussinessLayer.Application.Budget
{
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using MojBudzet.BussinessLayer.Domain.Budget;
    using MojBudzet.BussinessLayer.Infrastructure.Budget;

    /// <summary>
    /// Local application service to manage budgets.
    /// </summary>
    public class BudgetLocalService : BudgetService
    {
        private readonly MonthlyBudgetFactory monthlyBudgetFactory;
        private readonly Repository<MonthlyBudgetAggregate> repository;
        private readonly ILogger<BudgetLocalService> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetLocalService"/> class.
        /// </summary>
        /// <param name="monthlyBudgetFactory"><see cref="MonthlyBudgetFactory"/> instance.</param>
        /// <param name="repository"><see cref="Repository{MonthlyBudgetAggregate}"/> instance.</param>
        /// <param name="logger"><see cref="ILogger{BudgetLocalService}"/> instance.</param>
        public BudgetLocalService(MonthlyBudgetFactory monthlyBudgetFactory, Repository<MonthlyBudgetAggregate> repository, ILogger<BudgetLocalService> logger)
        {
            this.monthlyBudgetFactory = monthlyBudgetFactory;
            this.repository = repository;
            this.logger = logger;
        }

        /// <inheritdoc/>
        public async Task<string> AddMonthlyBudgetAsync(AddMonthlyBudgetCommand command)
        {
            this.logger.LogInformation("Adding monthly budget was started.");

            var budget = await this.monthlyBudgetFactory.Create(command);
            this.logger.LogInformation($"Monthly budget created. ID: {budget.Id}");

            await this.repository.AddAsync(budget);
            this.logger.LogInformation("Monthy budget was persisted.");

            return budget.Id;
        }
    }
}
