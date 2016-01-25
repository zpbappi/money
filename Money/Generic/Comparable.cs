using System;

namespace Money.Generic
{
    public partial class Money<T>
    {
        public int CompareTo(Money<T> other)
        {
            if (ReferenceEquals(null, other))
                return 1;

            if (this.Currency != other.Currency)
                throw new InvalidOperationException(string.Format("Cannot compare {0} and {1}.", this.Currency,
                    other.Currency));

            return this.Amount.CompareTo(other.Amount);
        }

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(null, obj))
                return 1;

            if (ReferenceEquals(this, obj))
                return 0;

            if (obj.GetType() != this.GetType())
                throw new InvalidOperationException(string.Format("Cannot convert object of type '{0}' to Money.", obj.GetType()));

            return this.CompareTo(obj as Money<T>);
        }

        public static bool operator >(Money<T> money1, Money<T> money2)
        {
            if (ReferenceEquals(null, money1))
                return false;
            if (ReferenceEquals(null, money2))
                return true;

            return money1.CompareTo(money2) > 0;
        }

        public static bool operator >=(Money<T> money1, Money<T> money2)
        {
            return (money1 > money2 || money1 == money2);
        }

        public static bool operator <(Money<T> money1, Money<T> money2)
        {
            return !(money1 >= money2);
        }

        public static bool operator <=(Money<T> money1, Money<T> money2)
        {
            return !(money1 > money2);
        }
    }
}