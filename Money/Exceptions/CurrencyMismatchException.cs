using System;

namespace Money.Exceptions
{
    public class CurrencyMismatchException : InvalidOperationException
    {
        public Currency SourceCurrency { get; private set; }
        public Currency DestinationCurrency { get; private set; }

        public CurrencyMismatchException(
            Currency sourceCurrency, 
            Currency destinationCurrency, 
            string message)
            : base(message)
        {
            this.SourceCurrency = sourceCurrency;
            this.DestinationCurrency = destinationCurrency;
        }
    }
}