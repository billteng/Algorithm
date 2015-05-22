using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public static class MathOne
    {
        public static int IsPrime(int x)
        {
            int i;

            if (x <= 1)
            {
                return 0;
            }

            for (i = 2; i * i <= x; ++i)
            {
                if (x % i == 0)
                {
                    return 0;
                }
            }

            return 1;
        }
    }
}
