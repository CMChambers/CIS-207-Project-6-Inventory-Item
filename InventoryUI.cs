

using System.Text;

namespace CIS207.Project6InventoryItem
{
    internal class InventoryUI
    {
        bool IsExitInput;
        //int inputInt;
        string MainMenu = "" +
            " 0. Exit \n" +
            " 1. View All Items \n" +
            " 2. View Item \n" +
            " 3. Add Item \n" +
            " 4. Remove Item \n" +
            " 5. Increase Item Stock \n" +
            " 6. Decrease Item Stock \n" +
            " 7. Edit Item \n";
        string AddItemMenu = "" +
            " 0. Back \n" +
            " 1. \n";
        string PickItemByNumberMenu = "Enter Item Number: ";

        void PrintMenu(string _menu)
        {
            Console.Write(_menu);
        }

        internal void Run(Inventory _inventory)
        {
            PrintHeader();
            IsExitInput = false;

            while (!IsExitInput)
            {
                PrintMenu(MainMenu);
                int inputInt = GetInputInt("Enter Selection: ");
                HandleMainMenuInput(_inventory, inputInt);
            }
        }

        int GetInputInt(string _prompt)
        {
            bool validInput = false;
            ValidationResultInt input = new();
            while (!validInput)
            {
                Console.WriteLine(_prompt);
                input = InputValidator.AsInt(Console.ReadLine() ?? "");
                if (input.IsError)
                {
                    HandleError("Invalid, try again.");
                }
                else
                {
                    validInput = true;
                }
            }
            return input.Value;
        }

        private void HandleMainMenuInput(Inventory _inventory, int _inputInt)
        {
            switch (_inputInt)
            {
                case 0:
                    Exit();
                    break;
                case 1:
                    ViewAllItems(_inventory);
                    break;
                case 2:
                    ViewItem(_inventory);
                    break;
                case 3:
                    AddItem(_inventory);
                    break;
                case 4:
                    RemoveItem(_inventory);
                    break;
                case 5:
                    IncreaseItemStock(_inventory);
                    break;
                case 6:
                    DecreaseItemStock(_inventory);
                    break;
                case 7:
                    EditItem(_inventory);
                    break;
                default:
                    break;
            }
        }

        private void EditItem(Inventory _inventory)
        {
            Console.WriteLine("==== Edit Item ====");
        }

        private void DecreaseItemStock(Inventory _inventory)
        {
            Console.WriteLine("==== Decrease Item Stock ====");
            int itemNumber = GetInputInt("Enter item number to decrease: ");
            int itemDecrement = GetInputInt("Enter amount to decrease by: ");
            _inventory.DecreaseStock(itemNumber, itemDecrement);

        }

        private void IncreaseItemStock(Inventory _inventory)
        {
            Console.WriteLine("==== Increase Item Stock ====");
            int itemNumber = GetInputInt("Enter item number to remove: ");
            int itemIncrement = GetInputInt("Enter amount to increase by: ");
            _inventory.IncreaseStock(itemNumber, itemIncrement);

        }

        void print(string _s)
        { Console.WriteLine(_s); }

        private void RemoveItem(Inventory _inventory)
        {
            Console.WriteLine("==== Remove Item ====");
            int itemNumber = GetInputInt("Enter item number to remove: ");
            _inventory.RemoveItem(itemNumber);

        }
        private void AddItem(Inventory _inventory)
        {
            Console.WriteLine("==== Add Item ====");
            int inputNumber = GetInputInt("Enter item number to add: ");
            string inputName = GetInputString("Enter item name: ");
            decimal inputPrice = GetInputDecimal("Enter item price: ");
            int inputStock = GetInputInt("Enter item stock: ");
            _inventory.AddItem(inputNumber, inputName, inputPrice, inputStock);

        }
        private void HandleError(string _errorMessage)
        {
            Console.WriteLine(_errorMessage);
        }
        private void ViewItem(Inventory _inventory)
        {
            Console.WriteLine("==== View Item ====");
            int itemNumber = GetInputInt("Enter item number to view: ");
            
            // check the dictionary for that item number, return error if not found

            PrintViewHeader();
            PrintViewItem(_inventory.inventoryItems.(itemNumber));

        }
        private void ViewAllItems(Inventory _inventory)
        {
            Console.WriteLine("==== View All Item ====");

            PrintViewHeader();
            for (int i = 0; i < _inventory.inventoryItems.Count; i++)
            {
                PrintViewItem(_inventory.inventoryItems[i]);
            }
        }
        private void Exit()
        {
            IsExitInput = true;
        }

        //private void PrintMainMenu()
        //{
        //    Console.WriteLine("0. Exit");
        //    Console.WriteLine("1. Pick Item By Number");
        //    Console.WriteLine("2. View All Items");
        //    Console.WriteLine("3. Add Item");
        //    Console.WriteLine("4. Remove Item");
        //}

        private void PrintHeader()
        {
            Console.WriteLine($"======================================");
            Console.WriteLine($"============ The BackRoom ============");
            Console.WriteLine($"======================================");
        }
    }
}