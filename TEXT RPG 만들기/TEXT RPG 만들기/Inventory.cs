using Item;
using Shop;
using Player;
using Enums;
using System;
using System.Runtime.CompilerServices;
using System.Numerics;

namespace Inventory
{
    public class CInventory
    {
        public List<CIteminfo> Items; //소지 아이템 목록 리스트

        public CInventory()
        {
            Items = new List<CIteminfo>(); //인벤토리 초기화
        }
        public void Add(CIteminfo item) //인벤토리에 추가하는 메서드
        {
            Items.Add(item);
            Console.WriteLine($"{item.Name} 1개가 인벤토리에 추가되었습니다.");
        }
        public void ShowInventory() //인벤토리 보여주는 메서드.
        {
            Console.WriteLine($"현재 인벤토리 아이템 수: {Items.Count}");

            Dictionary<string, (CIteminfo item, int count)> itemCount = new Dictionary<string, (CIteminfo item, int count)>();

            foreach (var item in Items)
            {
                if (itemCount.ContainsKey(item.Name)) // 이미 존재하면 개수 증가.
                {
                    itemCount[item.Name] = (itemCount[item.Name].item, itemCount[item.Name].count + 1);
                }
                else
                {
                    itemCount.Add(item.Name, (item, 1));
                }
            }
            Console.WriteLine("===인벤토리===");
            int index = 1;
            foreach (var item in itemCount)
            {
                var itemInfo = item.Value.item;
                var count = item.Value.count;
                Console.WriteLine($"{index}.{item.Key} - 능력치: {itemInfo.AbilityValue} - {count}개");
                index++;
            }

        }
        public void EquipItem( CPlayer player)
        {
            Console.Clear();
            ShowInventory();
            Console.WriteLine("장착할 아이템의 번호를 입력하세요.:");
            Console.WriteLine("장착 중인 아이템이 있을 경우 판매 후 새로 장착합니다");
            int itemNumber;
            if (int.TryParse(Console.ReadLine(), out itemNumber))
            {
                if (itemNumber >= 1 && itemNumber <= Items.Count) // 입력 받은 번호가 유효한지 체크
                {
                    var item = Items[itemNumber - 1]; // 번호에 맞는 아이템 찾기
                    if (item.ItemKind == ITEM_TYPE.POTION)
                    {
                        Console.WriteLine($"{item.Name}은 장작할 수 없습니다!");
                        Thread.Sleep(1000);

                    }
                    else
                    {
                        player.Equip(item,player);
                        Console.WriteLine($"{item.Name}을(를) 장착했습니다.");
                        Items.Remove(item); // 장착 후 인벤토리에서 아이템 제거
                        Thread.Sleep(1000);

                    }

                }
                else
                {
                    Console.WriteLine("잘못된 선택하셨습니다. 다시 시도하세요.");
                }
            }
            else
            {
                Console.WriteLine("잘못 선택하셨습니다. 번호를 다시 입력해주세요.");
            }
        }

        public void SellItem(CPlayer player)
        {
            Console.Clear();
            ShowInventory(); // 아이템 목록을 번호와 함께 출력
            Console.WriteLine("판매할 아이템의 번호를 입력하세요.");

            int selectedIndex;
            if (int.TryParse(Console.ReadLine(), out selectedIndex) && selectedIndex > 0 && selectedIndex <= Items.Count)
            {
                var item = Items[selectedIndex - 1]; // 선택된 번호에 해당하는 아이템 (인덱스는 0부터 시작하므로 -1)

                player.Gold += item.Price / 2; // 판매 시 반값
                Items.Remove(item); // 아이템 제거
                Console.WriteLine($"{item.Name}을(를) 판매했습니다. {item.Price / 2}골드를 획득했습니다.");
                Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine("잘못 선택하셨습니다. 다시 시도해주세요.");
                Thread.Sleep(1000);

            }
        }
        public void ShowPotion() // 포션만 따로 모아놓은 목록.
        {
            Console.WriteLine("======포션 목록======");
            int index = 1;
            foreach (var item in Items)
            {
                if (item.ItemKind == ITEM_TYPE.POTION)
                {
                    Console.WriteLine($"{index}. {item.Name} - 회복량: {item.AbilityValue}");

                }
                index++;
            }
        }
        public void UsingPotion(CPlayer player)
        {
            Console.Clear();
            ShowPotion();

            Console.WriteLine("사용할 포션 번호를 입력하세요");
            if (int.TryParse(Console.ReadLine(), out int selectPotionNum))
            {
                var selectPotion = Items.Where(item => item.ItemKind == ITEM_TYPE.POTION).ElementAtOrDefault(selectPotionNum - 1);
                //Items.Where(item => item.ItemKind == ITEM_TYPE.POTION) -> 리스트내에서 포션타입만 필터링.
                //ElementAtOrDefault(selectPotionNum - 1); -> 필터링한 내용중에서 선택한 번호에 맞는 리스트를 가져옴.
                int healAmount = int.Parse(selectPotion.AbilityValue);
                int TotalHp = player.Hp + healAmount;
                int TotalMp = player.Mp + healAmount;
                if (selectPotion != null)
                {
                    if (selectPotion.Name.Contains("HP"))
                    {
                        if (player.Hp == player.MaxHp)
                        {
                            Console.WriteLine("최대체력이므로 포션을 사용할 수 없습니다.");
                            Thread.Sleep(1000);
                        }
                        else if (TotalHp > player.MaxHp)
                        {
                            player.Hp = Math.Min(TotalHp, player.MaxHp);
                            Console.WriteLine($"{selectPotion.Name}을 사용해 {TotalHp - player.MaxHp}만큼 회복했습니다");
                            Items.Remove(selectPotion);
                            Thread.Sleep(1000);

                        }
                        else if (TotalHp <= player.MaxHp)
                        {
                            player.Hp = Math.Min(TotalHp, player.MaxHp);
                            Console.WriteLine($"{selectPotion.Name}을 사용해 {selectPotion.AbilityValue}만큼 회복햇습니다");
                            Items.Remove(selectPotion);
                            Thread.Sleep(1000);

                        }
                    }

                    if (selectPotion.Name.Contains("MP"))
                    {
                        if (player.Mp == player.MaxMp)
                        {
                            Console.WriteLine("최대마나이므로 포션을 사용할 수 없습니다.");
                            Thread.Sleep(1000);
                        }
                        else if (TotalMp > player.MaxMp)
                        {
                            player.Mp = Math.Min(TotalMp, player.MaxMp);
                            Console.WriteLine($"{selectPotion.Name}을 사용해 {TotalHp - player.MaxMp}만큼 회복했습니다");
                            Items.Remove(selectPotion);
                            Thread.Sleep(1000);

                        }
                        else if (TotalHp <= player.MaxMp)
                        {
                            player.Mp = Math.Min(TotalMp, player.MaxMp);
                            Console.WriteLine($"{selectPotion.Name}을 사용해 {selectPotion.AbilityValue}만큼 회복햇습니다");
                            Items.Remove(selectPotion);
                            Thread.Sleep(1000);
                        }
                    }

                }


            }
        }
        public void InventoryMenu(CPlayer player)
        {
            bool invenMenuLoop = true;
            while (invenMenuLoop)
            {
                Console.Clear();
                Console.WriteLine("=====인벤토리 메뉴=====");
                Console.WriteLine("Q: 인벤토리 열기");
                Console.WriteLine("W: 아이템 판매");
                Console.WriteLine("E: 아이템 장착");
                Console.WriteLine("0: 나가기");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.Q: //인벤토리 내용보여주기
                        ShowInventory();
                        Console.WriteLine("아무키나 눌러주세요");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.W: // 인벤토리 아이템 판매
                        SellItem(player);
                        Console.WriteLine("아무키나 눌러주세요");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.E: // 인벤토리 아이템 장착
                        EquipItem(player);
                        Console.WriteLine("아무키나 눌러주세요");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D0:
                        Console.WriteLine("인벤토리 나가는중");
                        Console.WriteLine("아무키나 눌러주세요");
                        Console.ReadKey();
                        invenMenuLoop = false;
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다");
                        break;
                }
            }
        }
    }
}
/*else
{
    int recoveryAmount = int.Parse(potion.AbilityValue);
    player.Hp = Math.Min(player.MaxHp, player.Hp + recoveryAmount);
    if (player.Hp+recoveryAmount > player.MaxHp
 
}*/
