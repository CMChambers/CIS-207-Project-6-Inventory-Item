

using System.Text;

namespace CIS207.Project6InventoryItem
{
    internal class InventoryUI
    {
        private bool _isExitInput;
        private string _mainMenu = "" +
            " 0. Exit \n" +
            " 1. View All Items \n" +
            " 2. View Item \n" +
            " 3. Add Item \n" +
            " 4. Remove Item \n" +
            " 5. Increase Item Stock \n" +
            " 6. Decrease Item Stock \n" +
            " 7. Edit Item \n";

        public void Run(Inventory inventory)
        {
            PrintHeader();
            _isExitInput = false;

            while (!_isExitInput)
            {
                PrintMenu(_mainMenu);
                int inputInt = GetInputInt("Enter Selection: ");
                HandleMainMenuInput(inventory, inputInt);
            }
        }
        private void PrintMenu(string menu)
        {
            Console.Write(menu);
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
        private void EditItem(Inventory inventory)
        {
            Console.WriteLine("==== Edit Item ====");
            int itemNumber = GetInputInt("Enter item number to edit: ");

        }
        private void DecreaseItemStock(Inventory inventory)
        {
            Console.WriteLine("==== Decrease Item Stock ====");
            int itemNumber = GetInputInt("Enter item number to decrease: ");
            int itemDecrement = GetInputInt("Enter amount to decrease by: ");
            //_inventory.DecreaseStock(itemNumber, itemDecrement);

        }
        private void IncreaseItemStock(Inventory inventory)
        {
            Console.WriteLine("==== Increase Item Stock ====");
            int itemNumber = GetInputInt("Enter item number to remove: ");
            int itemIncrement = GetInputInt("Enter amount to increase by: ");
            //_inventory.IncreaseStock(itemNumber, itemIncrement);

        }
        private void RemoveItem(Inventory inventory)
        {
            Console.WriteLine("==== Remove Item ====");
            int itemNumber = GetInputInt("Enter item number to remove: ");
            //_inventory.RemoveItem(itemNumber);

        }
        private void AddItem(Inventory inventory)
        {
            Console.WriteLine("==== Add Item ====");
            //bool validInput = false;
            int inputNumber = 0;
            while (true)
            {
                inputNumber = GetInputInt("Enter item number to add: ");
                if (!inventory.ContainsItem(inputNumber))
                {
                    //validInput = true;
                    break;
                }
                else
                { HandleError("Number not available, try again: "); }
            }
            string inputName = GetInputString("Enter item name: ");
            decimal inputPrice = GetInputDecimal("Enter item price: ");
            int inputStock = GetInputInt("Enter item stock: ");
            //_inventory.AddItem(inputNumber, inputName, inputPrice, inputStock);

            inventory.AddItem(inputNumber, new InventoryItem(inputName, inputStock, inputPrice));
        }
        private void HandleError(string errorMessage)
        {
            Console.WriteLine(errorMessage);
        }
        private void ViewItem(Inventory inventory)
        {
            Console.WriteLine("==== View Item ====");
            bool validInput = false;
            while (!validInput)
            {
                int itemNumber = GetInputInt("Enter item number to view, 0 to return: ");
                if (itemNumber == 0)
                {
                    return;
                }
                else if (inventory.ContainsItem(itemNumber))
                {
                    PrintViewHeader();
                    PrintViewItem(inventory.GetItem(itemNumber));
                    validInput = true;
                }
                else
                {
                    HandleError("Not Found, Try Again");
                }
            }
        }

        private void PrintViewHeader()
        {
            Console.WriteLine("== Number == Name == Price == Stock==");
            //format with tabs or something
        }

        private void ViewAllItems(Inventory inventory)
        {
            Console.WriteLine("==== View All Item ====");

            PrintViewHeader();
            //PrintViewItem();
            //for (int i = 0; i < _inventory.inventoryItems.Count; i++)
            //{
            //    PrintViewItem(_inventory.inventoryItems[i]);
            //}
        }

        private void PrintViewItem((int number, InventoryItem listing) item)
        {
            Console.WriteLine($"{item.number}, {item.listing.Name}, {item.listing.Price}, {item.listing.Count}");
        }

        int GetInputInt(string prompt)
        {
            bool validInput = false;
            ValidationResultInt input = new();
            while (!validInput)
            {
                Console.Write(prompt);
                input = InputValidator.AsInt(Console.ReadLine() ?? "");
                if (input.IsError)
                { HandleError("Invalid, try again: "); }
                else
                { validInput = true; }
            }
            return input.Value;
        }
        decimal GetInputDecimal(string prompt)
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
        string GetInputString(string prompt)
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

        private void PrintHeader()
        {
            Console.WriteLine($"======================================");
            Console.WriteLine($"============ The BackRoom ============");
            Console.WriteLine($"======================================");
        }
    }
}