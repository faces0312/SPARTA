using System;
using System.Collections.Generic;

class Grammer0
{
    public static void Main(string[] args) 
    {
        Console.WriteLine("�̸��� ���̸� ���ϼ���");
        string intput = Console.ReadLine();

        string[] divide = intput.Split(' ');

        int num = int.Parse(divide[1]);

        Console.WriteLine("�̸� : {0}  ���� : {1}", divide[0], num);
    }
}
