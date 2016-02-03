using System;
using System.Numerics;
using Money.Exceptions;
using Shouldly;
using Xunit;

namespace Money.Tests.MoneyTests.BinaryOperationWithNumbers
{
    public class MultiplicationWithNumericTypesTest
    {
        [Fact]
        public void MultiplyingWithZero_ShouldMakeTheAmount()
        {
            var money = new Money<long>(42L);
            money *= 0;
            money.Amount.ShouldBe(0);
        }

        [Fact]
        public void MultiplyingWithOne_ShouldNotChangeTheAmount()
        {
            var money = new Money<int>(42);
            var actual = money*1;
            actual.ShouldBe(money);
        }

        [Fact]
        public void MultiplyingSameDataType_ShouldReflectInMoney()
        {
            const int delta = 100;
            var money = new Money<int>(42);
            const int expected = 42 * delta;
            money *= delta;
            money.Amount.ShouldBe(expected);
        }

        [Fact]
        public void TryingToMultiplyInvalidType_ShouldResultInProperException()
        {
            var money = new Money<int>(42);
            Should.Throw<IncompatibleAmountTypeException>(() => money *= "INVALID");
        }

        [Fact]
        public void MultiplyingWithNull_ShouldNotChangeAnything()
        {
            var money = new Money<int>(42);
            var actual = money * (object)null;
            actual.ShouldBe(money);
        }

        [Fact]
        public void TryingToMultiplyValueOutOfRange_ShouldThrowOverflowException()
        {
            var money = new Money<int>(42);
            Should.Throw<OverflowException>(() => money *= long.MaxValue);
        }

        [Fact]
        public void ResultingOverflowShouldBeThrown()
        {
            var money = new Money<int>(42);
            Should.Throw<OverflowException>(() => money *= int.MaxValue);
        }

        [Fact]
        public void ATimesB_Is_BTimesA()
        {
            var money = new Money<int>(42);
            var actual = 100 * money;
            var expected = money * 100;
            actual.ShouldBe(expected);
        }

        [Fact]
        public void MultiplicationShouldWorkWithAnyCompatibleType()
        {
            const short multiplier = 100;
            const short expected = 42 * multiplier;

            AssertCanMultiplyAllNumericTypesWithinRange(new Money<short>(42), multiplier, expected);
            AssertCanMultiplyAllNumericTypesWithinRange(new Money<int>(42), multiplier, expected);
            AssertCanMultiplyAllNumericTypesWithinRange(new Money<long>(42L), multiplier, expected);
            AssertCanMultiplyAllNumericTypesWithinRange(new Money<float>(42f), multiplier, expected);
            AssertCanMultiplyAllNumericTypesWithinRange(new Money<double>(42d), multiplier, expected);
            AssertCanMultiplyAllNumericTypesWithinRange(new Money<decimal>(42m), multiplier, expected);
            AssertCanMultiplyAllNumericTypesWithinRange(new Money<BigInteger>(new BigInteger(42)), multiplier, expected);

        }

        private static void AssertCanMultiplyAllNumericTypesWithinRange<T>(
            Money<T> money,
            short multiplier,
            T expected)
            where T : struct, IComparable, IComparable<T>
        {
            (money * (int)multiplier).Amount.ShouldBe(expected);
            (money * (long)multiplier).Amount.ShouldBe(expected);
            (money * (double)multiplier).Amount.ShouldBe(expected);
            (money * (float)multiplier).Amount.ShouldBe(expected);
            (money * (decimal)multiplier).Amount.ShouldBe(expected);
            (money * (BigInteger)multiplier).Amount.ShouldBe(expected);
        }
    }
}