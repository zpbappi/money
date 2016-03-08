using System;
using System.Numerics;
using Money.Exceptions;
using Shouldly;
using Xunit;

namespace Money.Tests.MoneyTests.BinaryOperationWithNumbers
{
    public class SubtractWithNumericTypesTest
    {
        [Fact]
        public void SubtractingZeroShouldNotAffectTheAmount()
        {
            var money = new Money<long>(42L);
            money -= 0;
            money.Amount.ShouldBe(42);
        }

        [Fact]
        public void SubtractingSameDataTypeWillReflectInMoney()
        {
            const int delta = 100;
            var money = new Money<int>(42);
            const int expected = 42 - delta;
            money -= delta;
            money.Amount.ShouldBe(expected);
        }

        [Fact]
        public void SubtractWithNullWillNotChangeAnything()
        {
            var money = new Money<int>(42);
            var actual = money - null;
            actual.ShouldBe(money);
        }

        [Fact]
        public void TryingToSubtractValueOutOfRangeShouldThrowOverflowException()
        {
            var money = new Money<int>(42);
            Should.Throw<OverflowException>(() => money -= long.MaxValue);
        }

        [Fact]
        public void ResultingOverflowShouldBeThrown()
        {
            var money = new Money<int>(-42);
            Should.Throw<OverflowException>(() => money -= int.MaxValue);
        }

        [Fact]
        public void AMinusB_Is_BMinusA()
        {
            var money = new Money<int>(42);
            var actual = 100 - money;
            var expected = money - 100;
            actual.ShouldBe(expected);
        }

        [Fact]
        public void AdditionShouldWorkWithAnyCompatibleType()
        {
            const short delta = 100;
            const short expected = -58;

            AssertCanSubtractAllNumericTypesWithinRange(new Money<short>(42), delta, expected);
            AssertCanSubtractAllNumericTypesWithinRange(new Money<int>(42), delta, expected);
            AssertCanSubtractAllNumericTypesWithinRange(new Money<long>(42L), delta, expected);
            AssertCanSubtractAllNumericTypesWithinRange(new Money<float>(42f), delta, expected);
            AssertCanSubtractAllNumericTypesWithinRange(new Money<double>(42d), delta, expected);
            AssertCanSubtractAllNumericTypesWithinRange(new Money<decimal>(42m), delta, expected);
            AssertCanSubtractAllNumericTypesWithinRange(new Money<BigInteger>(new BigInteger(42)), delta, expected);

        }

        private static void AssertCanSubtractAllNumericTypesWithinRange<T>(
            Money<T> money,
            short delta,
            T expected)
            where T : struct, IComparable, IComparable<T>
        {
            (money - (int)delta).Amount.ShouldBe(expected);
            (money - (long)delta).Amount.ShouldBe(expected);
            (money - (double)delta).Amount.ShouldBe(expected);
            (money - (float)delta).Amount.ShouldBe(expected);
            (money - (decimal)delta).Amount.ShouldBe(expected);
            (money - (BigInteger)delta).Amount.ShouldBe(expected);
        }
    }
}