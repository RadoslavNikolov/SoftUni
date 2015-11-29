namespace TheSlum.Factory
{
    using System;
    using Items;

    public class ItemFactory
    {
        public Item CreateItem(ItemType itemType, string id)
        {
            switch (itemType)
            {
                    case ItemType.Axe: return new Axe(id);
                    case ItemType.Shield: return new Shield(id);
                    case ItemType.Injection: return new Injection(id);
                    case ItemType.Pill: return new Pill(id);
                default:
                    throw new NotSupportedException("Item of this type does not esist");
            }
        }
    }
}