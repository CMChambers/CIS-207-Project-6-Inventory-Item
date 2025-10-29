

using CIS207.Project6InventoryItem;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
//using System.Text;

namespace CIS207.Project6InventoryItem
{
    internal class InventoryUI
    {
        // fields at the bottom


        public void Run(Inventory inventory)
        {
            _isExitInput = false;
            SetOutput.PrintHeader(_mainMenuHeader);

            while (!_isExitInput)
            {
                SetOutput.PrintMenu(_mainMenu);
                int inputInt = GetInput.AsInt(_mainMenuPrompt);
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

        private static void ViewAllItems(Inventory inventory)
        {
            SetOutput.PrintHeader(viewAllItemsHeader);

            List<InventoryItem> inventoryCopy = inventory.GetAllItems();
            if (inventoryCopy.Count > 0)                                        // make error return method here
            {
                SetOutput.PrintViewHeader(_viewHeaderNumber, _viewHeaderName, _viewHeaderPrice, _viewHeaderStock);
                foreach (InventoryItem item in inventoryCopy)
                {
                    SetOutput.PrintViewItem(item);
                }
                SetOutput.PrintFooter();
                return;
            }
            SetOutput.HandleError(ErrorInventoryEmpty);
        }
        private static void ViewItem(Inventory inventory)
        {
            SetOutput.PrintHeader(viewItemHeader);

            while (true)
            {
                int itemNumber = GetInput.AsInt(viewItemPrompt);
                if (itemNumber == 0)
                {
                    SetOutput.PrintFooter();
                    return;
                }
                else if (inventory.ContainsItem(itemNumber))
                {
                    SetOutput.PrintViewHeader(_viewHeaderNumber, _viewHeaderName, _viewHeaderPrice, _viewHeaderStock);
                    SetOutput.PrintViewItem(inventory.GetItem(itemNumber));
                }
                else
                {
                    SetOutput.HandleError(ErrorItemNotFound);
                }
            }

        }
        private static void AddItem(Inventory inventory)
        {
            SetOutput.PrintHeader(addItemHeader);

            int inputNumber = 0;
            while (true)
            {
                inputNumber = GetInput.AsInt(addItemPrompt);
                if (inventory.ItemNumberAvailable(inputNumber))
                { break; }
                else
                { SetOutput.HandleError(ErrorItemNumberNotAvailable); }
            }

            string inputName = GetInput.AsString(addItemPromptForName);
            decimal inputPrice = GetInput.AsDecimal(addItemPromptForPrice);
            int inputStock = GetInput.AsInt(addItemPromptForStock);

            inventory.AddItem(inputNumber, inputName, inputPrice, inputStock);
        }
        private static void RemoveItem(Inventory inventory)
        {
            SetOutput.PrintHeader(removeItemHeader);

            //int itemNumber = GetInputAsInt(removeItemPrompt);
            while (true)
            {
                int inputNumber = GetInput.AsInt(removeItemPrompt);
                if (inputNumber == 0)
                {
                    return;
                }
                else if (inventory.ContainsItem(inputNumber))
                {
                    inventory.RemoveItem(inputNumber);
                    SetOutput.PrintFooter();
                    break;
                }
                else
                {
                    SetOutput.HandleError(ErrorItemNotFound);
                }
            }

        }
        private static void IncreaseItemStock(Inventory inventory)
        {
            SetOutput.PrintHeader(increaseItemStockHeader);
            while (true)
            {
                int itemNumber = GetInput.AsInt(increaseItemStockPrompt);
                if (inventory.ContainsItem(itemNumber))
                {
                    int itemIncrement = GetInput.AsInt(increaseItemStockPrompt2);
                    if (itemIncrement == 0)
                    {
                        return;
                    }
                    else if (itemIncrement > 0)
                    {
                        inventory.IncreaseStock(itemNumber, itemIncrement);
                        return;
                    }
                    else
                    {
                        SetOutput.HandleError(ErrorItemNotFound);
                    }
                }
            }
        }
        private static void DecreaseItemStock(Inventory inventory)
        {
            SetOutput.PrintHeader(decreaseItemStockHeader);
            while (true)
            {
                int itemNumber = GetInput.AsInt(decreaseItemStockPrompt);
                if (inventory.ContainsItem(itemNumber))
                {
                    int itemDecrement = GetInput.AsInt(decreaseItemStockPrompt2);
                    if (itemDecrement == 0)
                    {
                        return;
                    }
                    else if (itemDecrement > 0)
                    {
                        inventory.DecreaseStock(itemNumber, itemDecrement);
                        return;
                    }
                    else
                    {
                        SetOutput.HandleError(ErrorItemNotFound);
                    }
                }
            }
        }

        //private static void DecreaseItemStock(Inventory inventory)
        //{
        //    Console.WriteLine("==== Decrease Item Stock ====");
        //    int itemNumber = GetInputAsInt("Enter item number to decrease: ");
        //    int itemDecrement = GetInputAsInt("Enter amount to decrease by: ");
        //    //_inventory.DecreaseStock(itemNumber, itemDecrement);

        //}
        private static void EditItem(Inventory inventory)
        {
            Console.WriteLine("==== Edit Item ====");
            int itemNumber = GetInput.AsInt("Enter item number to edit: ");

        }


        //private static void HandleError(string errorMessage)
        //{ Console.WriteLine(errorMessage); }
        //private static void PrintMenu(string menu)
        //{ Console.Write(menu); }
        //private static void PrintViewHeader()
        //{
        //    Console.WriteLine($"== {_viewHeaderNumber} == {_viewHeaderName} == {_viewHeaderPrice} == {_viewHeaderStock} ==");
        //    //format with tabs or something
        //}
        //private static void PrintViewItem(InventoryItem item)
        //{ Console.WriteLine($"{item.Number}, {item.Name}, {item.Price}, {item.Stock}"); }
        //private static void PrintHeader(string header)
        //{
        //    Console.WriteLine($"======================================");
        //    Console.WriteLine($"============ {header} ============");
        //    Console.WriteLine($"======================================");
        //}
        //private static void PrintFooter()
        //{ Console.WriteLine($"============  ============"); }

        //static int GetInputAsInt(string prompt)
        //{
        //    while (true)
        //    {
        //        Console.Write(prompt);
        //        ValidationResultInt input = InputValidator.AsInt(Console.ReadLine() ?? "");

        //        if (!input.IsError)
        //        { return input.Value; }

        //        HandleError("Invalid, try again: ");
        //    }
        //}
        //static decimal GetInputAsDecimal(string prompt)
        //{
        //    bool validInput = false;
        //    ValidationResultDecimal input = new();
        //    while (!validInput)
        //    {
        //        Console.Write(prompt);
        //        input = InputValidator.AsDecimal(Console.ReadLine() ?? "");
        //        if (input.IsError)
        //        { HandleError("Invalid, try again: "); }
        //        else
        //        { validInput = true; }
        //    }
        //    return input.Value;
        //}
        //static string GetInputAsString(string prompt)
        //{
        //    bool validInput = false;
        //    ValidationResultString input = new();
        //    while (!validInput)
        //    {
        //        Console.Write(prompt);
        //        input = InputValidator.AsString(Console.ReadLine() ?? "");
        //        if (input.IsError)
        //        { HandleError("Invalid, try again: "); }
        //        else
        //        { validInput = true; }
        //    }
        //    return input.Value;
        //}

        #region fields

        private bool _isExitInput;
        private const string toReturn = ", 0 to return: ";
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
        private const string _viewHeaderStock = "Stock";
        private const string _viewHeaderPrice = "Price";

        private const string viewItemHeader = "View Item";
        private const string viewItemPrompt = "Enter item number to view: ";
        private const string viewAllItemsHeader = "View All Items";

        private const string addItemHeader = "Add Item";
        private const string addItemPrompt = "Enter item number to add: ";
        private const string addItemPromptForName = "Enter item name: ";
        private const string addItemPromptForPrice = "Enter item price: ";
        private const string addItemPromptForStock = "Enter item stock: ";

        private const string removeItemHeader = "Remove Item";
        private const string removeItemPrompt = "Enter item number to remove: ";

        private const string increaseItemStockHeader = "Increase Stock";
        private const string increaseItemStockPrompt = "Enter item number to increase stock: ";
        private const string increaseItemStockPrompt2 = "Enter amount to increase by: ";

        private const string decreaseItemStockHeader = "Decrease Stock";
        private const string decreaseItemStockPrompt = "Enter item number to decrease stock: ";
        private const string decreaseItemStockPrompt2 = "Enter amount to decrease by: ";

        private const string editItemHeader = "Edit Item";
        private const string editItemPrompt = "Enter item number to edit: ";

        private const string ErrorItemNotFound = "Not Found, Try Again";
        private const string ErrorItemNumberNotAvailable = "Number not available, try again: ";
        private const string ErrorInventoryEmpty = "Error Inventory Empty";

        #endregion
    }
}