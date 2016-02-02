using System;
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

        [Fact]
        public void ForBoundedTypes_ShouldThrowOverFlowOnIncrement()
        {
            var shortMoney = new Money<short>(short.MaxValue);
            Should.Throw<OverflowException>(() => ++shortMoney);

            var intMoney = new Money<int>(int.MaxValue);
            Should.Throw<OverflowException>(() => ++intMoney);

            var longMoney = new Money<long>(long.MaxValue);
            Should.Throw<OverflowException>(() => ++longMoney);
        }

        [Fact]
        public void ForBoundedTypes_ShouldThrowOverFlowOnDecrement()
        {
            var shortMoney = new Money<short>(short.MinValue);
            Should.Throw<OverflowException>(() => --shortMoney);

            var intMoney = new Money<int>(int.MinValue);
            Should.Throw<OverflowException>(() => --intMoney);

            var longMoney = new Money<long>(long.MinValue);
            Should.Throw<OverflowException>(() => --longMoney);
        }

        [Fact]
        public void ForBoundedTypes_ShouldThrowOverFlowOnNegate()
        {
            var shortMoney = new Money<short>(short.MinValue);
            Should.Throw<OverflowException>(() => { var m = -shortMoney; });

            var intMoney = new Money<int>(int.MinValue);
            Should.Throw<OverflowException>(() => { var m = -intMoney; });

            var longMoney = new Money<long>(long.MinValue);
            Should.Throw<OverflowException>(() => { var m = -longMoney; });
        }
    }
}