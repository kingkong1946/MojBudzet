namespace MojBudzet.BussinessLayer.Domain.Budget
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using FluentValidation;
    using Microsoft.Extensions.Logging;
    using MojBudzet.BussinessLayer.Application.Budget;

    /// <summary>
    /// Create monthly budget aggregates.
    /// </summary>
    public class MonthlyBudgetFactory
    {
        private readonly ILogger<MonthlyBudgetFactory> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="MonthlyBudgetFactory"/> class.
        /// </summary>
        /// <param name="logger"><see cref="ILogger{MonthlyBudgetFactory}"/> instance.</param>
        public MonthlyBudgetFactory(ILogger<MonthlyBudgetFactory> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Create monthly budget aggregate.
        /// </summary>
        /// <param name="command">Add monthly budget command.</param>
        /// <returns>Monthly budget aggregate.</returns>
        public Task<MonthlyBudgetAggregate> Create(AddMonthlyBudgetCommand command)
        {
            this.logger.LogInformation($"Monthly budget creating was started");
            return Task.FromResult(new MonthlyBudgetAggregate(command.Month));
        }
    }
}
