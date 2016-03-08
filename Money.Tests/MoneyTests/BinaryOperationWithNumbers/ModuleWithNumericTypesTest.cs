using System;
using System.Numerics;
using Money.Exceptions;
using Shouldly;
using Xunit;

namespace Money.Tests.MoneyTests.BinaryOperationWithNumbers
{
    public class ModuleWithNumericTypesTest
    {
        [Fact]
        public void ModuloWithZero_ShouldThrowException()
        {
            var money = new Money<long>(42L);
            Should.Throw<DivideByZeroException>(() => money %= 0);
        }

        [Fact]
        public void ModuloByOne_ShouldReturnMoneyWithZeroAmount()
        {
            var money = new Money<decimal>(42m);
            var expected = new Money<decimal>(0m);
            
            var actual = money % 1m;

            actual.ShouldBe(expected);
        }

        [Fact]
        public void ModuloOfSameDataType_ShouldReflectInMoney()
        {
            const decimal divisor = 42m;
            var money = new Money<decimal>(100m);
            var expected = new Money<decimal>(16m);

            var actual = money%divisor;

            actual.ShouldBe(expected);
        }

        [Fact]
        public void ModuleByNull_ShouldNotChangeAnything()
        {
            var money = new Money<int>(42);
            var actual = money % (ValueType) null;
            actual.ShouldBe(money);
        }

        [Fact]
        public void TryingToModuloByValueOutOfRange_ShouldThrowOverflowException()
        {
            var money = new Money<int>(42);
            Should.Throw<OverflowException>(() => money %= long.MaxValue);
        }

        [Fact]
        public void ModuloShouldWorkWithAnyCompatibleType()
        {
            const short divisor = 5;
            const short expected = 42 % divisor;

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
            (money % (int)divisor).Amount.ShouldBe(expected);
            (money % (long)divisor).Amount.ShouldBe(expected);
            (money % (double)divisor).Amount.ShouldBe(expected);
            (money % (float)divisor).Amount.ShouldBe(expected);
            (money % (decimal)divisor).Amount.ShouldBe(expected);
            (money % (BigInteger)divisor).Amount.ShouldBe(expected);
        }
    }
}