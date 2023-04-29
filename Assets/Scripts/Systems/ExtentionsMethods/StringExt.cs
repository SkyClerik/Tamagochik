using System.Linq;

namespace Extensions
{
    public static class StringExt
    {
        /// <summary>
        /// Возвращает значение, указывающее, содержит ли данная строка какую-нибудь из переданных построк.
        /// </summary>
        public static bool ContainsAny(this string str, params string[] values)
        {
            return values.Any(s => str.Contains(s));
        }
    }
}