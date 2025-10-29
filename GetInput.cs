//using CIS207.Project6InventoryItem;

using System.ComponentModel.DataAnnotations;

namespace CIS207.Project6InventoryItem
{
    internal class GetInput
    {
        public static T GetValidatedInput<T>(
        string prompt,
        Func<string, ValidationResult<T>> validator, string errorMessage)
        {
            while (true)
            {
                Console.Write(prompt);
                ValidationResult<T> result = validator(Console.ReadLine() ?? "");

                if (!result.IsError)
                    return result.Value!;

                Console.WriteLine(errorMessage);
            }
        }

        public static int AsInt(string prompt)
        { return GetValidatedInput(prompt, InputValidator.AsInt, "Invalid number, try again: "); }

        public static decimal AsDecimal(string prompt)
        { return GetValidatedInput(prompt, InputValidator.AsDecimal, "Invalid amount, try again: "); }

        public static string AsString(string prompt)
        { return GetValidatedInput(prompt, InputValidator.AsString, "Invalid text, try again: "); }
    }
}
