using Enums;
using Item;

namespace Item
{
    public class CIteminfo
    {
        public ITEM_TYPE ItemKind { get; set; }
        public string Description { get; set; }  // 아이템 설명
        public string AbilityValue { get; set; }  // 아이템 능력치
        public int Price {  get; set; }

   

    public CIteminfo(ITEM_TYPE itemKind, string description, string abilityvalue, int price)
        {
           this.ItemKind = itemKind;
            this.Description = description;
            this.AbilityValue = abilityvalue;
            this.Price = price;
        }

    }
}
