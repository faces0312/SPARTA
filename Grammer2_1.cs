using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grammer
{
    class Grammer2_1
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int factorial = 1;

            for(int i=num; i>0; i--)
            {
                factorial = factorial * i;
            }

            Console.WriteLine("Factorial of {0} is {1}", num, factorial);
        }
    }
}
