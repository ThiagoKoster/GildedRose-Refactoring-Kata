using Xunit;
using System.Collections.Generic;
using FluentAssertions;

namespace csharpcore
{
    public class GildedRoseTest
    {
        [Fact]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Name.Should().Be("foo");
        }

        [Fact]
        public void UpdateQuality_Should_UpdateQualityAndSellIn()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            
            Items[0].Quality.Should().Be(9);
            Items[0].SellIn.Should().Be(9);
        }

        [Fact]
        public void UpdateQuality_Should_Be_Faster_When_SellInExpired()
        {
            IList<Item> Items = new List<Item> { 
                new Item { Name = "foo", SellIn = 0, Quality = 10 },
                new Item { Name = "Aged Brie", SellIn = 0, Quality = 2 },
                new Item { Name = "Aged Brie", SellIn = -1, Quality = 2 }
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(8);
            Items[1].Quality.Should().Be(4);
            Items[2].Quality.Should().Be(4);
        }

        [Fact]
        public void Quality_Should_NotBe_Negative()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(0);
        }

        [Fact]
        public void Quality_Should_Increase_When_AgedBrie()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 2 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(3);
        }

        [Fact]
        public void Quality_Should_Increase_When_Is_50()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 50 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(50);
        }

        [Fact]
        public void Quality_Should_NotUpdate_When_ItemIsSulfuras()
        {
            IList<Item> Items = new List<Item> { 
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 1, Quality = 80 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 }  
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(80);
            Items[1].Quality.Should().Be(80);
        }
        
        [Fact]
        public void Quality_Should_IncreaseBy2_When_SellIn_LessOrEqualThan10()
        {
            IList<Item> Items = new List<Item> { 
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 10 }
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            
            Items[0].Quality.Should().Be(12);
            Items[1].Quality.Should().Be(12);

        }

        [Fact]
        public void Quality_Should_IncreaseBy3_When_SellIn_LessOrEqualThan5()
        {
            IList<Item> Items = new List<Item> { 
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 10 }
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            
            Items[0].Quality.Should().Be(13);
            Items[1].Quality.Should().Be(13);

        }

         [Fact]
        public void Quality_Should_Be_0_When_SellIn_Is_LessOrEqualThan0()
        {
            IList<Item> Items = new List<Item> { 
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 10 }
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            
            Items[0].Quality.Should().Be(0);
            Items[1].Quality.Should().Be(0);

        }
    }
}