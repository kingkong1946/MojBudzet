namespace MojBudzet.BussinessLayer.Infrastructure.Budget
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using LiteDB;
    using Microsoft.Extensions.Logging;
    using MojBudzet.BussinessLayer.Domain;
    using MojBudzet.BussinessLayer.Domain.Budget;
    using MojBudzet.BussinessLayer.Domain.Exception;

    /// <summary>
    /// LiteDB monthly budget repository.
    /// </summary>
    public class LiteDbMonthlyBudgetRepository : Repository<MonthlyBudgetAggregate>
    {
        private readonly LiteDatabase database;
        private readonly ILogger<LiteDbMonthlyBudgetRepository> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LiteDbMonthlyBudgetRepository"/> class.
        /// </summary>
        /// <param name="database"><see cref="LiteDatabase"/> instance.</param>
        /// <param name="logger"><see cref="ILogger{LiteDbMonthlyBudgetRepository}"/> instance.</param>
        public LiteDbMonthlyBudgetRepository(LiteDatabase database, ILogger<LiteDbMonthlyBudgetRepository> logger)
        {
            this.database = database;
            this.logger = logger;
        }

        /// <inheritdoc/>
        public Task AddAsync(MonthlyBudgetAggregate item)
        {
            this.logger.LogInformation($"Persiste monthly budget was started. ID: {item.Id}");

            var expenses = item
                .GetExpenses()
                .Select(expense => new ExpenseDocument
                {
                    Name = expense.Name,
                    Value = expense.Value,
                })
                .ToList();

            var document = new MonthlyBudgetDocument
            {
                Id = item.Id,
                Expenses = expenses,
                Month = item.Month,
            };

            this.logger.LogInformation($"Monthly budget document was created. ID: {item.Id}");

            try
            {
                this.database.GetCollection<MonthlyBudgetDocument>().Insert(document);
            }
            catch (LiteException)
            {
                throw new MonthlyBudgetExistsException("The monthly budget already exists", document.Id);
            }

            this.logger.LogInformation($"Monthly budget document was inserted. ID: {item.Id}");

            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public Task<MonthlyBudgetAggregate> FindAsync(System.Linq.Expressions.Expression<Func<MonthlyBudgetAggregate, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
