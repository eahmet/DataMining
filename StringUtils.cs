using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMiningForm
{
    public class StringUtils
    {
        public static int  CalculateDistance(string a, string b)
        {
            a = a.Replace(" ", "").ToLower(CultureInfo.InvariantCulture);
            b = b.Replace(" ", "").ToLower(CultureInfo.InvariantCulture);
            if (string.IsNullOrEmpty(a) && string.IsNullOrEmpty(b)) {
                return 0;
            }
            if (string.IsNullOrEmpty(a)) {
                return b.Length;
            }
            if (string.IsNullOrEmpty(b)) {
                return a.Length;
            }
            var  lengthA   = a.Length;
            var  lengthB   = b.Length;
            var  distances = new int[lengthA + 1, lengthB + 1];
            for (var i = 0;  i <= lengthA;  distances[i, 0] = i++);
            for (var j = 0;  j <= lengthB;  distances[0, j] = j++);

            for (var i = 1;  i <= lengthA;  i++)
            for (var j = 1;  j <= lengthB;  j++)
            {
                var  cost = b[j - 1] == a[i - 1] ? 0 : 1;
                distances[i, j] = Math.Min
                (
                    Math.Min(distances[i - 1, j] + 1, distances[i, j - 1] + 1),
                    distances[i - 1, j - 1] + cost
                );
            }
            return distances[lengthA, lengthB];
        }
    }
}
