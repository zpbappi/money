using System.Collections.Generic;

namespace Money.Tests
{
    public class MockCountingConverter : ICurrencyConverter<decimal>
    {
        public IList<string> CurrencyPairs { get; private set; }
        public IList<decimal> Amounts { get; private set; }

        public MockCountingConverter()
        {
            this.CurrencyPairs = new List<string>();
            this.Amounts = new List<decimal>();
        }
 
        public decimal Convert(decimal fromAmount, Currency fromCurrency, Currency toCurrency)
        {
            this.Amounts.Add(fromAmount);
            this.CurrencyPairs.Add(GenerateCurrencyPair(fromCurrency, toCurrency));
            return 1m;
        }

        public static string GenerateCurrencyPair(Currency fromCurrency, Currency toCurrency)
        {
            return (fromCurrency + "/" + toCurrency);
        }
    }
}