

using System.Text;

namespace CIS207.Project6InventoryItem
{
    internal class InventoryUI
    {
        string[] mainMenu =
        {
            "List All Items",
            "Select Item by Number",
            "Exit"
        };

        string[] itemMenu =
        {
            "Reduce Stock",
            "Increase Stock",
            "Rename Item",
            "Change Price"

        };
        string[] currentMenu;

        internal void Run(Inventory inventory)
        {
            SetMenuState();
            PrintHeader();
            PrintMenu();
            GetInput();
        }

        private void SetMenuState()
        {
            currentMenu = mainMenu;
        }

        private void GetInput()
        {
            Console.Write($"Enter Selection : ");
            string result = Console.ReadLine() ?? "";
        }

        private void PrintMenu()
        {
            Console.WriteLine(PrintCurrentMenu(currentMenu));
        }

        private static string PrintCurrentMenu(string[] _currentMenu)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < _currentMenu.Length; i++)
            {
                string? item = _currentMenu[i];
                sb.AppendLine($"{i + 1} : {_currentMenu[i]}");
            }

            string result = sb.ToString();

            return result;
        }

        private void PrintHeader()
        {
            Console.WriteLine($"======================================");
            Console.WriteLine($"============ The BackRoom ============");
            Console.WriteLine($"======================================");
        }
    }
}