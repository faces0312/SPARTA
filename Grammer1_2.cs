using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grammer
{
    class Grammer1_2
    {
        static void Main(string[] args)
        {
            int sum = 0;
            float avarage = 0;

            string[] str = Console.ReadLine().Split(' ');

            for(int i=0; i<str.Length; i++)
            {
                sum += int.Parse(str[i]);
            }

            avarage = (float)sum / str.Length;

            Console.WriteLine("Sum : " + sum);
            Console.WriteLine("Avarage : " + avarage);
        }
    }
}
