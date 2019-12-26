namespace MojBudzet.BussinessLayer.Domain
{
    using System;

    public struct Money
    {
        private readonly decimal value;

        public Money(decimal value)
        {
            if (value < 0.0m)
            {
                throw new ArgumentOutOfRangeException("value", "Value must be greater or equal than zero");
            }

            this.value = value;
        }

        public static implicit operator decimal(Money money) => money.value;

        public override string ToString()
        {
            return this.value.ToString();
        }
    }
}
