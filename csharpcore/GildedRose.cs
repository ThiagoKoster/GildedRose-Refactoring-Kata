using System.Collections.Generic;

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
            for (var i = 0; i < Items.Count; i++)
            {
                UpdateItemQuality(Items[i]);

                UpdateSellIn(Items[i]);

                if (Items[i].SellIn < 0)
                {
                    UpdateExpiredItem(Items[i]);
                }
            }
        }

        private void UpdateItemQuality(Item item)
        {
            if (item.Name == ItemsNames.Sulfuras)
            {
                return;
            }
            
            if (item.Name == ItemsNames.AgedBrie)
            {
                if(item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }
                return;
            }

            if (item.Name == ItemsNames.BackstagePasses)
            {
                if(item.Quality < 50)
                {
                    UpdateBackstagePassesQuality(item);
                }
                return;
            }

            if (item.Quality > 0)
            {
                item.Quality -= 1;
                return;
            }
        }

        private static void UpdateBackstagePassesQuality(Item item)
        {
            if (item.SellIn > 10)
            {
                item.Quality += 1;
            }
            if (item.SellIn > 5 && item.SellIn < 11)
            {
                item.Quality += 2;
            }

            if (item.SellIn > 0 && item.SellIn < 6)
            {
                item.Quality += 3;
            }

            if(item.Quality > 50)
            {
                item.Quality = 50;
            }
        }

        private void UpdateExpiredItem(Item item)
        {
            if(item.Name == ItemsNames.Sulfuras)
            {
                return;
            }
            if(item.Name == ItemsNames.AgedBrie)
            {
                if (item.Quality < 50)
                {
                    item.Quality += 1;
                }
                return;
            }
            if(item.Name == ItemsNames.BackstagePasses)
            {
                item.Quality = 0;
                return;
            }

            if (item.Quality > 0)
            {
                item.Quality -= 1;
            }
        }

        private void UpdateSellIn(Item item)
        {
            if (item.Name != ItemsNames.Sulfuras)
            {
                item.SellIn -= 1;
            }
        }
    }
}
