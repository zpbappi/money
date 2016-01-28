using System;

namespace Money.Exceptions
{
    public class CurrencyMismatchException : InvalidOperationException
    {
        public string SourceCurrency { get; private set; }
        public string DestinationCurrency { get; private set; }

        public CurrencyMismatchException(
            string sourceCurrency, 
            string destinationCurrency, 
            string message)
            : base(message)
        {
            this.SourceCurrency = sourceCurrency;
            this.DestinationCurrency = destinationCurrency;
        }
    }
}