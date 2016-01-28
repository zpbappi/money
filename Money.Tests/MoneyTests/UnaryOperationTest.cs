using Shouldly;
using Xunit;

namespace Money.Tests.MoneyTests
{
    using Money = Money<long>;
    public class UnaryOperationTest
    {
        [Theory]
        [InlineData(long.MinValue)]
        [InlineData(-100)]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        [InlineData(long.MaxValue-1)]
        public void ShouldIncrementMoney(long amount)
        {
            var money = new Money(amount);
            money++;
            var expected = new Money(amount + 1);

            money.ShouldBe(expected);
        }

        [Theory]
        [InlineData(long.MinValue+1)]
        [InlineData(-100)]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        [InlineData(long.MaxValue)]
        public void ShouldDecrementMoney(long amount)
        {
            var money = new Money(amount);
            money--;
            var expected = new Money(amount - 1);

            money.ShouldBe(expected);
        }

        [Theory]
        [InlineData(long.MinValue+1)]
        [InlineData(-100)]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        [InlineData(long.MaxValue)]
        public void ShouldNegateMoney(long amount)
        {
            var money = -new Money(amount);
            
            var expected = new Money(-amount);

            money.ShouldBe(expected);
        }
    }
}