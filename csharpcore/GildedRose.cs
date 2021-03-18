using System;
using System.Collections.Generic;
using csharpcore.Items;

namespace csharpcore
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var rawItem in Items)
            {
                var item = ItemFactory.GetItemClass(rawItem);
                item.Update();
            }
        }
    }
}
