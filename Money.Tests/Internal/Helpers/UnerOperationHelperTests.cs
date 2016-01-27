using System;
using System.Numerics;
using Money.Internal.Helpers;
using Shouldly;
using Xunit;

namespace Money.Tests.Internal.Helpers
{
    public class UnerOperationHelperTests
    {
        [Fact]
        public void UnaryOperationOnIntShouldBeSupported()
        {
            EnsureIncrementDecrementNegation<int>(true);
            UnaryOperationHelper.SupportsOnesCompliment<int>().ShouldBeTrue();
        }

        [Fact]
        public void UnaryOperationOnLongShouldBeSupported()
        {
            EnsureIncrementDecrementNegation<long>(true);
            UnaryOperationHelper.SupportsOnesCompliment<long>().ShouldBeTrue();
        }

        [Fact]
        public void UnaryOperationOnShortShouldBeSupported()
        {
            EnsureIncrementDecrementNegation<short>(true);
            UnaryOperationHelper.SupportsOnesCompliment<short>().ShouldBeTrue();
        }

        [Fact]
        public void UnaryOperationOnDecimalShouldBeSupported()
        {
            EnsureIncrementDecrementNegation<decimal>(true);
            UnaryOperationHelper.SupportsOnesCompliment<decimal>().ShouldBeFalse();
        }

        [Fact]
        public void UnaryOperationOnBigIntegerShouldBeSupported()
        {
            EnsureIncrementDecrementNegation<BigInteger>(true);
            UnaryOperationHelper.SupportsOnesCompliment<BigInteger>().ShouldBeTrue();
        }

        [Fact]
        public void UnaryOperationOnInvalidTypeShouldNotBeSupported()
        {
            EnsureIncrementDecrementNegation<object>(false);
            UnaryOperationHelper.SupportsOnesCompliment<object>().ShouldBeFalse();
        }

        [Fact]
        public void ShouldProperlyDetectPartialUnaryOperationImplementation()
        {
            UnaryOperationHelper.SupportsIncrement<PartiallyUnarySupportedNumber>().ShouldBeTrue();
            UnaryOperationHelper.SupportsDecrement<PartiallyUnarySupportedNumber>().ShouldBeFalse();
            UnaryOperationHelper.SupportsNegation<PartiallyUnarySupportedNumber>().ShouldBeFalse();
            UnaryOperationHelper.SupportsOnesCompliment<PartiallyUnarySupportedNumber>().ShouldBeTrue();
            UnaryOperationHelper.SupportsUnaryPlus<PartiallyUnarySupportedNumber>().ShouldBeFalse();
        }

        public static void EnsureIncrementDecrementNegation<T>(bool expectedValue)
        {
            UnaryOperationHelper.SupportsIncrement<T>().ShouldBe(expectedValue);
            UnaryOperationHelper.SupportsDecrement<T>().ShouldBe(expectedValue);
            UnaryOperationHelper.SupportsNegation<T>().ShouldBe(expectedValue);
            UnaryOperationHelper.SupportsIncrement<T>().ShouldBe(expectedValue);
        }
    }

    public struct PartiallyUnarySupportedNumber
    {
        private readonly int number;

        public PartiallyUnarySupportedNumber(int number)
        {
            this.number = number;
        }

        public static PartiallyUnarySupportedNumber operator ++(PartiallyUnarySupportedNumber me)
        {
            return new PartiallyUnarySupportedNumber(me.number + 1);
        }

        public static PartiallyUnarySupportedNumber operator ~(PartiallyUnarySupportedNumber me)
        {
            return new PartiallyUnarySupportedNumber(~me.number);
        }
    }
}