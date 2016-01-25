using Shouldly;
using Xunit;

namespace Money.Tests
{
    public class MoneyEqualityTest
    {
        [Theory]
        [InlineData(42, 42, true)]
        [InlineData(42, 24, false)]
        public void MoneyWithSameCurrency_ShouldSupportEqualityComparison(
            decimal amount1,
            decimal amount2,
            bool expectedEqualityTestResult)
        {
            const string currency = "AUD";
            var money1 = new Money(amount1, currency);
            var money2 = new Money(amount2, currency);
            
            var actualEqualityTestResult = money1 == money2;

            actualEqualityTestResult.ShouldBe(expectedEqualityTestResult);
        }

        [Fact]
        public void ShouldBeComparableWithNull()
        {
            var money = new Money(42, "AUD");
            var actual = money == null;

            actual.ShouldBe(false);
        }

        [Theory]
        [InlineData(42, 42, true)]
        [InlineData(42, 24, false)]
        public void MoneyWithSameCurrency_ShouldBeEquatable(
            decimal amount1,
            decimal amount2,
            bool expected)
        {
            const string currency = "AUD";
            var money1 = new Money(amount1, currency);
            var money2 = new Money(amount2, currency);

            var actual = money1.Equals(money2);

            actual.ShouldBe(expected);
        }

        [Fact]
        public void ShouldBeEquatableWithNull()
        {
            var money = new Money(42, "AUD");
            var actual = money.Equals(null);

            actual.ShouldBe(false);
        }

        [Theory]
        [InlineData(1, "AUD", 1, "USD", false)]
        [InlineData(0, "AUD", 0, "USD", false)]
        [InlineData(1, "AUD", 1, "AUD", true)]
        public void WhenComparingTwoDifferentCurrencies_ShouldReturnFalse(
            decimal amount1,
            string currency1,
            decimal amount2,
            string currency2,
            bool expected)
        {
            var money1 = new Money(amount1, currency1);
            var money2 = new Money(amount2, currency2);

            var actual = money1 == money2;

            actual.ShouldBe(expected);
        }

        [Theory]
        [InlineData(1, "AUD", 1, "USD", false)]
        [InlineData(0, "AUD", 0, "USD", false)]
        [InlineData(1, "AUD", 1, "AUD", true)]
        public void WhenEquatingTwoDifferentCurrencies_ShouldReturnFalse(
            decimal amount1,
            string currency1,
            decimal amount2,
            string currency2,
            bool expected)
        {
            var money1 = new Money(amount1, currency1);
            var money2 = new Money(amount2, currency2);

            var actual = money1.Equals(money2);

            actual.ShouldBe(expected);
        }
    }
}