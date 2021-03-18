namespace csharpcore.Items
{
    public static class ItemFactory
    {
        public static BaseItem GetItemClass(Item rawItem)
        {
            if(rawItem.Name == ItemsNames.Sulfuras)
                return new Sulfuras(rawItem);
            
            if(rawItem.Name == ItemsNames.AgedBrie)
                return new AgedBrie(rawItem);

            if(rawItem.Name == ItemsNames.BackstagePasses)
                return new BackstagePasses(rawItem);

            return new BaseItem(rawItem);
        }
    }
}