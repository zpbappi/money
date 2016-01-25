using System;
using Shouldly;
using Xunit;

namespace Money.Tests.MoneyTests
{
    public class ComparisonTest
    {
        [Theory]
        [InlineData(42, "AUD")]
        [InlineData(-100, "AUD")]
        [InlineData(0, "USD")]
        public void NullInvariant(decimal amount, string currency)
        {
            var money = new Money(amount, currency);
            
            money.ShouldBeGreaterThan(null);
            money.ShouldBeGreaterThanOrEqualTo(null);

            var actual = money < null;
            actual.ShouldBeFalse();

            actual = money <= null;
            actual.ShouldBeFalse();
        }

        [Theory]
        [InlineData(1, "AUD", 1, "USD")]
        [InlineData(1, "AUD", 42, "USD")]
        public void ShouldNotAllowComparisonBetweenDifferentCurrencies(
            decimal amount1,
            string currency1,
            decimal amount2,
            string currency2)
        {
            var money1 = new Money(amount1, currency1);
            var money2 = new Money(amount2, currency2);
            Should.Throw<InvalidOperationException>(() =>
            {
                var result = money1 > money2;
            });
        }

        [Theory]
        [InlineData(42, 100, false)]
        [InlineData(42, 7, true)]
        [InlineData(42, 42, false)]
        [InlineData(42, -42, true)]
        [InlineData(-42, 42, false)]
        [InlineData(-42, -42, false)]
        public void CanCompareGreaterThan(
            decimal amount1,
            decimal amount2,
            bool expected)
        {
            const string currency = "AUD";
            Money m1 = new Money(amount1, currency), 
                m2 = new Money(amount2, currency);

            var actual = m1 > m2;

            actual.ShouldBe(expected);
        }

        [Theory]
        [InlineData(42, 100, false)]
        [InlineData(42, 7, true)]
        [InlineData(42, 42, true)]
        [InlineData(42, -42, true)]
        [InlineData(-42, 42, false)]
        [InlineData(-42, -42, true)]
        public void CanCompareGreaterThanEqual(
            decimal amount1,
            decimal amount2,
            bool expected)
        {
            const string currency = "AUD";
            Money m1 = new Money(amount1, currency),
                m2 = new Money(amount2, currency);

            var actual = m1 >= m2;

            actual.ShouldBe(expected);
        }

        [Theory]
        [InlineData(42, 100, true)]
        [InlineData(42, 7, false)]
        [InlineData(42, 42, false)]
        [InlineData(42, -42, false)]
        [InlineData(-42, 42, true)]
        [InlineData(-42, -42, false)]
        public void CanCompareLessThan(
            decimal amount1,
            decimal amount2,
            bool expected)
        {
            const string currency = "AUD";
            Money m1 = new Money(amount1, currency),
                m2 = new Money(amount2, currency);

            var actual = m1 < m2;

            actual.ShouldBe(expected);
        }

        [Theory]
        [InlineData(42, 100, true)]
        [InlineData(42, 7, false)]
        [InlineData(42, 42, true)]
        [InlineData(42, -42, false)]
        [InlineData(-42, 42, true)]
        [InlineData(-42, -42, true)]
        public void CanCompareLessThanEqual(
            decimal amount1,
            decimal amount2,
            bool expected)
        {
            const string currency = "AUD";
            Money m1 = new Money(amount1, currency),
                m2 = new Money(amount2, currency);

            var actual = m1 <= m2;

            actual.ShouldBe(expected);
        }
    }
}