using System;
using Xunit;
using Shouldly;


namespace Money.Tests
{
    public class MoneyConstructionTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ShouldThrowWithEmptyCurrency(string currency)
        {
            Should.Throw<ArgumentNullException>(() => Money.Create(42, currency));
        }

        [Fact]
        public void ShouldThrowWithNullValues()
        {
            Should.Throw<ArgumentNullException>(() => Money<decimal?>.Create(null, "AUD"));
        }

        [Theory]
        [InlineData(42, "AUD")]
        public void ShouldNotThrowWithProperValues(decimal amount, string currency)
        {
            Should.NotThrow(() => Money.Create(amount, currency));
        }

        [Theory]
        [InlineData("aud", "AUD")]
        [InlineData("aUd", "AuD")]
        [InlineData("Aud", "AUD")]
        public void CurrencyCodeShouldBeCaseIgnorant(string currencyCase1, string currencyCase2)
        {
            var money1 = Money.Create(42, currencyCase1);
            var money2 = Money.Create(42, currencyCase2);

            money1.Currency.ShouldBe(money2.Currency);
        }
    }
}