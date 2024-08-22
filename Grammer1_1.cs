using System;

namespace Grammer
{
    class Grammer1_1
    {
        static void Main(string[] args)
        {
            /*for문을 이용
            for(int i=1; i<100; i+=2)
            {
                Console.WriteLine(i);
            }
            */

            /*while문 이용
            int i = 1;
            while(i<100)
            {
                Console.WriteLine(i);
                i += 2;
            }
            */

            //do while문 이용
            int i = 1;
            do
            {
                Console.WriteLine(i);
                i += 2;
            } while (i < 100);
        }
    }
}
