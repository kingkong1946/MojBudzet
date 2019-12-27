namespace MojBudzet.BussinessLayer.Domain.Budget
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MojBudzet.BussinessLayer.Domain.Expense;

    /// <summary>
    /// Calculate income and expenses for month.
    /// </summary>
    public class MonthlyBudgetAggregate
    {
        private readonly IList<ExpenseEntity> expenses = new List<ExpenseEntity>();

        /// <summary>
        /// Initializes a new instance of the <see cref="MonthlyBudgetAggregate"/> class.
        /// </summary>
        /// <param name="month">Budget month</param>
        public MonthlyBudgetAggregate(DateTime month)
        {
            this.Month = month;
        }

        /// <summary>
        /// Gets identifier in format MM/yy.
        /// </summary>
        public string Id => this.Month.ToString("MM/yy");

        /// <summary>
        /// Gets budget month.
        /// </summary>
        public DateTime Month { get; }

        /// <summary>
        /// Add single expense to budget.
        /// </summary>
        /// <param name="expense">Single expense.</param>
        public void AddExpense(ExpenseEntity expense) => this.expenses.Add(expense);

        /// <summary>
        /// Returns array of expenses.
        /// </summary>
        /// <returns>Array of expenses.</returns>
        public ExpenseEntity[] GetExpenses() => this.expenses.ToArray();
    }
}
