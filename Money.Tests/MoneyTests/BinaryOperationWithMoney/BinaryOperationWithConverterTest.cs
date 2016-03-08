using System;
using Shouldly;
using Xunit;

namespace Money.Tests.MoneyTests.BinaryOperationWithMoney
{
    public class BinaryOperationWithConverterTest
    {
        private readonly ICurrencyConverter<decimal> currencyConverter;

        public BinaryOperationWithConverterTest()
        {
            var mock = new MockCurrencyConverter();
            mock.RegisterConversionRate("USD", "AUD", 1.3m);
            
            this.currencyConverter = mock;
        }

        [Fact]
        public void ForMultipleCurrencies_ShouldPerformConversionCorrectly()
        {
            var m1 = new Money<decimal>(100m, "AUD");
            var m2 = new Money<decimal>(33m, "AUD");
            var m3 = new Money<decimal>(32m, "AUD");
            var m4 = new Money<decimal>(-7m, "USD");
            var m5 = new Money<decimal>(3.14m, "AUD");

            var wallet = m1 - ((m2%m3) + m5)*m4;

            var actual = wallet.Evaluate(this.currencyConverter, "AUD");

            var expected = new Money<decimal>(137.674m, "AUD");

            actual.ShouldBe(expected);
        }

        [Fact]
        public void WhenCurrencyConverterIsNull_ShouldThrow()
        {
            var m1 = new Money<int>(123, "USD");
            var m2 = new Money<int>(1, "AUD");
            var wallet = m1 + m2;
            Should.Throw<ArgumentNullException>(() => wallet.Evaluate(null, "AUD"));
        }

        [Fact]
        public void WhenDestinationCurrencyIsEmpty_ShouldThrow()
        {
            var m1 = new Money<decimal>(123, "USD");
            var m2 = new Money<decimal>(1, "AUD");
            var wallet = m1 + m2;
            Should.Throw<ArgumentNullException>(() => wallet.Evaluate(this.currencyConverter, null));
        }
    }
}