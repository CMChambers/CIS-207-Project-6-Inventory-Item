

using System.Text;

namespace CIS207.Project6InventoryItem
{
    internal class InventoryUI
    {
        string[] mainMenu =
        {
                "List All Items" ,
                 "Exit"
        };

        internal void Run(Inventory inventory)
        {
            PrintHeader();
            PrintMenu();
            GetInput();
        }

        private void GetInput()
        {
            Console.Write($"Enter Selection : ");
            string result = Console.ReadLine() ?? "";
        }

        private void PrintMenu()
        {
            Console.WriteLine(PrintCurrenctMenu(mainMenu));
        }

        private static string PrintCurrenctMenu(string[] _currentMenu)
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