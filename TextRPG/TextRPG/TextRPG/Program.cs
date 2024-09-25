using System;
using System.Collections.Generic;
using System.IO;

namespace TextRPG
{
    public class Program
    {
        public static DataManager manager = new DataManager();
        public static string name = manager.LoadVariable("name");
        public static string job = manager.LoadVariable("job");
        public static string lv = manager.LoadVariable("lv");
        public static string hp = manager.LoadVariable("hp");
        public static string money = manager.LoadVariable("money");

        //보유 아이템 개수
        public static int item_cnt = 0;
        public static int equip_cnt = 1;
        //추가 능력치
        public static int add_IQ;
        public static int add_Focus;
        public static int add_Time;

        public static List<Job> list = new List<Job>();
        public static List<Item> list_Inventory = new List<Item>();
        public static List<Item> list_Item = new List<Item>();

        static void Main(string[] args)
        {

            list.Add(new Student());
            list.Add(new Tutor());
            list.Add(new Manager());

            list_Inventory.Add(new laptop());
            list_Inventory.Add(new Computer());
            list_Inventory.Add(new SuperComputer());
            list_Inventory.Add(new Pencil());
            list_Inventory.Add(new Pen());
            list_Inventory.Add(new FountainPen());
            list_Inventory[0].Item_Init();
            list_Inventory[1].Item_Init();
            list_Inventory[2].Item_Init();
            list_Inventory[3].Item_Init();
            list_Inventory[4].Item_Init();
            list_Inventory[5].Item_Init();


            for (int i = list_Inventory.Count - 1; i >= 0; i--)
            {
                if (list_Inventory[i].is_Have == false)
                    list_Inventory.RemoveAt(i);
            }

            list_Item.Add(new laptop());
            list_Item.Add(new Computer());
            list_Item.Add(new SuperComputer());
            list_Item.Add(new Pencil());
            list_Item.Add(new Pen());
            list_Item.Add(new FountainPen());

            Start_Name();
            Start_Job();
            list[int.Parse(job)].JobInformation();
            hp = (list[int.Parse(job)].Time + add_Time).ToString();

            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");

            Console.WriteLine("당신의 이름은 {0}입니다.", name);
            Console.WriteLine("당신의 직업은 {0}입니다.", list[int.Parse(job)].Name);

            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");

            Menu();

            //manager.InitializeFile();
        }


        public static void Start_Name()
        {
            money = "1500";
            manager.SaveVariable("money", money);
            //초기 이름 선택
            if (string.IsNullOrEmpty(name))
            {
                do
                {
                    Console.WriteLine("원하시는 이름을 설정하세요.\n");
                    string name_Select = Console.ReadLine();
                    Console.WriteLine("입력하신 이름은 {0}입니다.\n", name_Select);

                    Console.WriteLine("1. 저장\n2. 최소");
                    int num_Name = int.Parse(Console.ReadLine());
                    if (num_Name == 1)
                    {
                        name = name_Select;
                        manager.SaveVariable("name", name);
                    }
                } while (string.IsNullOrEmpty(name));
            }
            Console.Clear();
        }

        public static void Start_Job()
        {
            //초기 직업 선택

            if (string.IsNullOrEmpty(job))
            {
                do
                {
                    Console.WriteLine("당신의 직업을 선택하세요\n");
                    Console.WriteLine("1. 수강생\n2. 튜터\n3. 담임매니저\n");

                    int job_num = int.Parse(Console.ReadLine());

                    list[job_num - 1].JobInformation();
                    Console.Clear();
                    Console.WriteLine("\n선택하신 직업은 {0}입니다.", list[job_num - 1].Name);
                    Console.WriteLine(list[job_num - 1].Info);
                    Console.WriteLine("지식   : {0}", list[job_num - 1].IQ);
                    Console.WriteLine("집중력 : {0}", list[job_num - 1].Focus);
                    Console.WriteLine("시간   : {0}", list[job_num - 1].Time);

                    Console.WriteLine("\n선택하신 직업을 저장하겠습니까?\n1. 저장\n2. 최소");
                    int job_Name = int.Parse(Console.ReadLine());
                    if (job_Name == 1)
                    {
                        job = (job_num - 1).ToString();
                        manager.SaveVariable("job", job);
                    }
                    manager.SaveVariable("1", lv);
                } while (string.IsNullOrEmpty(job));
            }
            Console.Clear();
        }

        public static void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n1. 상태 보기\n2. 인벤토리\n3. 상점\n4. 공부하기\n5. 휴식");
                Console.Write("\n원하시는 행동을 입력하세요.\n>>");

                int num_Select = int.Parse(Console.ReadLine());

                if (num_Select == 1)
                {
                    Console.Clear();
                    list[int.Parse(job)].JobInformation();
                    list[int.Parse(job)].Status();
                    break;
                }
                else if (num_Select == 2)
                {
                    Console.Clear();
                    Console.WriteLine("인벤토리");
                    Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n\n[아이템 목록]\n");
                    item_cnt = 0;
                    foreach (Item item in list_Inventory)
                    {
                        item.is_Have = true;
                        item.Item_Inform();
                        item.ItmeInventory();
                        item_cnt++;
                    }
                    while (true)
                    {
                        Console.WriteLine("\n\n1. 장착 관리\n2. 나가기\n");
                        Console.Write("\n원하시는 행동을 입력하세요.\n>>");
                        int item_Select = int.Parse(Console.ReadLine());
                        if (item_Select == 1)
                        {
                            Equip();
                            break;
                        }
                        else if (item_Select == 2)
                            break;
                    }
                }
                else if (num_Select == 3)
                {
                    Store();
                }
                else if (num_Select == 4)
                {
                    Study();
                }
                else if (num_Select == 5)
                {
                    Refresh();
                    break;
                }
            }
        }

        public static void Study()
        {
            Console.Clear();
            Console.WriteLine("던전입장");
            Console.WriteLine("이곳에서 오늘의 데일리 스크럼을 작성할 수 있습니다.\n");
            Console.WriteLine("1. 강의 듣기                 | 집중력 3 이상 권장");
            Console.WriteLine("2. 코딩 테스트 문제 풀기     | 집중력 5 이상 권장");
            Console.WriteLine("3. 프로젝트 진행하기         | 집중력 10 이상 권장");
            Console.WriteLine("0. 나가기");

            Console.Write("\n원하시는 행동을 입력해주세요.\n>>");
            int num = int.Parse(Console.ReadLine());

            if (num == 0)
                Menu();
            else if (num == 1)
                Study_Start(num, 3);
            else if (num == 2)
                Study_Start(num, 5);
            else if (num == 3)
                Study_Start(num, 10);
            else
                Study();
        }

        public static void Study_Start(int level, int focus)
        {
            int clear_Percnet = new Random().Next(1, 101);

            if (list[int.Parse(job)].Focus + add_Focus < focus)
            {
                if (clear_Percnet <= 40)
                {
                    int hp_num = int.Parse(hp);
                    hp_num /= 2;
                    hp = hp_num.ToString();

                    Console.Clear();
                    Console.WriteLine("오늘 할당치를 달성하지 못했습니다...\n");
                    Console.WriteLine("남은 시간이 {0}로 감소하였습니다.", hp);
                    Console.Write("\n아무키나 입력하세요 \n>>");
                    Console.ReadLine();
                }
                else
                {
                    Study_Clear(level);
                }
            }
            else
            {
                Study_Clear(level);
            }
        }

        public static void Study_Clear(int level)
        {
            int use_Time = new Random().Next(20, 36);

            Console.Clear();
            Console.WriteLine("던전 클리어");
            Console.WriteLine("축하합니다!!\n");
            if (level == 1)
                Console.WriteLine("강의 듣기를 완료했습니다!");
            else if (level == 2)
                Console.WriteLine("코딩 테스트를 완료했습니다!");
            else if (level == 3)
                Console.WriteLine("프로젝트를 완료했습니다!");

            Console.WriteLine("\n[탐험 결과]");

            Console.Write("시간 {0} -> ", hp);
            int hp_num = int.Parse(hp);
            hp_num -= use_Time;
            hp = hp_num.ToString();
            Console.WriteLine("{0}", hp);

            Console.Write("Gole {0} G -> ", money);
            int money_num = int.Parse(money);
            if (level == 1)
                money_num += 1000;
            else if (level == 2)
                money_num += 1700;
            else if (level == 3)
                money_num += 2500;
            money = money_num.ToString();
            Console.WriteLine("{0} G", money);


            Console.Write("\n아무키나 입력하세요 \n>>");
            Console.ReadLine();
        }

        public static void Refresh()
        {
            Console.Clear();
            Console.WriteLine("휴식하기");
            Console.WriteLine("500 G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : {0} G)\n", money);
            Console.WriteLine("1. 휴식하기");
            Console.WriteLine("0. 나가기");

            while (true)
            {

                Console.Write("\n원하시는 행동을 입력해주세요.\n>>");
                int num = int.Parse(Console.ReadLine());

                if (num == 0)
                {
                    break;
                }
                else if (num == 1)
                {
                    if (int.Parse(money) < 500)
                        Console.WriteLine("Gold 가 부족합니다.");
                    else
                    {
                        int money_num = int.Parse(money);
                        money_num -= 500;
                        money = money_num.ToString();
                        Console.WriteLine("휴식을 완료했습니다.");
                        hp = 100.ToString();
                    }
                }
            }
            Menu();
        }

        public static void Store()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("상점");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n\n[보유 골드]");
                Console.WriteLine(money + " G\n");
                Console.WriteLine("[아이템 목록]");

                foreach (Item item in list_Item)
                {
                    item.Item_Inform();
                    item.ItmeInventory_Store();
                }
                Console.WriteLine("\n1. 아이템 구매");
                Console.WriteLine("2. 아이템 판매");
                Console.WriteLine("0. 나가기");
                Console.Write("\n원하시는 행동을 입력해주세요.\n>>");
                int num = int.Parse(Console.ReadLine());

                if (num == 0)
                    break;
                else if (num == 1)
                {
                    Store_Manage();
                    break;
                }
                else if (num == 2)
                {
                    Sell();
                    break;
                }
            }
        }

        public static void Sell()
        {
            Console.Clear();
            Console.WriteLine("상점 - 아이템 구매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n\n[보유 골드]");
            Console.WriteLine(money + " G\n");
            Console.WriteLine("[아이템 목록]");

            item_cnt = 1;
            foreach (Item item in list_Inventory)
            {
                item.is_Have = true;
                item.Item_Inform();
                item.ItmeInventory();
                item_cnt++;
            }

            Console.WriteLine("\n0. 나가기");

            Console.Write("\n원하시는 행동을 입력하세요.\n>>");
            int num = int.Parse(Console.ReadLine());

            if (num == 0)
            {
                Menu();
            }
            else if (num > 0 && num <= item_cnt)
            {
                list_Inventory[num - 1].Item_Init();

                for (int i = list_Item.Count - 1; i >= 0; i--)
                {
                    if (list_Inventory[num - 1].num == list_Item[i].num)
                        list_Item[i].Item_Init();
                }

                int money_num = int.Parse(money);
                money_num += (int)(list_Inventory[num - 1].price * 0.85f);
                money = money_num.ToString();

                list_Inventory.RemoveAt(num - 1);

                Sell();
            }
            else
            {
                Console.WriteLine("잘못된입력입니다.");
            }
        }

        public static void Store_Manage()
        {

            Console.Clear();
            Console.WriteLine("상점 - 아이템 구매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n\n[보유 골드]");
            Console.WriteLine(money + " G\n");
            Console.WriteLine("[아이템 목록]");
            item_cnt = 1;
            foreach (Item item in list_Item)
            {
                item.ItemManage_Store();
            }
            Console.WriteLine("\n0. 나가기\n");


            //여기를 구매가능하도록 바꿔야됨
            while (true)
            {
                Console.Write("원하시는 행동을 입력하세요.\n>>");
                int num = int.Parse(Console.ReadLine());

                if (num == 0)
                {
                    break;
                }
                else if (num > 0 && num <= item_cnt)
                {
                    Buy(num - 1);
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다");
                }
            }
            Menu();
        }

        public static void Buy(int num)
        {
            if (list_Item[num].is_Buy == true)
            {
                Console.WriteLine("이미 구매한 아이템입니다");
            }
            else
            {
                if (list_Item[num].price > int.Parse(money))
                {
                    Console.WriteLine("Gold 가 부족합니다.");
                }
                else
                {
                    Console.WriteLine("구매를 완료했습니다.");
                    int money_num = int.Parse(money);
                    money_num -= list_Item[num].price;
                    money = money_num.ToString();
                    list_Item[num].ItemBuy();
                }
            }
            Store_Manage();
        }


        public static void Equip()
        {
            Console.Clear();
            Console.WriteLine("인벤토리 - 장착관리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n\n[아이템 목록]\n");
            equip_cnt = 1;
            foreach (Item item in list_Inventory)
            {
                item.ItemManage();
            }

            Console.WriteLine("\n0. 나가기\n");
            while (true)
            {
                Console.Write("원하시는 행동을 입력하세요.\n>>");
                int num = int.Parse(Console.ReadLine());

                if (num == 0)
                {
                    break;
                }
                else if (num > 0 && num <= item_cnt)
                {
                    if (list_Inventory[num - 1].type == "지식")
                    {
                        for (int i = list_Inventory.Count - 1; i >= 0; i--)
                        {
                            if (i != num - 1)
                                list_Inventory[i].ItemEquip_InitIQ();
                        }
                    }
                    else if (list_Inventory[num - 1].type == "집중력")
                    {
                        for (int i = list_Inventory.Count - 1; i >= 0; i--)
                        {
                            if (i != num - 1)
                                list_Inventory[i].ItemEquip_InitFocus();
                        }
                    }

                    list_Inventory[num - 1].ItemEquip();
                    Console.Clear();
                    Console.WriteLine("인벤토리 - 장착관리");
                    Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n\n[아이템 목록]\n");
                    equip_cnt = 1;
                    foreach (Item item in list_Inventory)
                    {
                        item.ItemManage();
                    }
                    Console.WriteLine("\n0. 나가기\n");
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다");
                }
            }
            Menu();
        }
    }
}
