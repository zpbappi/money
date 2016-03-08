using System.Collections.Generic;

namespace Money
{
    public sealed partial class Money<T>
    {
        public static bool operator ==(Money<T> money1, Money<T> money2)
        {
            if (ReferenceEquals(null, money1))
                return false;
            if (ReferenceEquals(null, money2))
                return false;

            return money1.Equals(money2);
        }

        public static bool operator !=(Money<T> money1, Money<T> money2)
        {
            return !(money1 == money2);
        }

        public bool Equals(Money<T> other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return EqualityComparer<T>.Default.Equals(this.Amount, other.Amount) &&
                string.Equals(this.Currency, other.Currency);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return this.Equals((Money<T>)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (EqualityComparer<T>.Default.GetHashCode(this.Amount) * 397) ^ this.Currency.GetHashCode();
            }
        }
    }
}