using System;
using Shouldly;
using Xunit;

namespace Money.Tests.MoneyTests.BinaryOperationWithMoney
{
    public class BinaryOperationsWithoutConverterTest
    {
        [Fact]
        public void CombinationOfMoneyWithSameCurrency_ShouldResultInValidMoneyOfSameCurrencyWithoutAnyConversion()
        {
            var m1 = new Money<decimal>(42m, "AUD");
            var m2 = new Money<decimal>(10m, "AUD");
            var m3 = new Money<decimal>(-9m, "AUD");
            var m4 = new Money<decimal>(7m, "AUD");
            var m5 = new Money<decimal>(101m, "AUD");
            var m6 = new Money<decimal>(3m, "AUD");

            var wallet = m1 + m2 - (m3*m4)/(m5%m6);
            var actual = wallet.EvaluateWithoutConversion();

            var expect = new Money<decimal>(83.5m, "AUD");

            actual.ShouldBe(expect);
        }

        [Fact]
        public void TryingToEvaluateDifferentCurrenciesTogether_ShouldThrow()
        {
            var m1 = new Money<decimal>(42m, "AUD");
            var m2 = new Money<decimal>(10m, "USD");
            var m3 = new Money<decimal>(-9m, "AUD");

            var wallet = m1 + m2*m3;

            Should.Throw<InvalidOperationException>(() => wallet.EvaluateWithoutConversion());
        }
    }
}