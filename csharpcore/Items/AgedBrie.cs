namespace csharpcore.Items
{
    public class AgedBrie : BaseItem
    {
        public AgedBrie(Item item) : base(item)
        {
        }

        public override void Update()
        {
            Enhance(1);
            _item.SellIn -= 1;
            if(_item.SellIn < 0)
            {
                Enhance(1);    
            }
        }
    }
}