using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grammer
{
    class Grammer2_4
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(' ');

            int[] num = new int[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                num[i] = int.Parse(str[i]);
            }

            Console.WriteLine("최댓값 : {0}, 최솟값 : {1}", num.Max(), num.Min());
        }
    }
}
