using System;
using System.Linq.Expressions;

namespace Money.Internal.Helpers
{
    public static class UnaryOperationHelper
    {
        internal static bool SupportsUnaryOperation<T>(Func<Expression, UnaryExpression> unaryOperation)
        {
            try
            {
                var operand = Expression.Constant(default(T), typeof(T));
                unaryOperation(operand);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool SupportsIncrement<T>()
        {
            return SupportsUnaryOperation<T>(Expression.Increment); 
        }

        public static bool SupportsDecrement<T>()
        {
            return SupportsUnaryOperation<T>(Expression.Decrement);
        }

        public static bool SupportsNegation<T>()
        {
            return SupportsUnaryOperation<T>(Expression.Negate);
        }

        public static bool SupportsCheckedNegation<T>()
        {
            return SupportsUnaryOperation<T>(Expression.NegateChecked);
        }

        public static bool SupportsUnaryPlus<T>()
        {
            return SupportsUnaryOperation<T>(Expression.UnaryPlus);
        }

        public static bool SupportsOnesCompliment<T>()
        {
            return SupportsUnaryOperation<T>(Expression.OnesComplement);
        }
    }
}