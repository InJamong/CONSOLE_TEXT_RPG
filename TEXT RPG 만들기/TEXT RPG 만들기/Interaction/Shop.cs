using Enums;
using Player;
using Skill;
using Inventory;
using Item;
namespace Shop
    
{
    public class CShop
    {
        private List<CIteminfo> itemList;
       

        public CShop()
        {
            itemList = new List<CIteminfo>();
            ItemSetUp();

        }
        public void ItemSetUp()
        {
            AddNewItem(ITEM_TYPE.ARMOR, "가죽 갑옷", "가죽으로 만든 갑옷", "10", 500);
            AddNewItem(ITEM_TYPE.ARMOR, "철 갑옷", "철로 만든 갑옷", "20", 5000);
            AddNewItem(ITEM_TYPE.ARMOR, "망자의 갑옷", "망자의 영혼으로 만든 갑옷", "40", 8000);
            AddNewItem(ITEM_TYPE.ARMOR, "용 갑옷", "용의 비늘로 만든 갑옷", "100", 20000);
            AddNewItem(ITEM_TYPE.WEAPON, "나무 검", "나무로 만든 검", "10", 500);
            AddNewItem(ITEM_TYPE.WEAPON, "철 검", "철로 만든 검", "20", 5000);
            AddNewItem(ITEM_TYPE.WEAPON, "망자의 검", "망자의 영혼으로 만든 검", "40", 8000);
            AddNewItem(ITEM_TYPE.WEAPON, "용살자의 검", "용을 죽인 자의 검", "100", 20000);
            AddNewItem(ITEM_TYPE.POTION, "소형 HP포션", "HP를 소량 회복한다", "30", 500);
            AddNewItem(ITEM_TYPE.POTION, "소형 MP포션", "MP를 소량 회복한다", "30", 500);
            AddNewItem(ITEM_TYPE.POTION, "대형 HP포션", "HP를 대량 회복한다", "70", 1000);
            AddNewItem(ITEM_TYPE.POTION, "대형 MP포션", "MP를 대량 회복한다", "70", 1000);
            AddNewItem(ITEM_TYPE.STATUPGRADE, "HP 증가", "최대 HP를 증가시킨다.", "10", 3000);
            AddNewItem(ITEM_TYPE.STATUPGRADE, "MP 증가", "최대 MP를 증가시킨다", "10", 3000);
            AddNewItem(ITEM_TYPE.STATUPGRADE, "공격력 증가", "공격력을 증가시킨다", "10", 5000);
            AddNewItem(ITEM_TYPE.STATUPGRADE, "방어력 증가", "방어력을 증가시킨다", "10", 5000);

        }


        private void AddNewItem(ITEM_TYPE ItemKind, string name, string description, string abilityValue, int price)
        { 
            itemList.Add(new CIteminfo(ItemKind, name, description, abilityValue, price));
        }

        bool ShopLoop = true;
        public void ShowShopMenu(CPlayer player)
        {
            //while (ShopLoop)
            {
                Console.Clear();
                Console.WriteLine("상점에 오신 걸 환영합니다.");
                Console.WriteLine("1. 방어구");
                Console.WriteLine("2. 무기");
                Console.WriteLine("3. 물약");
                Console.WriteLine("4. 능력치 강화");
                Console.WriteLine("0. 나가기");
                Console.WriteLine("원하시는 걸 선택해주세요.");


                int ChoiceMenu = int.Parse(Console.ReadLine());

                    switch ((SHOP_MENU)ChoiceMenu)
                    {
                        case SHOP_MENU.ARMOR:
                            {

                                ShowItemType(ITEM_TYPE.ARMOR, player); //방어구 상점
                                break;
                            }

                        case SHOP_MENU.WEAPON:
                            {
                                ShowItemType(ITEM_TYPE.WEAPON, player); // 무기 상점
                                break;
                            }
                        case SHOP_MENU.POTION:
                            {
                                ShowItemType(ITEM_TYPE.POTION, player); // 물약 상점
                                break;
                            }
                        case SHOP_MENU.STATUPGRADE:
                            {
                                ShowItemType(ITEM_TYPE.STATUPGRADE, player); // 능력치 업글
                                break;
                            }
                    case SHOP_MENU.EXIT:
                        {
                            Console.WriteLine("상점을 종료합니다.");
                            Thread.Sleep(1000);
                            Console.Clear();
                            ShopLoop = false;
                            break;
                        }
                    default:
                            {
                                Console.WriteLine("잘못된 선택입니다. 다시 선택하세요.");
                                Thread.Sleep(1000);
                                break;
                            }
                    }
            }
            
        }


        private void ShowItemType(ITEM_TYPE type, CPlayer player)
        {
            Console.Clear();
            Console.WriteLine($"===[{type} 상점]===");

            List<CIteminfo> filteredItems = new List<CIteminfo>();
            int index = 1;


            foreach (CIteminfo item in itemList)
            {
                if (item.ItemKind == type)
                {
                    filteredItems.Add(item);
                    Console.WriteLine($"{index}. 아이템 이름: {item.Name}");
                    Console.WriteLine($"   설명: {item.Description}");
                    Console.WriteLine($"   능력치: {item.AbilityValue} 증가");
                    Console.WriteLine($"   가격: {item.Price} 골드\n");
                    index++;
                }
            }

            if (filteredItems.Count == 0)
            {
                Console.WriteLine("해당 분류에 아이템이 없습니다.");
                Console.WriteLine("아무 키나 누르면 상점으로 돌아갑니다...");
                Console.ReadKey();
                return;
            }
            Console.WriteLine($"소지 골드: {player.Gold}");
            Console.WriteLine("구매할 아이템 번호를 입력하세요 (0: 뒤로가기):");

            int input;
            if (int.TryParse(Console.ReadLine(), out input))
            {
                if (input == 0)
                    ShowShopMenu(player);

                if (input >= 1 && input <= filteredItems.Count)
                {
                    // 구매 처리
                    BuyItem(player, type, input);

                }
                else 
                {
                    Console.WriteLine("잘못된 번호입니다.");
                    Console.Clear();
                }
            }
            else
            {
                Console.WriteLine("숫자만 입력해주세요.");
                Console.Clear();
            }

                     
        }
        #region 잠깐 냅둬보자
        /*private void ShowItemType(ITEM_TYPE type) // 아이템 보여주는 메서드.
        {
            Console.Clear();
            Console.WriteLine($"===[{type}]===");

            int index = 1;
            foreach (CIteminfo item in itemList)
            {
                if (item.ItemKind == type)
                {
                    Console.WriteLine($"{index}.아이템 이름: {item.Name}");
                    Console.WriteLine($"설명: {item.Description}");
                    Console.WriteLine($"능력치: {item.AbilityValue}증가");
                    Console.WriteLine($"가격: {item.Price}골드\n");
                    index++;
                }
            }

        }*/
        #endregion

        public void BuyItem(CPlayer player, ITEM_TYPE itemkind,int num) //아이템 구매 메서드.
        {
            int itemCount = 1;

            foreach (var item in itemList)
            {
                if (item.ItemKind == itemkind)
                {
                    if (itemCount == num)
                    {
                        if (player.Gold >= item.Price)
                        {
                            player.Gold -= item.Price;

                           if (item.ItemKind == ITEM_TYPE.STATUPGRADE)
                            {
                                UpgradeStat(player, item);
                                
                            }
                            else
                            {
                                player.Inventory.Add(item);
                                Thread.Sleep(1000);
                                ShowShopMenu(player);
                            }

                            return;
                        }
                        else
                        {
                            Console.WriteLine("골드가 부족합니다.");
                            Thread.Sleep(500);
                            ShowShopMenu(player);
                        }
                    }
                    itemCount++;
                }       
            }            
        }
        //이걸 딕셔너리로 처리해서 가져오는게 나을지도...?
        private void UpgradeStat(CPlayer player, CIteminfo item) //상점에서 업그레이드 아이템 샀을때 스텟에 적용.
        {
            
            
                if (item.Name.Contains("HP 증가"))//Contains => 문자열(string)안에 특정 문자열이 포함되는지 확인해서 참/거짓을 반환.
                {
                    player.MaxHp += int.Parse(item.AbilityValue);
                    Console.WriteLine("최대 HP가 증가했습니다");
                    Thread.Sleep(1000);
                    ShowShopMenu(player);


            }
            else if (item.Name.Contains("MP 증가"))
                {
                    player.MaxMp += int.Parse(item.AbilityValue);
                    Console.WriteLine("최대 MP가 증가했습니다");
                    Thread.Sleep(1000);
                    ShowShopMenu(player);
                    Console.Clear();

                }
                else if (item.Name.Contains("공격력 증가"))
                {
                    player.Atk += int.Parse(item.AbilityValue);
                    Console.WriteLine("공격력이 증가했습니다");
                    Thread.Sleep(1000);
                    ShowShopMenu(player);
                    Console.Clear();

            }
                else if (item.Name.Contains("방어력 증가"))
                {
                    player.Def += int.Parse(item.AbilityValue);
                    Console.WriteLine("방어력이 증가했습니다");
                    Thread.Sleep(1000);
                    ShowShopMenu(player);
                    Console.Clear();
            }
            


        }


    }
}
