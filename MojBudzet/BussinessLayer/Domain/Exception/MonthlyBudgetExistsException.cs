namespace MojBudzet.BussinessLayer.Domain.Exception
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Serializable]
    public class MonthlyBudgetExistsException : Exception
    {
        public MonthlyBudgetExistsException() { }
        public MonthlyBudgetExistsException(string message) : base(message) { }
        public MonthlyBudgetExistsException(string message, string value) : base(message) 
        {
            this.Value = value;
        }
        public MonthlyBudgetExistsException(string message, System.Exception inner) : base(message, inner) { }
        protected MonthlyBudgetExistsException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        public string Value { get; }
    }
}
