using System;
using Shouldly;
using Xunit;

namespace Money.Tests.MoneyTests.BinaryOperationWithNumbers
{
    public class ShiftOperatorTests
    {
        [Fact]
        public void ShiftingZeroTimes_IsAWasteOfTime()
        {
            var money = new Money<long>(42L);
            var actual = money << 0;
            actual.ShouldBe(money);

            actual = money >> 0;
            actual.ShouldBe(money);
        }

        [Fact]
        public void WhenShiftingUnsupportedTypes_ShouldThrowInvalidOperation()
        {
            var money = new Money<decimal>(42m);

            Should.Throw<InvalidOperationException>(() => money >>= 0);
            Should.Throw<InvalidOperationException>(() => money <<= 0);
        }

        [Fact]
        public void ShiftingWithinTheRange_ShouldWorkProperly()
        {
            var money = new Money<int>(42);

            (money << 1).Amount.ShouldBe(42*2);
            (money >> 1).Amount.ShouldBe(42/2);
        }
    }
}