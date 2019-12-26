namespace MojBudzet.BussinessLayer.Infrastructure.Budget
{
    using System;
    using System.Collections.Generic;

    public class MonthlyBudgetDocument
    {
        public string Id { get; set; }

        public DateTime Month { get; set; }

        public List<ExpenseDocument> Expenses { get; set; }
    }
}
