using System;

namespace Money.WalletComposer.Operation
{
    internal interface IBinaryOperation
    {
        Money<T> Operate<T>(Money<T> left, Money<T> right) where T : struct, IComparable, IComparable<T>;
    }
}