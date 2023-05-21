using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA
{
    internal class PrimeNumberGenerator
    {
        private static Random random = new Random();

        public static int Generate(int left, int right) //left right це діапазони задання рандомного числа
        {
            int values = random.Next(left, right);
            while(!IsPrime(values))
            {
                values++;
            }
            return values;
        }

        private static bool IsPrime(int values)
        {
            for (int i = 2; i <= values / 2; i++)
            {
                if (values % i == 0)
                    return false;
            }
            return true;
        }
    }
}
