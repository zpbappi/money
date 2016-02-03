using System;
using System.Numerics;
using Money.Exceptions;
using Shouldly;
using Xunit;

namespace Money.Tests.MoneyTests
{
    public class AdditionWithNumericTypesTest
    {
        [Fact]
        public void AddingWithZeroShouldNotAffectTheAmount()
        {
            var money = new Money<long>(42L);
            money += 0;
            money.Amount.ShouldBe(42);
        }

        [Fact]
        public void AddingSameDataTypeWillReflectInMoney()
        {
            var delta = 100;
            var money = new Money<int>(42);
            var expected = 42 + delta;
            money += delta;
            money.Amount.ShouldBe(expected);
        }

        [Fact]
        public void TryingToAddInvalidTypeWillResultInProperException()
        {
            var money = new Money<int>(42);
            Should.Throw<IncompatibleAmountTypeException>(() => money += "INVALID");
        }

        [Fact]
        public void AddingWithNullWillNotChangeAnything()
        {
            var money = new Money<int>(42);
            var actual = money + (object)null;
            actual.ShouldBe(money);
        }

        [Fact]
        public void TryingToAddValueOutOfRangeShouldThrowOverflowException()
        {
            var money = new Money<int>(42);
            Should.Throw<OverflowException>(() => money += long.MaxValue);
        }

        [Fact]
        public void ResultingOverflowShouldBeThrown()
        {
            var money = new Money<int>(42);
            Should.Throw<OverflowException>(() => money += int.MaxValue);
        }

        [Fact]
        public void APlusBIsBPlusA()
        {
            var money = new Money<int>(42);
            var actual = 100 + money;
            var expected = money + 100;
            actual.ShouldBe(expected);
        }

        [Fact]
        public void AdditionShouldWorkWithAnyCompatibleType()
        {
            AssertCanAddAllNumericTypesWithinRange<short>(new Money<short>(42), 100, 142);
            AssertCanAddAllNumericTypesWithinRange(new Money<int>(42), 100, 142);
            AssertCanAddAllNumericTypesWithinRange(new Money<long>(42L), 100, 142);
            AssertCanAddAllNumericTypesWithinRange(new Money<float>(42f), 100, 142);
            AssertCanAddAllNumericTypesWithinRange(new Money<double>(42d), 100, 142);
            AssertCanAddAllNumericTypesWithinRange(new Money<decimal>(42m), 100, 142);
            AssertCanAddAllNumericTypesWithinRange(new Money<BigInteger>(new BigInteger(42)), 100, 142);

        }

        private static void AssertCanAddAllNumericTypesWithinRange<T>(
            Money<T> money, 
            short delta, 
            T expected) 
            where T : struct, IComparable, IComparable<T>
        {
            (money + (int)delta).Amount.ShouldBe(expected);
            (money + (long)delta).Amount.ShouldBe(expected);
            (money + (double)delta).Amount.ShouldBe(expected);
            (money + (float)delta).Amount.ShouldBe(expected);
            (money + (decimal)delta).Amount.ShouldBe(expected);
            (money + (BigInteger)delta).Amount.ShouldBe(expected);
        }
    }
}