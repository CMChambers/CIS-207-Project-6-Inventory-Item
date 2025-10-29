
namespace CIS207.Project6InventoryItem
{
    internal class InventoryItem
    {
        private int _number;
        private string _name;
        private int _stock;
        private decimal _price;

        public InventoryItem()
        {
            Number = 0;
            Name = String.Empty;
            Price = 0;
            Stock = 0;
        }
        public InventoryItem(int number, string name, decimal price, int stock)
        {
            Number = number;
            Name = name;
            Price = price;
            Stock = stock;
        }

        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }

        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        public decimal Price
        {
            get { return _price; }
            private set
            {
                //do check for cents
                _price = value;
            }
        }

        public int Stock
        {
            get { return _stock; }
            set { _stock = value; }
        }
    }
}