using System;

namespace Money.Exceptions
{
    public class IncompatibleMoneyTypeException : InvalidOperationException
    {
        public Type SourceType { get; set; }
        public Type DestinationType { get; set; }

        public IncompatibleMoneyTypeException(
            Type sourceType,
            Type destinationType,
            string message)
            : base(message)
        {
            this.SourceType = sourceType;
            this.DestinationType = destinationType;
        }
    }
}