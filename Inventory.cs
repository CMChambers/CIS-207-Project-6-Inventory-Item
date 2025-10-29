



namespace CIS207.Project6InventoryItem
{
    internal class Inventory
    {
        public List<InventoryItem> inventoryItems = [];

        internal void LoadInventory()
        {
            inventoryItems.Add(new InventoryItem(1, "item 1", 1.00m, 1));
            inventoryItems.Add(new InventoryItem(2, "item 2", 10.00m, 1));
            inventoryItems.Add(new InventoryItem(3, "item 3", 5.00m, 1));
            inventoryItems.Add(new InventoryItem(4, "item 4", 12.00m, 1));
            inventoryItems.Add(new InventoryItem(5, "item 5", 2.00m, 1));
        }

        public bool ContainsItem(int itemNumber)
        {
            if (ContainsKey(itemNumber))
            { return true; }
            return false;
        }

        private bool ContainsKey(int itemNumber)
        {
            foreach (InventoryItem item in inventoryItems)
            {
                if (item.Number == itemNumber) { return true; }
            }
            return false;
        }

        public InventoryItem GetItem(int itemNumber)
        {
            foreach (InventoryItem item in inventoryItems)
            {
                if (item.Number == itemNumber)
                { return item; }
            }
            return null;
        }

        internal void AddItem(InventoryItem inventoryItem)
        {
            throw new NotImplementedException();
        }
        public void AddItem(int number, string name, decimal price, int stock)
        {
            inventoryItems.Add(new InventoryItem(number, name, price, stock));
        }
        public void RemoveItem(int itemNumber)
        {
            inventoryItems.Remove(GetItem(itemNumber));
        }
        public void IncreaseStock(int itemNumber, int amount)
        {
            foreach (InventoryItem item in inventoryItems)
            {
                if (item.Number == itemNumber)
                {
                    item.Stock += amount;
                    break;
                }
            }
        }
        public void DecreaseStock(int itemNumber, int amount)
        {
            foreach (InventoryItem item in inventoryItems)
            {
                if (item.Number == itemNumber)
                {
                    item.Stock -= amount;
                    break;
                }
            }
        }



        internal List<InventoryItem> GetAllItems()
        {
            //if (inventoryItems == null)
            return inventoryItems.ToList();
            //throw new NotImplementedException();
        }

        internal bool ItemNumberAvailable(int itemNumber)
        {
            if (ContainsKey(itemNumber))
            { return false; }
            return true;
        }
    }
}