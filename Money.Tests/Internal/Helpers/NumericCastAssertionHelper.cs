using System.Collections.Generic;
using System.Numerics;
using Money.Internal.Helpers;
using Shouldly;

namespace Money.Tests.Internal.Helpers
{
    public static class NumericCastAssertionHelper
    {
        public static void ShouldNotBeConvertibleToAnyNumericType(this object value)
        {
            var castingResults = GetCastingResults(value);

            castingResults.ShouldNotContain(true);
        }

        public static void ShouldBeConvertibleToAllNumericTypes(this object value)
        {
            var castingResults = GetCastingResults(value);

            castingResults.ShouldNotContain(false);
        }

        private static List<bool> GetCastingResults(object value)
        {
            var castingResults = new List<bool>
            {
                NumericTypeHelper.CanCastTo<short>(value),
                NumericTypeHelper.CanCastTo<int>(value),
                NumericTypeHelper.CanCastTo<long>(value),
                NumericTypeHelper.CanCastTo<double>(value),
                NumericTypeHelper.CanCastTo<decimal>(value),
                NumericTypeHelper.CanCastTo<BigInteger>(value)
            };
            return castingResults;
        }
    }
}