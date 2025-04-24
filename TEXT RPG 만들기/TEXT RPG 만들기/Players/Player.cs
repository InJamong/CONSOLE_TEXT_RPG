using Item;
using Job;
using Enums;
using Inventory;

namespace Player
{
    public class CPlayer
    {
        public string Name { get; set; }
        public int MaxHp { get; set; }

        public int Hp {  get; set; }
        public int MaxMp {  get; set; }

        public int Mp { get; set; }
        public int Atk { get; set; }
        public int Def {  get; set; }
        public int Gold { get; set; }
        public CJob Job { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public CInventory Inventory { get; set; }
        public CIteminfo EquippedWeapon { get; private set; }
        public CIteminfo EquippedArmor { get; private set; }

        private int defaultHp;
        private int defaultMp;
       
        

        public CPlayer(string name,int gold, CJob job,int x,int y)
        {
            Inventory = new CInventory();
            
            this.Name = name;
            this.Job = job;
            this.Gold = gold;
            this.X = 3;
            this.Y = 5;
            MaxHp = job.BaseHp;  // 초기값은 여전히 직업의 BaseHp로 설정
            MaxMp = job.BaseMp;  // 마찬가지로 초기값 설정
            Atk = job.BaseAtk;  // 초기값 설정
            Def = job.BaseDef;  // 초기값 설정
            
            Hp=MaxHp;
            Mp = MaxMp;
        }
        public void SaveDefaultStatus()
        {
            defaultHp = MaxHp;
            defaultMp = MaxMp;
            Hp = MaxHp;     // 전투 시작 전에는 체력과 마나를 최대로 회복
            Mp = MaxMp;
        }
        public void PlayerDefaultStatus()
        {
            MaxHp = defaultHp;
            MaxMp = defaultMp;
            Hp = MaxHp;
            Mp = MaxMp;
        }
        public void Equip(CIteminfo item, CPlayer player)
        {
            switch (item.ItemKind)
            {
                case ITEM_TYPE.ARMOR:
                    if (EquippedArmor != null)
                    {
                        Def -= int.Parse(EquippedArmor.AbilityValue);
                        Console.WriteLine($"{EquippedArmor.Name}을(를) 해제했습니다");
                        Console.WriteLine($"{EquippedArmor.Name}을(를) 판매했습니다");
                        player.Gold += EquippedArmor.Price / 2;
                        
                    }
                    
                    EquippedArmor = item;
                    Def += int.Parse(item.AbilityValue);
                    Console.WriteLine($"{item.Name} 장착! 방어력 {item.AbilityValue}만큼 증가");

                    Console.WriteLine($"현재 장착 방어구: {EquippedArmor.Name}, 능력치: {EquippedArmor.AbilityValue}");
                    break;

                        
                    

                case ITEM_TYPE.WEAPON:
                    if (EquippedWeapon != null)
                    {
                        Atk -= int.Parse(EquippedWeapon.AbilityValue);
                        Console.WriteLine($"{EquippedWeapon.Name}을(를) 해제했습니다");
                        Console.WriteLine($"{EquippedWeapon.Name}을(를) 판매했습니다");
                        player.Gold += EquippedWeapon.Price / 2;
               
                    }
                    
                     EquippedWeapon = item;
                     Atk += int.Parse(item.AbilityValue);
                     Console.WriteLine($"{item.Name} 장착! 공격력 {item.AbilityValue}만큼 증가");
                     Console.WriteLine($"현재 장착 무기: {EquippedWeapon.Name}, 능력치: {EquippedWeapon.AbilityValue}");
                     break;
               

            }
        }
    }
}
