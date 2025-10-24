



namespace CIS207.Project6InventoryItem
{
    internal class Inventory
    {
        public Dictionary<int, InventoryItem> inventoryItems = [];

        internal void LoadInventory()
        {
            inventoryItems.Add(1001, new InventoryItem("item 1", 1.00m, 1));
            inventoryItems.Add(1002, new InventoryItem("item 2", 10.00m, 1));
            inventoryItems.Add(1003, new InventoryItem("item 3", 5.00m, 1));
            inventoryItems.Add(1004, new InventoryItem("item 4", 12.00m, 1));
            inventoryItems.Add(1005, new InventoryItem("item 5", 2.00m, 1));
        }

        public bool ContainsItem(int _itemNumber)
        {
            if (inventoryItems.ContainsKey(_itemNumber))
            { return true; }
            return false;
        }

        public (int, InventoryItem) GetItem(int _itemNumber)
        {
            return (_itemNumber, inventoryItems[_itemNumber]);
        }

        internal void AddItem(int inputNumber, InventoryItem inventoryItem)
        {
            throw new NotImplementedException();
        }

        internal IEnumerable<InventoryItem> GetAllItems()
        {
            //if (inventoryItems == null)
            //return inventoryItems.ToList();
            throw new NotImplementedException();
        }
    }
}