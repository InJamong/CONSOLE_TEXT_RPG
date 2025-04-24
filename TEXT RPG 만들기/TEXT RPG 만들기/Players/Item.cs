using Enums;
using Item;

namespace Item
{
    public class CIteminfo
    {
        public ITEM_TYPE ItemKind { get; set; } //enum에 있는 아이템 종류 저장.
        public string Name {  get; set; }
        public string Description { get; set; }  // 아이템 설명
        public string AbilityValue { get; set; }  // 아이템 능력치
        public int Price {  get; set; }
        public int Count { get; set; } = 1;
       

   

    public CIteminfo(ITEM_TYPE itemKind,string name, string description, string abilityvalue, int price)
        {
           this.ItemKind = itemKind;
            this.Description = description;
            this.AbilityValue = abilityvalue;
            this.Price = price;
            this.Name = name;
            Count = 1;
            
        }

    }
}
