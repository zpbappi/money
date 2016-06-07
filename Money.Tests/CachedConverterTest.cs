using System;
using System.Linq;
using Shouldly;
using Xunit;

namespace Money.Tests
{
    public class CachedConverterTest
    {
        private readonly MockCountingConverter mockCountingConverter;
        private readonly ICurrencyConverter<decimal> sut;

        public CachedConverterTest()
        {
            this.mockCountingConverter = new MockCountingConverter();
            this.sut = new CachedCurrencyConverter<decimal>(this.mockCountingConverter);
        }

        [Fact]
        public void WhenInitiatingWithNoConverter_ShouldThrow()
        {
            Should.Throw<ArgumentNullException>(() => new CachedCurrencyConverter<decimal>(null));
        }

        [Fact]
        public void ShouldOnlyCallToConvertOne()
        {
            var m1 = new Money<decimal>(100m, "AUD");
            var m2 = new Money<decimal>(33m, "AUD");
            var m3 = new Money<decimal>(32m, "AUD");
            var m4 = new Money<decimal>(-7m, "USD");
            var m5 = new Money<decimal>(3.14m, "AUD");

            var wallet = m1 - ((m2 % m3) + m5) * m4;

            wallet.Evaluate(this.sut, Currency.AUD);
            this.mockCountingConverter.Amounts.ShouldAllBe(x => x == 1m);
        }

        [Fact]
        public void ShouldOnlyCallForUniqueCurrenyPairConversion()
        {
            var m1 = new Money<decimal>(100m, "AUD");
            var m2 = new Money<decimal>(33m, "EUR");
            var m3 = new Money<decimal>(32m, "AUD");
            var m4 = new Money<decimal>(-7m, "USD");
            var m5 = new Money<decimal>(3.14m, "AUD");

            var wallet = m1 - ((m2 % m3) + m5) * m4;

            wallet.Evaluate(this.sut, "AUD");

            var actual = this.mockCountingConverter.CurrencyPairs.OrderBy(x => x).ToArray();
            
            var expected = new[]
            {
                MockCountingConverter.GenerateCurrencyPair(Currency.AUD, Currency.AUD),
                MockCountingConverter.GenerateCurrencyPair(Currency.EUR, Currency.AUD),
                MockCountingConverter.GenerateCurrencyPair(Currency.USD, Currency.AUD)
            };

            actual.ShouldBe(expected);
        }

        [Fact]
        public void ConceptFromTheMovieInception_ShouldBeUselessIfApplied()
        {
            var sut =
                new CachedCurrencyConverter<decimal>(
                    new CachedCurrencyConverter<decimal>(
                        new CachedCurrencyConverter<decimal>(
                            new CachedCurrencyConverter<decimal>(this.mockCountingConverter))));

            var m1 = new Money<decimal>(100m, "AUD");
            var m2 = new Money<decimal>(33m, "EUR");
            var m3 = new Money<decimal>(32m, "AUD");
            var m4 = new Money<decimal>(-7m, "USD");
            var m5 = new Money<decimal>(3.14m, "AUD");

            var wallet = m1 - ((m2 % m3) + m5) * m4;
            wallet.Evaluate(sut, "AUD");

            var actual = this.mockCountingConverter.CurrencyPairs.OrderBy(x => x).ToArray();

            var expected = new[]
            {
                MockCountingConverter.GenerateCurrencyPair(Currency.AUD, Currency.AUD),
                MockCountingConverter.GenerateCurrencyPair(Currency.EUR, Currency.AUD),
                MockCountingConverter.GenerateCurrencyPair(Currency.USD, Currency.AUD)
            };

            this.mockCountingConverter.Amounts.ShouldAllBe(x => x == 1m);
            actual.ShouldBe(expected);
        }
    }
}