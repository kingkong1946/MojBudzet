namespace MojBudzet.BussinessLayer.Infrastructure.Budget
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using LiteDB;
    using MojBudzet.BussinessLayer.Domain;
    using MojBudzet.BussinessLayer.Domain.Budget;

    public class MonthlyBudgetRepository : Repository<MonthlyBudgetAggregate>
    {
        private readonly LiteDatabase database;

        public MonthlyBudgetRepository(LiteDatabase database)
        {
            this.database = database;
        }

        public Task AddAsync(MonthlyBudgetAggregate item)
        {
            var document = new MonthlyBudgetDocument
            {
                Id = item.Id,
                Expenses = item.GetExpenses().Select(expense => new ExpenseDocument
                {
                    Name = expense.Name,
                    Value = expense.Value,
                }).ToList(),
                Month = item.Month,
            };

            this.database.GetCollection<MonthlyBudgetDocument>().Insert(document);

            return Task.CompletedTask;
        }

        public Task<MonthlyBudgetAggregate> FindAsync(System.Linq.Expressions.Expression<Func<MonthlyBudgetAggregate, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
