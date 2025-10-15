using System;

namespace CIS207.Project6InventoryItem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InventoryUI menu = new InventoryUI();
            Inventory inventory = new Inventory();

            inventory.LoadInventory();
            menu.Run(inventory);
        }


    }
}