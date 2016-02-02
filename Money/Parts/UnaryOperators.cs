using System;
using System.Linq.Expressions;
using Money.Internal.Helpers;

namespace Money
{
    public partial class Money<T>
    {
        public static Money<T> operator ++(Money<T> me)
        {
            var val = BinaryOperationHelper.AddChecked(me.Amount, NumericTypeHelper.ConvertTo<T>(1));
            return new Money<T>(val, me.Currency);
        }

        public static Money<T> operator --(Money<T> me)
        {
            var val = BinaryOperationHelper.AddChecked(me.Amount, NumericTypeHelper.ConvertTo<T>(-1));
            return new Money<T>(val, me.Currency);
        }

        public static Money<T> operator -(Money<T> me)
        {
            return ApplyUnaryOperation(me.Amount, me.Currency, Expression.NegateChecked);
        }

        private static Money<T> ApplyUnaryOperation(
            T amount, 
            string currency,
            Func<Expression, UnaryExpression> unaryExpressionFunction)
        {
            var currentValue = Expression.Constant(amount, typeof(T));
            var unaryExpression = unaryExpressionFunction(currentValue);
            var newValue = Expression.Lambda<Func<T>>(unaryExpression).Compile()();
            return new Money<T>(newValue, currency);
        } 
    }
}