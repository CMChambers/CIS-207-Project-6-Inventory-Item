
namespace CIS207.Project6InventoryItem
{
    internal class Inventory
    {
        public Dictionary<int, InventoryItem> inventoryItems = new Dictionary<int, InventoryItem>();

        internal void LoadInventory()
        {
            inventoryItems.Add(1001, new InventoryItem("item 1", 1, 1.00));
            inventoryItems.Add(1002, new InventoryItem("item 2", 1, 10.00));
            inventoryItems.Add(1003, new InventoryItem("item 3", 1, 5.00));
            inventoryItems.Add(1004, new InventoryItem("item 4", 1, 12.00));
            inventoryItems.Add(1005, new InventoryItem("item 5", 1, 2.00));

        }
    }
}