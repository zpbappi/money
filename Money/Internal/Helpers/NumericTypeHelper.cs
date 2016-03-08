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

        public static T ConvertTo<T>(ValueType value)
        {
            var exp = Expression.ConvertChecked(Expression.Constant(value, value.GetType()), typeof(T));
            return Expression.Lambda<Func<T>>(exp).Compile()();
        }

        public static T? TryConvertTo<T>(ValueType value) where T : struct 
        {
            try
            {
                return ConvertTo<T>(value);
            }
            catch (OverflowException)
            {
                return null;
            }
        }
    }
}