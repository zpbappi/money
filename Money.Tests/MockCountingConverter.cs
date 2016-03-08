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
 
        public decimal Convert(decimal fromAmount, string fromCurrency, string toCurrency)
        {
            this.Amounts.Add(fromAmount);
            this.CurrencyPairs.Add(GenerateCurrencyPair(fromCurrency, toCurrency));
            return 1m;
        }

        public static string GenerateCurrencyPair(string fromCurrency, string toCurrency)
        {
            return (fromCurrency.ToUpperInvariant() + "/" + toCurrency.ToUpperInvariant());
        }
    }
}