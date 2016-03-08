using System;
using System.Numerics;
using Money.Exceptions;
using Shouldly;
using Xunit;

namespace Money.Tests.MoneyTests.BinaryOperationWithNumbers
{
    public class DivisionWithNumericTypesTest
    {
        [Fact]
        public void DividingWithZero_ShouldThrowException()
        {
            var money = new Money<long>(42L);
            Should.Throw<DivideByZeroException>(() => money /= 0);
        }

        [Fact]
        public void DividingByOne_ShouldNotChangeTheAmount()
        {
            var money = new Money<decimal>(42m);
            var actual = money / 1m;
            actual.ShouldBe(money);
        }

        [Fact]
        public void DividingSameDataType_ShouldReflectInMoney()
        {
            const decimal delta = 100m;
            var money = new Money<decimal>(42m);
            const decimal expected = 42 / delta;
            money /= delta;
            money.Amount.ShouldBe(expected);
        }

        [Fact]
        public void DividingByNull_ShouldNotChangeAnything()
        {
            var money = new Money<int>(42);
            var actual = money / (ValueType)null;
            actual.ShouldBe(money);
        }

        [Fact]
        public void TryingToDivideByValueOutOfRange_ShouldThrowOverflowException()
        {
            var money = new Money<int>(42);
            Should.Throw<OverflowException>(() => money /= long.MaxValue);
        }

        [Fact]
        public void DivisionShouldWorkWithAnyCompatibleType()
        {
            const short divisor = 6;
            const short expected = 42 / divisor;

            AssertCanMultiplyAllNumericTypesWithinRange(new Money<short>(42), divisor, expected);
            AssertCanMultiplyAllNumericTypesWithinRange(new Money<int>(42), divisor, expected);
            AssertCanMultiplyAllNumericTypesWithinRange(new Money<long>(42L), divisor, expected);
            AssertCanMultiplyAllNumericTypesWithinRange(new Money<float>(42f), divisor, expected);
            AssertCanMultiplyAllNumericTypesWithinRange(new Money<double>(42d), divisor, expected);
            AssertCanMultiplyAllNumericTypesWithinRange(new Money<decimal>(42m), divisor, expected);
            AssertCanMultiplyAllNumericTypesWithinRange(new Money<BigInteger>(new BigInteger(42)), divisor, expected);

        }

        private static void AssertCanMultiplyAllNumericTypesWithinRange<T>(
            Money<T> money,
            short divisor,
            T expected)
            where T : struct, IComparable, IComparable<T>
        {
            (money / (int)divisor).Amount.ShouldBe(expected);
            (money / (long)divisor).Amount.ShouldBe(expected);
            (money / (double)divisor).Amount.ShouldBe(expected);
            (money / (float)divisor).Amount.ShouldBe(expected);
            (money / (decimal)divisor).Amount.ShouldBe(expected);
            (money / (BigInteger)divisor).Amount.ShouldBe(expected);
        }
    }
}