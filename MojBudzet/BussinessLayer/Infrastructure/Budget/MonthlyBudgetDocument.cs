namespace MojBudzet.BussinessLayer.Infrastructure.Budget
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// LiteDb monthly budget document.
    /// </summary>
    public class MonthlyBudgetDocument
    {
        /// <summary>
        /// Gets or sets identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets budget month.
        /// </summary>
        public DateTime Month { get; set; }

        /// <summary>
        /// Gets or sets list of single expenses.
        /// </summary>
        public List<ExpenseDocument> Expenses { get; set; }
    }
}
