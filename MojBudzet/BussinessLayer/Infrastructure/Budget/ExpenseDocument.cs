namespace MojBudzet.BussinessLayer.Infrastructure.Budget
{
    /// <summary>
    /// LiteDB expense document.
    /// </summary>
    public class ExpenseDocument
    {
        /// <summary>
        /// Gets or sets identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets amount of expense.
        /// </summary>
        public decimal Value { get; set; }
    }
}
