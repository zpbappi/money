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
        public void AnyMoneyShouldBeGreaterThanNull(decimal amount, string currency)
        {
            var money = new Money(amount, currency);
            
            var actual = money > null;

            actual.ShouldBeTrue();
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