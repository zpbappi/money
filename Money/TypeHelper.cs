using System;

namespace Money
{
    internal static class TypeHelper
    {
        public static bool IsValueType<T>()
        {
            var type = typeof (T);
            return type.IsValueType;
        }

        public static bool IsNullableValueType<T>()
        {
            var type = typeof (T);
            return Nullable.GetUnderlyingType(type) != null;
        }

        public static bool IsReferenceType<T>()
        {
            return !IsValueType<T>();
        }

        public static bool CanHaveNull<T>()
        {
            return IsReferenceType<T>() || IsNullableValueType<T>();
        }
    }
}