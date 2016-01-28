using System;

namespace Money.Exceptions
{
    public class IncompatibleAmountTypeException : InvalidOperationException
    {
        public Type SourceType { get; set; }
        public Type DestinationType { get; set; }

        public IncompatibleAmountTypeException(
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