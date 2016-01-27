using System;
using System.Linq.Expressions;

namespace Money.Internal.Helpers
{
    public static class NumericTypeHelper
    {
        public static bool CanCastTo<TDestination>(object sourceValue)
        {
            if (sourceValue == null || sourceValue.GetType() == typeof(object))
                return false;

            try
            {
                Expression.Convert(Expression.Constant(sourceValue, sourceValue.GetType()), typeof(TDestination));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}