using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grammer
{
    class Grammer3_1
    {
        static void Main(string[] args)
        {
            string secretWord = "hangman";
            char[] guessWord = new char[secretWord.Length];
            int attempts = 6;
            bool wordGuessed = false;



            Console.WriteLine("행맨 게임을 시작하세요");
            for (int i = 0; i < secretWord.Length; i++)
            {
                guessWord[i] = '_';
                Console.Write(guessWord[i]);
            }

            do
            {
                bool turn_Guess = false;

                //입력
                Console.WriteLine("\n남은기회 : " + attempts);
                Console.WriteLine("\n알파벳을 입력하세요");
                char word = Console.ReadLine()[0];
                Console.Write("\n");
                //같은 알파벳이 있는지 확인
                for (int i = 0; i < secretWord.Length; i++)
                {
                    if(secretWord[i].Equals(word))
                    {
                        guessWord[i] = secretWord[i];
                        turn_Guess = true;
                    }
                }
                int cnt = 0;
                //맞췄는지 확인
                for (int i = 0; i < secretWord.Length; i++)
                {
                    if (secretWord[i].Equals(guessWord[i]))
                        cnt++;

                    if (cnt == secretWord.Length)
                        wordGuessed = true;
                    Console.Write(guessWord[i]);
                }

                if(wordGuessed == true)
                    break;

                //도전횟수 감소
                if (turn_Guess == false)
                {
                    Console.WriteLine("\n틀렸습니다");
                    attempts--;
                }

            } while (attempts >= 0);



            if(wordGuessed == true)
                Console.WriteLine("\n이겼습니다!");
            else
                Console.WriteLine("\n졌습니다.");

        }
    }
}
