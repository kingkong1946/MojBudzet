namespace MojBudzet.BussinessLayer.Domain.Budget
{
    using System;

    [Serializable]
    public class InvalidMonthException : Exception
    {
        public InvalidMonthException() { }
        public InvalidMonthException(string message) : base(message) { }
        public InvalidMonthException(string message, Exception inner) : base(message, inner) { }
        protected InvalidMonthException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
