using System.Linq;

namespace Extensions
{
    public static class UtilsExt
    {
        public static bool IsNullAny<T>(params T[] array)
        {
            if (array == null)
                return true;

            return array.Any(value => value == null);
        }

        public static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
    }
}