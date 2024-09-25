using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Item
    {
        public int num { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        //타입
        public string type { get; set; }
        //수치
        public int value { get; set; }
        //보유 여부
        public bool is_Have { get; set; }
        //장착 여부
        public bool is_Equip { get; set; }
        //구매 여부
        public bool is_Buy { get; set; }
        //가격
        public int price { get; set; }

        public virtual void Item_Init()
        {
            is_Equip = false;
            is_Have = false;
            is_Buy = false;
        }

        public virtual void ItemBuy()
        {
            is_Buy = true;
            is_Have = true;
        }
        public virtual void Item_Inform()
        {
            Name = "";
            Info = "";
            type = "";
            value = 0;
        }

        public virtual void ItmeInventory()
        {
            if (is_Have == true)
            {
                if (is_Equip == true)
                    Console.WriteLine("- [E]{0}      | {1} +{2} | {3}", Name, type, value, Info);
                else
                    Console.WriteLine("- {0}      | {1} +{2} | {3}", Name, type, value, Info);
            }
        }

        public virtual void ItemManage()
        {
            if (is_Have == true)
            {
                if (is_Equip == true)
                    Console.WriteLine("- {0} [E]{1}      | {2} +{3} | {4}", Program.equip_cnt, Name, type, value, Info);
                else
                    Console.WriteLine("- {0} {1}      | {2} +{3} | {4}", Program.equip_cnt, Name, type, value, Info);

                Program.equip_cnt++;
            }
        }

        public virtual void ItmeInventory_Store()
        {
            if (is_Buy == false)
                Console.WriteLine("- {0}      | {1} +{2} | {3}\t| {4}", Name, type, value, Info, price);
            else
                Console.WriteLine("- {0}      | {1} +{2} | {3}\t| 구매완료", Name, type, value, Info);
        }

        public virtual void ItemManage_Store()
        {
            if (is_Buy == false)
                Console.WriteLine("- {0} {1}      | {2} +{3} | {4}\t| {5}", Program.item_cnt, Name, type, value, Info, price);
            else
                Console.WriteLine("- {0} {1}      | {2} +{3} | {4}\t| 구매완료", Program.item_cnt, Name, type, value, Info);
            Program.item_cnt++;
        }
        public virtual void ItemEquip_InitIQ()
        {
            if (is_Equip == true)
                Program.add_IQ -= 0;
            is_Equip = false;
        }

        public virtual void ItemEquip_InitFocus()
        {
            if (is_Equip == true)
                Program.add_IQ -= 0;
            is_Equip = false;
        }

        public virtual void ItemEquip()
        {
            is_Equip = !is_Equip;
        }
    }

    public class laptop : Item
    {

        public override void Item_Init()
        {
            is_Equip = false;
            is_Have = false;
            is_Buy = false;
        }

        public override void ItemBuy()
        {
            is_Buy = true;
            is_Have = true;
            Program.list_Inventory.Add(new laptop());
        }

        public override void Item_Inform()
        {
            num = 1;
            Name = "노트북";
            Info = "가지고 다니기 간편한 노트북입니다.";
            type = "지식";
            value = 3;
            price = 300;
        }

        public override void ItmeInventory()
        {
            if (is_Have == true)
            {
                if (is_Equip == true)
                    Console.WriteLine("- [E]{0}          | {1} + {2} | {3}", Name, type, value, Info);
                else
                    Console.WriteLine("- {0}          | {1} + {2} | {3}", Name, type, value, Info);
            }
        }

        public override void ItemManage()
        {
            if (is_Have == true)
            {
                if (is_Equip == true)
                    Console.WriteLine("- {0} [E]{1}          | {2} +{3} | {4}", Program.equip_cnt, Name, type, value, Info);
                else
                    Console.WriteLine("- {0} {1}          | {2} +{3} | {4}", Program.equip_cnt, Name, type, value, Info);

                Program.equip_cnt++;
            }
        }


        public override void ItmeInventory_Store()
        {
            if (is_Buy == false)
                Console.WriteLine("- {0}      | {1} +{2} | {3}\t| {4} G", Name, type, value, Info, price);
            else
                Console.WriteLine("- {0}      | {1} +{2} | {3}\t| 구매완료", Name, type, value, Info);
        }

        public override void ItemManage_Store()
        {
            if (is_Buy == false)
                Console.WriteLine("- {0} {1}      | {2} +{3} | {4}\t| {5} G", Program.item_cnt, Name, type, value, Info, price);
            else
                Console.WriteLine("- {0} {1}      | {2} +{3} | {4}\t| 구매완료", Program.item_cnt, Name, type, value, Info);
            Program.item_cnt++;
        }

        public override void ItemEquip_InitIQ()
        {
            if (is_Equip == true)
                Program.add_IQ -= 3;
            is_Equip = false;
        }

        public override void ItemEquip()
        {
            is_Equip = !is_Equip;
            if (is_Equip == true)
                Program.add_IQ += 3;
            else
                Program.add_IQ -= 3;
        }
    }

    public class Computer : Item
    {
        public override void Item_Init()
        {
            is_Equip = false;
            is_Have = false;
            is_Buy = false;
        }

        public override void ItemBuy()
        {
            is_Buy = true;
            is_Have = true;
            Program.list_Inventory.Add(new Computer());
        }
        public override void Item_Inform()
        {
            num = 2;
            Name = "컴퓨터";
            Info = "코더들의 영원한 친구 컴퓨터입니다.";
            type = "지식";
            value = 5;
            price = 500;
        }

        public override void ItmeInventory()
        {
            if (is_Have == true)
            {
                if (is_Equip == true)
                    Console.WriteLine("- [E]{0}          | {1} + {2} | {3}", Name, type, value, Info);
                else
                    Console.WriteLine("- {0}          | {1} + {2} | {3}", Name, type, value, Info);
            }
        }
        public override void ItemManage()
        {
            if (is_Have == true)
            {
                if (is_Equip == true)
                    Console.WriteLine("- {0} [E]{1}          | {2} +{3} | {4}", Program.equip_cnt, Name, type, value, Info);
                else
                    Console.WriteLine("- {0} {1}          | {2} +{3} | {4}", Program.equip_cnt, Name, type, value, Info);

                Program.equip_cnt++;
            }
        }
        public override void ItmeInventory_Store()
        {
            if (is_Buy == false)
                Console.WriteLine("- {0}      | {1} +{2} | {3}\t| {4} G", Name, type, value, Info, price);
            else
                Console.WriteLine("- {0}      | {1} +{2} | {3}\t| 구매완료", Name, type, value, Info);
        }

        public override void ItemManage_Store()
        {
            if (is_Buy == false)
                Console.WriteLine("- {0} {1}      | {2} +{3} | {4}\t| {5} G", Program.item_cnt, Name, type, value, Info, price);
            else
                Console.WriteLine("- {0} {1}      | {2} +{3} | {4}\t| 구매완료", Program.item_cnt, Name, type, value, Info);
            Program.item_cnt++;
        }

        public override void ItemEquip_InitIQ()
        {
            if (is_Equip == true)
                Program.add_IQ -= 5;
            is_Equip = false;
        }

        public override void ItemEquip()
        {
            is_Equip = !is_Equip;
            if (is_Equip == true)
                Program.add_IQ += 5;
            else
                Program.add_IQ -= 5;
        }
    }

    public class SuperComputer : Item
    {
        public override void Item_Init()
        {
            is_Equip = false;
            is_Have = false;
            is_Buy = false;
        }

        public override void ItemBuy()
        {
            is_Buy = true;
            is_Have = true;
            Program.list_Inventory.Add(new SuperComputer());
        }

        public override void Item_Inform()
        {
            num = 3;
            Name = "슈퍼컴퓨터";
            Info = "챗GPT가 탑재된 최첨단 컴퓨터입니다.";
            type = "지식";
            value = 10;
            price = 1000;
        }

        public override void ItmeInventory()
        {
            if (is_Have == true)
            {
                if (is_Equip == true)
                    Console.WriteLine("- [E]{0}      | {1} +{2} | {3}", Name, type, value, Info);
                else
                    Console.WriteLine("- {0}      | {1} +{2} | {3}", Name, type, value, Info);
            }
        }

        public override void ItemManage()
        {
            if (is_Have == true)
            {
                if (is_Equip == true)
                    Console.WriteLine("- {0} [E]{1}      | {2} +{3} | {4} G", Program.equip_cnt, Name, type, value, Info);
                else
                    Console.WriteLine("- {0} {1}      | {2} +{3} | {4}", Program.equip_cnt, Name, type, value, Info);

                Program.equip_cnt++;
            }
        }
        public override void ItmeInventory_Store()
        {
            if (is_Buy == false)
                Console.WriteLine("- {0}      | {1} +{2} | {3}\t| {4} G", Name, type, value, Info, price);
            else
                Console.WriteLine("- {0}      | {1} +{2} | {3}\t| 구매완료", Name, type, value, Info);
        }

        public override void ItemManage_Store()
        {
            if (is_Buy == false)
                Console.WriteLine("- {0} {1}      | {2} +{3} | {4}\t| {5}", Program.item_cnt, Name, type, value, Info, price);
            else
                Console.WriteLine("- {0} {1}      | {2} +{3} | {4}\t| 구매완료", Program.item_cnt, Name, type, value, Info);
            Program.item_cnt++;
        }

        public override void ItemEquip_InitIQ()
        {
            if (is_Equip == true)
                Program.add_IQ -= 10;
            is_Equip = false;
        }
        public override void ItemEquip()
        {
            is_Equip = !is_Equip;
            if (is_Equip == true)
                Program.add_IQ += 10;
            else
                Program.add_IQ -= 10;
        }
    }

    public class Pencil : Item
    {

        public override void Item_Init()
        {
            is_Equip = false;
            is_Have = false;
            is_Buy = false;
        }

        public override void ItemBuy()
        {
            is_Buy = true;
            is_Have = true;
            Program.list_Inventory.Add(new Pencil());
        }

        public override void Item_Inform()
        {
            num = 4;
            Name = "연필";
            Info = "가장 기본적인 필기도구입니다.";
            type = "집중력";
            value = 3;
            price = 300;
        }

        public override void ItmeInventory()
        {
            if (is_Have == true)
            {
                if (is_Equip == true)
                    Console.WriteLine("- [E]{0}          | {1} + {2} | {3}", Name, type, value, Info);
                else
                    Console.WriteLine("- {0}          | {1} + {2} | {3}", Name, type, value, Info);
            }
        }

        public override void ItemManage()
        {
            if (is_Have == true)
            {
                if (is_Equip == true)
                    Console.WriteLine("- {0} [E]{1}          | {2} +{3} | {4}", Program.equip_cnt, Name, type, value, Info);
                else
                    Console.WriteLine("- {0} {1}          | {2} +{3} | {4}", Program.equip_cnt, Name, type, value, Info);

                Program.equip_cnt++;
            }
        }


        public override void ItmeInventory_Store()
        {
            if (is_Buy == false)
                Console.WriteLine("- {0}      | {1} +{2} | {3}\t| {4} G", Name, type, value, Info, price);
            else
                Console.WriteLine("- {0}      | {1} +{2} | {3}\t| 구매완료", Name, type, value, Info);
        }

        public override void ItemManage_Store()
        {
            if (is_Buy == false)
                Console.WriteLine("- {0} {1}      | {2} +{3} | {4}\t| {5} G", Program.item_cnt, Name, type, value, Info, price);
            else
                Console.WriteLine("- {0} {1}      | {2} +{3} | {4}\t| 구매완료", Program.item_cnt, Name, type, value, Info);
            Program.item_cnt++;
        }


        public override void ItemEquip_InitFocus()
        {
            if (is_Equip == true)
                Program.add_Focus -= 3;
            is_Equip = false;
        }

        public override void ItemEquip()
        {
            is_Equip = !is_Equip;
            if (is_Equip == true)
                Program.add_Focus += 3;
            else
                Program.add_Focus -= 3;
        }
    }

    public class Pen : Item
    {

        public override void Item_Init()
        {
            is_Equip = false;
            is_Have = false;
            is_Buy = false;
        }

        public override void ItemBuy()
        {
            is_Buy = true;
            is_Have = true;
            Program.list_Inventory.Add(new Pen());
        }

        public override void Item_Inform()
        {
            num = 5;
            Name = "볼펜";
            Info = "좀 더 지속성있는 필기입니다.";
            type = "집중력";
            value = 5;
            price = 500;
        }

        public override void ItmeInventory()
        {
            if (is_Have == true)
            {
                if (is_Equip == true)
                    Console.WriteLine("- [E]{0}          | {1} + {2} | {3}", Name, type, value, Info);
                else
                    Console.WriteLine("- {0}          | {1} + {2} | {3}", Name, type, value, Info);
            }
        }

        public override void ItemManage()
        {
            if (is_Have == true)
            {
                if (is_Equip == true)
                    Console.WriteLine("- {0} [E]{1}          | {2} +{3} | {4}", Program.equip_cnt, Name, type, value, Info);
                else
                    Console.WriteLine("- {0} {1}          | {2} +{3} | {4}", Program.equip_cnt, Name, type, value, Info);

                Program.equip_cnt++;
            }
        }


        public override void ItmeInventory_Store()
        {
            if (is_Buy == false)
                Console.WriteLine("- {0}      | {1} +{2} | {3}\t| {4} G", Name, type, value, Info, price);
            else
                Console.WriteLine("- {0}      | {1} +{2} | {3}\t| 구매완료", Name, type, value, Info);
        }

        public override void ItemManage_Store()
        {
            if (is_Buy == false)
                Console.WriteLine("- {0} {1}      | {2} +{3} | {4}\t| {5} G", Program.item_cnt, Name, type, value, Info, price);
            else
                Console.WriteLine("- {0} {1}      | {2} +{3} | {4}\t| 구매완료", Program.item_cnt, Name, type, value, Info);
            Program.item_cnt++;
        }


        public override void ItemEquip_InitFocus()
        {
            if (is_Equip == true)
                Program.add_Focus -= 5;
            is_Equip = false;
        }

        public override void ItemEquip()
        {
            is_Equip = !is_Equip;
            if (is_Equip == true)
                Program.add_Focus += 5;
            else
                Program.add_Focus -= 5;
        }
    }

    public class FountainPen : Item
    {

        public override void Item_Init()
        {
            is_Equip = false;
            is_Have = false;
            is_Buy = false;
        }

        public override void ItemBuy()
        {
            is_Buy = true;
            is_Have = true;
            Program.list_Inventory.Add(new laptop());
        }

        public override void Item_Inform()
        {
            num = 6;
            Name = "만년필";
            Info = "가장 고가이자 간지나는 필기도구입니다.";
            type = "집중력";
            value = 10;
            price = 1000;
        }

        public override void ItmeInventory()
        {
            if (is_Have == true)
            {
                if (is_Equip == true)
                    Console.WriteLine("- [E]{0}          | {1} + {2} | {3}", Name, type, value, Info);
                else
                    Console.WriteLine("- {0}          | {1} + {2} | {3}", Name, type, value, Info);
            }
        }

        public override void ItemManage()
        {
            if (is_Have == true)
            {
                if (is_Equip == true)
                    Console.WriteLine("- {0} [E]{1}          | {2} +{3} | {4}", Program.equip_cnt, Name, type, value, Info);
                else
                    Console.WriteLine("- {0} {1}          | {2} +{3} | {4}", Program.equip_cnt, Name, type, value, Info);

                Program.equip_cnt++;
            }
        }


        public override void ItmeInventory_Store()
        {
            if (is_Buy == false)
                Console.WriteLine("- {0}      | {1} +{2} | {3}\t| {4} G", Name, type, value, Info, price);
            else
                Console.WriteLine("- {0}      | {1} +{2} | {3}\t| 구매완료", Name, type, value, Info);
        }

        public override void ItemManage_Store()
        {
            if (is_Buy == false)
                Console.WriteLine("- {0} {1}      | {2} +{3} | {4}\t| {5} G", Program.item_cnt, Name, type, value, Info, price);
            else
                Console.WriteLine("- {0} {1}      | {2} +{3} | {4}\t| 구매완료", Program.item_cnt, Name, type, value, Info);
            Program.item_cnt++;
        }


        public override void ItemEquip_InitFocus()
        {
            if (is_Equip == true)
                Program.add_Focus -= 10;
            is_Equip = false;
        }

        public override void ItemEquip()
        {
            is_Equip = !is_Equip;
            if (is_Equip == true)
                Program.add_Focus += 10;
            else
                Program.add_Focus -= 10;
        }
    }
}