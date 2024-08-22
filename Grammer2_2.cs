using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grammer
{
    class Grammer2_2
    {
        static void Main(string[] args)
        {
            int player_num = 0;

            Random ran = new Random();
            int result = ran.Next(1, 101); // 1 이상 101 미만의 난수 생성

            do
            {
                Console.Write("Enter your guss (1 - 100) : ");
                player_num = int.Parse(Console.ReadLine());

                if (player_num > result)
                    Console.WriteLine("Too high! Try again.");
                else if (player_num < result)
                    Console.WriteLine("Too low! Try again.");

            } while (player_num != result);



            Console.WriteLine("Congratulations! You guessed the number.");
        }
    }
}
