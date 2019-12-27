namespace MojBudzet.BussinessLayer.Application.Budget
{
    using System.Threading.Tasks;

    /// <summary>
    /// Application service to manage budgets.
    /// </summary>
    public interface BudgetService
    {
        /// <summary>
        /// Add new monthly budget.
        /// </summary>
        /// <param name="command">Creating monthly budget</param>
        /// <returns>Budget identifier</returns>
        Task<string> AddMonthlyBudgetAsync(AddMonthlyBudgetCommand command);
        //Task AddExpenseToBudgetAsync();
    }
}
