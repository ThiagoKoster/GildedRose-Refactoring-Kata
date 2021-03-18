namespace csharpcore.Items
{
    public class BackstagePasses : BaseItem
    {
        public BackstagePasses(Item item) : base(item)
        {
        }

        public override void Update()
        {
            if(_item.SellIn > 10)
            {
                Enhance(1);
            }
            if (_item.SellIn > 5 && _item.SellIn < 11)
            {
                Enhance(2);
            }

            if (_item.SellIn > 0 && _item.SellIn < 6)
            {
                Enhance(3);
            }

            if(_item.SellIn <= 0)
            {
                _item.Quality = 0;
            }

            _item.SellIn -= 1;
        }
    }
}