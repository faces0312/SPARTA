using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grammer
{
    class Grammer2_3
    {
        static void Main(string[] args)
        {
            //구구단 세로 출력
            /*for(int i=1; i<=9; i++)
            {
                for(int j=2; j<=9; j++)
                {
                    Console.Write("{0} X {1} = {2}\t", j,i,j*i);
                }
                Console.WriteLine("");
            }*/

            //구구단 가로 출력
            for (int i = 2; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    Console.Write("{0} X {1} = {2}\t", i, j, j * i);
                }
                Console.WriteLine("");
            }
        }
    }
}
