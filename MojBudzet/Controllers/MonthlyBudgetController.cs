namespace MojBudzet.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using MojBudzet.BussinessLayer.Application.Budget;

    /// <summary>
    /// Monthy budget endpoint.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MonthlyBudgetController : ControllerBase
    {
        private readonly BudgetService budgetService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MonthlyBudgetController"/> class.
        /// </summary>
        /// <param name="budgetService">Provide services to manage monthly budget.</param>
        public MonthlyBudgetController(BudgetService budgetService)
        {
            this.budgetService = budgetService;
        }

        /// <summary>
        /// Create new monthly budget.
        /// </summary>
        /// <param name="command">Request body</param>
        /// <returns>Operaton result</returns>
        [HttpPost]
        public async Task<IActionResult> Post(AddMonthlyBudgetCommand command)
        {
            var result = await this.budgetService.AddMonthlyBudgetAsync(command);

            var resourcePath = this.Url.Action("Get", "MonthlyBudget");

            return this.Created(resourcePath, result);
        }
    }
}