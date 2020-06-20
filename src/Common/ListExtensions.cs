using System.Collections.Generic;

namespace Common.Extensions
{
    public static class ListExtensions
    {
        public static bool IsNullOrEmpty<T>(this IList<T> list)
        {
            var isNullOrEmpty = true;
            if (list?.Count > 0)
            {
                isNullOrEmpty = false;
            }

            return isNullOrEmpty;
        }
    }
}
