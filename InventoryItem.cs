namespace CIS207.Project6InventoryItem
{
    internal class InventoryItem
    {
        private string name;
        private int count;
        private double price;

        public InventoryItem(string _name, int _count, double _price)
        {
            Name = _name ;
            Count = _count;
            Price = _price;
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public int Count
        {
            get { return count; }
            private set { count = value; }

        }

        public double Price
        {
            get { return price; }
            private set { price = value; }
        }

        public void Rename(string _newName)
        {
            name = _newName;
        }
    }
}