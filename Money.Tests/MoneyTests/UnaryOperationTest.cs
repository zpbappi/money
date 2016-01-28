using Shouldly;
using Xunit;

namespace Money.Tests.MoneyTests
{
    using Money = Money<decimal>;
    public class UnaryOperationTest
    {
        [Theory]
        [InlineData(long.MinValue)]
        [InlineData(-100)]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        [InlineData(long.MaxValue)]
        public void ShouldIncrementMoney(decimal amount)
        {
            var money = new Money(amount);
            money++;
            var expected = new Money(amount + 1);

            money.ShouldBe(expected);
        }

        [Theory]
        [InlineData(long.MinValue)]
        [InlineData(-100)]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        [InlineData(long.MaxValue)]
        public void ShouldDecrementMoney(decimal amount)
        {
            var money = new Money(amount);
            money--;
            var expected = new Money(amount - 1);

            money.ShouldBe(expected);
        }
    }
}