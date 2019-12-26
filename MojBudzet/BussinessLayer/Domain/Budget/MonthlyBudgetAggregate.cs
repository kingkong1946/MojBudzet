namespace MojBudzet.BussinessLayer.Domain.Budget
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MojBudzet.BussinessLayer.Domain.Expense;

    public class MonthlyBudgetAggregate
    {
        private readonly IList<ExpenseModel> expenses = new List<ExpenseModel>();

        public MonthlyBudgetAggregate(DateTime month)
        {
            this.Month = month;
        }

        public string Id => this.Month.ToString("MM/yy");

        public DateTime Month { get; }

        public void AddExpense(ExpenseModel expense) => this.expenses.Add(expense);

        public ExpenseModel[] GetExpenses() => this.expenses.ToArray();
    }
}
