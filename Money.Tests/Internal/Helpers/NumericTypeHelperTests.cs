using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Money.Internal.Helpers;
using Shouldly;
using Xunit;

namespace Money.Tests.Internal.Helpers
{
    public class NumericTypeHelperTests
    {
        [Fact]
        public void CannotCastNullValues()
        {
            NumericTypeHelper.CanCastTo<int>(null).ShouldBeFalse();
        }

        [Fact]
        public void CannotConvertObjectType()
        {
            new object().ShouldNotBeConvertibleToAnyNumericType();
        }

        [Theory]
        [InlineData(43)]
        [InlineData(0)]
        [InlineData(-100)]
        [InlineData(int.MaxValue)]
        [InlineData(int.MinValue)]
        public void CanCastFromInt(int number)
        {
            number.ShouldBeConvertibleToAllNumericTypes();
        }

        [Theory]
        [InlineData(42)]
        [InlineData(0)]
        [InlineData(-100)]
        [InlineData(short.MaxValue)]
        [InlineData(short.MinValue)]
        public void CanCastFromShort(short number)
        {
            number.ShouldBeConvertibleToAllNumericTypes();
        }

        [Theory]
        [InlineData(42)]
        [InlineData(0)]
        [InlineData(-100)]
        [InlineData(long.MaxValue)]
        [InlineData(long.MinValue)]
        public void CanCastFromLong(long number)
        {
            number.ShouldBeConvertibleToAllNumericTypes();
        }

        [Theory]
        [InlineData(42)]
        [InlineData(0)]
        [InlineData(-100)]
        [InlineData(-99999999999)]
        public void CanCastFromDecimal(decimal number)
        {
            number.ShouldBeConvertibleToAllNumericTypes();
        }

        [Theory]
        [InlineData(42)]
        [InlineData(0)]
        [InlineData(-100)]
        [InlineData(long.MaxValue)]
        [InlineData(long.MinValue)]
        public void CanCastFromBigInteger(long number)
        {
            var bigNumber = new BigInteger(number);
            bigNumber.ShouldBeConvertibleToAllNumericTypes();
        }

        [Theory]
        [InlineData(42)]
        [InlineData(0)]
        [InlineData(-100)]
        [InlineData(-99999999999)]
        public void CanCastFromACustomNumberType(decimal number)
        {
            var customNumber = new CustomNumber(number);
            customNumber.ShouldBeConvertibleToAllNumericTypes();
        }


        [Theory]
        [InlineData("VALUE")]
        [InlineData("2")]
        public void CannotCastFromString(string str)
        {
            str.ShouldNotBeConvertibleToAnyNumericType();
        }

        [Fact]
        public void CannotConvertAnyNonNumericValues()
        {
            GetInconvertibleObjects().ForEach(
                item => item.ShouldNotBeConvertibleToAnyNumericType());
        }

        private static List<object> GetInconvertibleObjects()
        {
            return new List<object>
            {
                "42",
                "InvalidValue",
                new object(),
                DateTime.Now,
                new List<int>{1},
                Enumerable.Empty<long>(),
                new Complex(41.99, -1)
            };
        }
    }
}