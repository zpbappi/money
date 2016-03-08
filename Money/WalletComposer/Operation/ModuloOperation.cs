using Money.Internal.Helpers;

namespace Money.WalletComposer.Operation
{
    internal class ModuloOperation : BinaryOperation
    {
        public override Money<T> Operate<T>(Money<T> left, Money<T> right)
        {
            return base.ApplyBinaryOperation(left, right, BinaryOperationHelper.Modulo);
        }
    }
}