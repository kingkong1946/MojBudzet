namespace MojBudzet.BussinessLayer.Domain
{
    using System;

    /// <summary>
    /// Value object for money.
    /// </summary>
    public struct Money
    {
        private readonly decimal value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Money"/> struct.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when value is below zero.</exception>
        /// <param name="value">Amount of money.</param>
        public Money(decimal value)
        {
            if (value < 0.0m)
            {
                throw new ArgumentOutOfRangeException("value", "Value must be greater or equal than zero");
            }

            this.value = value;
        }

        public static implicit operator decimal(Money money) => money.value;

        /// <inheritdoc/>
        public override string ToString()
        {
            return this.value.ToString();
        }
    }
}
