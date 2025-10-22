// a class to validated inputs

using System.Globalization;

namespace CIS207.Project6InventoryItem
{
    static class InputValidator
    {
        public static ValidationResultInt AsInt(string _number)                                   // returns a validation result for an int
        {
            int convertedNumber;                                                                        // declare result variables

            if (!TryConvertToInt(_number, out convertedNumber))                                         // try to convert the text to numbers
            { return new ValidationResultInt(); }                                                // returns a validation result containing error

            return new ValidationResultInt(convertedNumber);                                            // return validated result containing int and no-error falg
        }

        internal static ValidationResultString AsString(string _string)                           // returns a validation result for a string
        {
            string convertedText = _string.Trim();                                                      // declare result variable, assigns trimmed parameter to it

            if (string.IsNullOrEmpty(convertedText))                                                    // checks if string is empty or null
            { return new ValidationResultString("Please enter a name", "Missing Name"); }               // returns a validation result containing error information

            return new ValidationResultString(convertedText);                                           // return validation result containing string and no-error flag


        }

        private static bool TryConvertToInt(string inputNumber, out int convertedNumber)                // tries to parse int, returns true for success, false for fail
        {
            return int.TryParse(
                            inputNumber,
                            NumberStyles.Integer,                                                       // allows leading & trailing white space & negative
                            CultureInfo.InvariantCulture,                                               // use "." as decimal separator
                            out convertedNumber
                        );
        }
    }
}


