using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace CampaignMonitor
{
    public static class Questions
    {
        /// <summary>
        /// Requirement 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return value == null || value.Trim().Length == 0;
        }

        /// <summary>
        /// Requirement 2
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string PositiveDivisors(int number)
        {
            var list = new List<int>(); // if we don't consider the orders of output number, we can use the StringBuilder()

            if (number <= 0 || number >= int.MaxValue)
                return null;

            var i = 1;
            var max = number;

            while (i < max)
            {
                max = number / i;
                var mod = number % i;

                if (mod == 0)
                {
                    list.Add(i);                    
                    list.Add(max);
                }

                i++;
            }

            list.Sort();

            return new JavaScriptSerializer().Serialize(list).Replace("[", "{").Replace("]", "}");
        }

        /// <summary>
        /// Requirement 3
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static double AreaOfTriangle(int a, int b, int c)
        {
            if (a <= 0 || b <= 0 || c <= 0 || a >= int.MaxValue || b >= int.MaxValue || c >= int.MaxValue)
                throw new Exception("InvalidTriangleException");

            if (a + b + c >= int.MaxValue || a + b > int.MaxValue || a + c > int.MaxValue || b + c >= int.MaxValue || a + b <= c || a + c <= b || b + c <= a)
                throw new Exception("InvalidTriangleException");

            var p = (a + b + c) / 2.0;

            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
    }
}
