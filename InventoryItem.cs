
namespace CIS207.Project6InventoryItem
{
    internal class InventoryItem
    {
        private string _name;
        private int _stock;
        private decimal _price;

        public InventoryItem(string name, decimal price, int stock)
        {
            Name = name ;
            Price = price;
            Stock = stock;
        }

        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        public int Stock
        {
            get { return _stock; }
            private set { _stock = value; }

        }

        public decimal Price
        {
            get { return _price; }
            private set { _price = value; }
        }

        public void Rename(string _newName)
        {
            _name = _newName;
        }
    }
}