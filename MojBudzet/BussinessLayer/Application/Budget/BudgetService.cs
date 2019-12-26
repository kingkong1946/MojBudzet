namespace MojBudzet.BussinessLayer.Application.Budget
{
    using System.Threading.Tasks;

    public interface BudgetService
    {
        Task<string> AddMonthlyBudgetAsync(AddMonthlyBudgetCommand command);
        //Task AddExpenseToBudgetAsync();
    }
}
