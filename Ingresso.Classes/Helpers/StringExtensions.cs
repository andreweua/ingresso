using System.Linq;

namespace Ingresso.Classes
{
    public static class StringExtensions
    {
        #region Públicos

        public static long ConvertToLongValue(this string str)
        {
            long ret = 0;

            var num = string.Join("", str.ToList().FindAll(c => c >= '0' && c <= '9'));
            long.TryParse(num, out ret);

            return ret;
        }

        #endregion
    }
}
