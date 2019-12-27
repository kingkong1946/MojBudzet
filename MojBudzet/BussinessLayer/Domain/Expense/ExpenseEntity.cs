namespace MojBudzet.BussinessLayer.Domain.Expense
{
    /// <summary>
    /// Single expense.
    /// </summary>
    public class ExpenseEntity
    {
        /// <summary>
        /// Gets or sets expense name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets cost expense.
        /// </summary>
        public Money Value { get; set; }
    }
}
