namespace csharpcore.Items
{
    public class BaseItem
    {
        protected Item _item;
        public BaseItem(Item item)
        {
            _item = item;
        }
        public virtual void Update()
        {
            _item.SellIn -= 1;
            Degrade();
            if(_item.SellIn < 0)
            {
                Degrade();
            }

        }

        protected void Degrade()
        {
            if (_item.Quality > 0)
            {
                _item.Quality -= 1;
            }
        }

        protected void Enhance(int factor)
        {
            _item.Quality += factor;
            if (_item.Quality > 50)
            {
                _item.Quality = 50;
            }
        }
    }
}