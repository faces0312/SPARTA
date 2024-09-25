using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Job
    {
        public string Name { get; set; }
        public string Info { get; set; }
        //공격력
        public int IQ { get; set; }
        //방어
        public int Focus { get; set; }
        //체력
        public int Time { get; set; }

        public virtual void JobInformation()
        {
            Name = "";
            Info = "";
            IQ = 0;
            Focus = 0;
            Time = 0;
        }

        public virtual void Status()
        {
            Console.WriteLine("Lv. 01");
            Console.WriteLine("Chad ( 전사 )");
            Console.WriteLine("공격력 : 10");
            Console.WriteLine("방어력 : 5");
            Console.WriteLine("체 력 : 100");
            Console.WriteLine("Gold : 1500 G");
            Console.WriteLine("\n0. 나가기");
        }

    }
    public class Student : Job
    {
        public override void JobInformation()
        {
            Name = "수강생";
            Info = "배우는 단계이지만 코더의 자질과 열정만은 최강이다.";
            IQ = 1;
            Focus = 3;
            Time = 100;
        }

        public override void Status()
        {
            Console.WriteLine("Lv. {0}", Program.lv);
            Console.WriteLine("Chad ( {0} )", Name);
            Console.WriteLine("체 력 : {0}", Program.hp);
            Console.WriteLine("지 식  : {0}", IQ + Program.add_IQ);
            Console.WriteLine("집중력 : {0}", Focus + Program.add_Focus);
            Console.WriteLine("시 간  : {0}", Time + Program.add_Time);
            Console.WriteLine("Gold : {0}", Program.money);
            Console.WriteLine("\n0. 나가기");
            while (true)
            {
                Console.Write("\n원하시는 행동을 입력하세요.\n>>");
                int num_Select = int.Parse(Console.ReadLine());
                if (num_Select == 0)
                    break;
            }
            Program.Menu();
        }

    }

    public class Tutor : Job
    {
        public override void JobInformation()
        {
            Name = "튜터";
            Info = "코더의 완벽한 육각형이다.";
            IQ = 3;
            Focus = 3;
            Time = 100;
        }
        public override void Status()
        {
            Console.WriteLine("Lv. {0}", Program.lv);
            Console.WriteLine("Chad ( {0} )", Name);
            Console.WriteLine("체 력 : {0}", Program.hp);
            Console.WriteLine("지 식  : {0}", IQ + Program.add_IQ);
            Console.WriteLine("집중력 : {0}", Focus + Program.add_Focus);
            Console.WriteLine("시 간  : {0}", Time + Program.add_Time);
            Console.WriteLine("Gold : " + Program.money);
            Console.WriteLine("\n0. 나가기");
            while (true)
            {
                Console.Write("\n원하시는 행동을 입력하세요.\n>>");
                int num_Select = int.Parse(Console.ReadLine());
                if (num_Select == 0)
                    break;
            }
            Program.Menu();
        }

    }

    public class Manager : Job
    {
        public override void JobInformation()
        {
            Name = "담임매니저";
            Info = "완벽한 코더도 하나씩의 부족은 있을지도?";
            IQ = 5;
            Focus = 5;
            Time = 100;
        }
        public override void Status()
        {
            Console.WriteLine("Lv. {0}", Program.lv);
            Console.WriteLine("Chad ( {0} )", Name);
            Console.WriteLine("체 력 : {0}", Program.hp);
            Console.WriteLine("지 식  : {0}", IQ + Program.add_IQ);
            Console.WriteLine("집중력 : {0}", Focus + Program.add_Focus);
            Console.WriteLine("시 간  : {0}", Time + Program.add_Time);
            Console.WriteLine("Gold : 1500 G");
            Console.WriteLine("\n0. 나가기");
            while (true)
            {
                Console.Write("\n원하시는 행동을 입력하세요.\n>>");
                int num_Select = int.Parse(Console.ReadLine());
                if (num_Select == 0)
                    break;
            }
            Program.Menu();
        }

    }
}
