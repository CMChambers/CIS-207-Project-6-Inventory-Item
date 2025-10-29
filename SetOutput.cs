using System.ComponentModel.DataAnnotations;
using System.Reflection.PortableExecutable;

namespace CIS207.Project6InventoryItem
{
    public class SetOutput
    {

        public static void HandleError(string errorMessage)
        { Console.WriteLine(errorMessage); }

        public static void PrintMenu(string menu)
        { Console.Write(menu); }

        public static void PrintViewHeader(string number, string name, string price, string stock)
        {
            Console.WriteLine($"{number,-10}{name,-15}{price,10}{stock,10}");
            //format with tabs or something
        }

        public static void PrintViewItem(InventoryItem item)
        { Console.WriteLine($"{item.Number,-10}{item.Name,-15}{item.Price,10:C}{item.Stock,10}"); }

        public static void PrintHeader(string header)
        {
            string v = new('=', Math.Max(0, (50 - header.Length) / 2));
            string x = new('=', Math.Max(0, 52));

            Console.WriteLine($"{x}");
            Console.WriteLine($"{v} {header} {v}");
            Console.WriteLine($"{x}");
        }

        public static void PrintFooter()
        {
            string v = new('=', Math.Max(0, 52));
            Console.WriteLine($"{v}");
        }

    }
}