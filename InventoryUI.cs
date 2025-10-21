

using System.Text;

namespace CIS207.Project6InventoryItem
{
    internal class InventoryUI
    {
        bool IsExitInput;
        private int input;

        internal void Run(Inventory _inventory)
        {
            PrintHeader();
            while (!IsExitInput)
            {
                PrintMainMenu();
                GetInput();
                HandleInput(_inventory);
            }
        }

        private void HandleInput(Inventory _inventory)
        {
            if (validatedInput.IsError)
            { HandleError(validatedInput); }

            switch (validatedInput.Value)
            {
                case 0:
                    Exit();
                    break;
                case 1:
                    PickItemByNumber(_inventory);
                    break;
                case 2:
                    ViewAllItems(_inventory);
                    break;
                case 3:
                    AddItem(_inventory);
                    break;
                case 4:
                    RemoveItem(_inventory);
                    break;
                default:
                    break;
            }
        }

        private void PickItemByNumber(Inventory _inventory)
        {
            Console.WriteLine("Enter Item Number: ");
            input = InputValidator.AsInt(Console.ReadLine());
            Console.WriteLine(_inventory.ListItem(input));
        }

        private void ViewAllItems(Inventory _inventory)
        {
            Console.Write(_inventory.ListAllInventory());
        }

        private void Exit()
        {
            IsExitInput = true;
        }

        private void GetInput()
        {
            IsExitInput = false;

            Console.Write($"Enter Selection : ");
            input = InputValidator.AsInt(Console.ReadLine() ?? "");
        }

        private void PrintMainMenu()
        {
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Pick Item By Number");
            Console.WriteLine("2. View All Items");
            Console.WriteLine("3. Add Item");
            Console.WriteLine("4. Remove Item");
        }

        private void PrintHeader()
        {
            Console.WriteLine($"======================================");
            Console.WriteLine($"============ The BackRoom ============");
            Console.WriteLine($"======================================");
        }
    }
}