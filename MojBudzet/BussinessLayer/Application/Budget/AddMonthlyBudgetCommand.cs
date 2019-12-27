namespace MojBudzet.BussinessLayer.Application.Budget
{
    using System;

    /// <summary>
    /// Add new empty monthly budget command.
    /// </summary>
    public class AddMonthlyBudgetCommand
    {
        /// <summary>
        /// Gets or sets budget month.
        /// </summary>
        public DateTime Month { get; set; }
    }
}
