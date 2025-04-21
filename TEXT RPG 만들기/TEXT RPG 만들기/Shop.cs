using Enums;
using Player;
using Skill;
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
        public void AddNewItem(ITEM_TYPE ItemKind, string name, string description, string abilityValue, int price)
        {
            CIteminfo newItem = new CIteminfo(ItemKind, description, abilityValue, price);
            itemList.Add(newItem);
        }
        public void ItemSetUp()
        {
            AddNewItem(ITEM_TYPE.ARMOR, "가죽 갑옷", "가죽으로 만든 갑옷","10",500);
            AddNewItem(ITEM_TYPE.ARMOR, "철 갑옷", "철로 만든 갑옷", "20", 1500);
            AddNewItem(ITEM_TYPE.ARMOR, "망자의 갑옷", "망자의 영혼으로 만든 갑옷", "40", 8000);
            AddNewItem(ITEM_TYPE.ARMOR, "용 갑옷", "용의 비늘로 만든 갑옷", "80", 10000);
            AddNewItem(ITEM_TYPE.WEAPON, "나무 검", "나무로 만든 검", "10", 500);
            AddNewItem(ITEM_TYPE.WEAPON, "철 검", "철로 만든 검", "20", 1500);
            AddNewItem(ITEM_TYPE.WEAPON, "망자의 검", "망자의 영혼으로 만든 검", "40", 8000);
            AddNewItem(ITEM_TYPE.WEAPON, "용살자의 검", "용을 죽인 자의 검", "80", 10000);
            AddNewItem(ITEM_TYPE.POTION, "소형 HP포션", "작은 HP포션", "30", 500);
            AddNewItem(ITEM_TYPE.POTION, "소형 MP포션", "작은 MP포션", "30", 500);
            AddNewItem(ITEM_TYPE.POTION, "대형 HP포션", "큰 HP포션", "70", 1000);
            AddNewItem(ITEM_TYPE.POTION, "대형 MP포션", "큰 MP포션", "70", 1000);

        }



    }

}
