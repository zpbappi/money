using System;
using System.Linq.Expressions;

namespace Money
{
    public partial class Money<T>
    {
        public static Money<T> operator ++(Money<T> me)
        {
            return ApplyUnaryOperation(me.Amount, me.Currency, Expression.Increment);
        }

        public static Money<T> operator --(Money<T> me)
        {
            return ApplyUnaryOperation(me.Amount, me.Currency, Expression.Decrement);
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