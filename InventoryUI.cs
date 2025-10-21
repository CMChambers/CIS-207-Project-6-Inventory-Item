

using System.Text;

namespace CIS207.Project6InventoryItem
{
    internal class InventoryUI
    {
        bool IsExitInput;
        private int validatedInput;

        internal void Run(Inventory inventory)
        {
            PrintHeader();
            while (!IsExitInput)
            {
                PrintMenu();
                GetInput();
                HandleInput();
            }
        }

        private void HandleInput()
        {
            if (validatedInput.IsError)
            { HandleError(validatedInput); }

            switch (validatedInput.Value)
            {
                case 0:
                    PickItemByNumber();
                    break;
                case 1:
                    ViewAllItems();
                    break;
                case 2:
                    Exit();
                    break;
                default:
                    break;
            }
        }

        private void GetInput()
        {
            IsExitInput = false;

            Console.Write($"Enter Selection : ");
            string rawInput = Console.ReadLine() ?? "";
            validatedInput = InputValidator.AsInt(rawInput);
        }

        private void PrintMenu()
        {
            PrintMainMenu();
        }

        private void PrintMainMenu()
        {
            Console.WriteLine($"1. Pick Item By Number");
            Console.WriteLine($"2. View All Items");
            Console.WriteLine($"3. Exit");
        }

        private void PrintHeader()
        {
            Console.WriteLine($"======================================");
            Console.WriteLine($"============ The BackRoom ============");
            Console.WriteLine($"======================================");
        }
    }
}