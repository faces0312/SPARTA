using System;
using System.Collections.Generic;

class Grammer0
{
    public static void Main(string[] args) 
    {
        Console.WriteLine("이름과 나이를 말하세요");
        string intput = Console.ReadLine();

        string[] divide = intput.Split(' ');

        int num = int.Parse(divide[1]);

        Console.WriteLine("이름 : {0}  나이 : {1}", divide[0], num);
    }
}
