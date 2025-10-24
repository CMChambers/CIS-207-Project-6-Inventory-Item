

using CIS207.Project6InventoryItem;
using System.ComponentModel.DataAnnotations;
//using System.Text;

namespace CIS207.Project6InventoryItem
{
    internal class InventoryUI
    {
        private bool _isExitInput;
        private const string _mainMenuHeader = "The Backrooms";
        private const string _mainMenu = "" +
            " 0. Exit \n" +
            " 1. View All Items \n" +
            " 2. View Item \n" +
            " 3. Add Item \n" +
            " 4. Remove Item \n" +
            " 5. Increase Item Stock \n" +
            " 6. Decrease Item Stock \n" +
            " 7. Edit Item \n";
        private const string _mainMenuPrompt = "Enter Selection: ";
        private const string _viewHeaderNumber = "Number";
        private const string _viewHeaderName = "Name";
        private const string _viewHeaderPrice = "Price";
        private const string _viewHeaderStock = "Stock";
        private const string viewItemHeader = "View Item";
        private const string viewItemPrompt = "Enter item number to view, 0 to return: ";
        private const string viewAllItemsHeader = "View All Items";
        private const string ErrorNotFound = "Not Found, Try Again";

        public void Run(Inventory inventory)
        {
            PrintHeader(_mainMenuHeader);
            _isExitInput = false;

            while (!_isExitInput)
            {
                PrintMenu(_mainMenu);
                int inputInt = GetInputAsInt(_mainMenuPrompt);
                HandleMainMenuInput(inventory, inputInt);
            }
        }

        private void HandleMainMenuInput(Inventory inventory, int choice)
        {
            switch (choice)
            {
                case 0:
                    Exit();
                    break;
                case 1:
                    ViewAllItems(inventory);
                    break;
                case 2:
                    ViewItem(inventory);
                    break;
                case 3:
                    AddItem(inventory);
                    break;
                case 4:
                    RemoveItem(inventory);
                    break;
                case 5:
                    IncreaseItemStock(inventory);
                    break;
                case 6:
                    DecreaseItemStock(inventory);
                    break;
                case 7:
                    EditItem(inventory);
                    break;
                default:
                    break;
            }
        }

        private void Exit()
        { _isExitInput = true; }
        private static void ViewItem(Inventory inventory)
        {
            PrintHeader(viewItemHeader);
            while (true)
            {
                int itemNumber = GetInputAsInt(viewItemPrompt);
                if (itemNumber == 0)
                {
                    return;
                }
                else if (inventory.ContainsItem(itemNumber))
                {
                    PrintViewHeader();
                    PrintViewItem(inventory.GetItem(itemNumber));
                    break;
                }
                else
                {
                    HandleError(ErrorNotFound);
                }
            }
        }


        private static void ViewAllItems(Inventory inventory)
        {
            PrintHeader(viewAllItemsHeader);
            PrintViewHeader();

            var inventoryCopy = inventory.GetAllItems();
            foreach (var item in inventoryCopy)
            {
                PrintViewItem(item);
            }
        }
        private static void AddItem(Inventory inventory)
        {
            Console.WriteLine("==== Add Item ====");
            //bool validInput = false;
            int inputNumber = 0;
            while (true)
            {
                inputNumber = GetInputAsInt("Enter item number to add: ");
                if (!inventory.ContainsItem(inputNumber))
                {
                    //validInput = true;
                    break;
                }
                else
                { HandleError("Number not available, try again: "); }
            }
            //string inputName = GetInput.AsString("Enter item name: ");
            //decimal inputPrice = GetInput.AsDecimal("Enter item price: ");
            int inputStock = GetInputAsInt("Enter item stock: ");
            //_inventory.AddItem(inputNumber, inputName, inputPrice, inputStock);

            //inventory.AddItem(inputNumber, new InventoryItem(inputName, inputStock, inputPrice));
        }
        private static void RemoveItem(Inventory inventory)
        {
            Console.WriteLine("==== Remove Item ====");
            int itemNumber = GetInputAsInt("Enter item number to remove: ");
            //_inventory.RemoveItem(itemNumber);

        }
        private static void IncreaseItemStock(Inventory inventory)
        {
            Console.WriteLine("==== Increase Item Stock ====");
            int itemNumber = GetInputAsInt("Enter item number to remove: ");
            int itemIncrement = GetInputAsInt("Enter amount to increase by: ");
            //_inventory.IncreaseStock(itemNumber, itemIncrement);

        }
        private static void DecreaseItemStock(Inventory inventory)
        {
            Console.WriteLine("==== Decrease Item Stock ====");
            int itemNumber = GetInputAsInt("Enter item number to decrease: ");
            int itemDecrement = GetInputAsInt("Enter amount to decrease by: ");
            //_inventory.DecreaseStock(itemNumber, itemDecrement);

        }
        private static void EditItem(Inventory inventory)
        {
            Console.WriteLine("==== Edit Item ====");
            int itemNumber = GetInputAsInt("Enter item number to edit: ");

        }


        private static void HandleError(string errorMessage)
        { Console.WriteLine(errorMessage); }
        private static void PrintMenu(string menu)
        { Console.Write(menu); }
        private static void PrintViewHeader()
        {
            Console.WriteLine($"== {_viewHeaderNumber} == {_viewHeaderName} == {_viewHeaderPrice} == {_viewHeaderStock} ==");
            //format with tabs or something
        }
        private static void PrintViewItem((int number, InventoryItem listing) item)
        { Console.WriteLine($"{item.number}, {item.listing.Name}, {item.listing.Price}, {item.listing.Stock}"); }
        private static void PrintHeader(string header)
        {
            //Console.WriteLine($"======================================");
            Console.WriteLine($"============ {header} ============");
            //Console.WriteLine($"======================================");
        }


        static int GetInputAsInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                ValidationResultInt input = InputValidator.AsInt(Console.ReadLine() ?? "");

                if (!input.IsError)
                { return input.Value; }

                HandleError("Invalid, try again: ");
            }
        }
        static decimal GetInputAsDecimal(string prompt)
        {
            bool validInput = false;
            ValidationResultDecimal input = new();
            while (!validInput)
            {
                Console.Write(prompt);
                input = InputValidator.AsDecimal(Console.ReadLine() ?? "");
                if (input.IsError)
                { HandleError("Invalid, try again: "); }
                else
                { validInput = true; }
            }
            return input.Value;
        }
        static string GetInputAsString(string prompt)
        {
            bool validInput = false;
            ValidationResultString input = new();
            while (!validInput)
            {
                Console.Write(prompt);
                input = InputValidator.AsString(Console.ReadLine() ?? "");
                if (input.IsError)
                { HandleError("Invalid, try again: "); }
                else
                { validInput = true; }
            }
            return input.Value;
        }
    }
}