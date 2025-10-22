// a class to validated inputs

using System.Globalization;

namespace CIS207.Project6InventoryItem
{
    static class InputValidator
    {
        public static ValidationResultInt AsInt(string _input)                                   // returns a validation result for an int
        {
            if (!TryConvertToInt(_input, out int convertedNumber))                                         // try to convert the text to numbers
            { return new ValidationResultInt(); }                                                // returns a validation result containing error

            return new ValidationResultInt(convertedNumber);                                            // return validated result containing int and no-error falg
        }

        public static ValidationResultDecimal AsDecimal(string _input)                                   // returns a validation result for an int
        {
            if (!TryConvertToDecimal(_input, out decimal convertedNumber))                                         // try to convert the text to numbers
            { return new ValidationResultDecimal(); }                                                // returns a validation result containing error

            return new ValidationResultDecimal(convertedNumber);                                            // return validated result containing int and no-error falg
        }

        internal static ValidationResultString AsString(string _input)                           // returns a validation result for a string
        {
            string convertedText = _input.Trim();                                                      // declare result variable, assigns trimmed parameter to it

            if (string.IsNullOrEmpty(convertedText))                                                    // checks if string is empty or null
            { return new ValidationResultString(); }                                                // returns a validation result containing error information

            return new ValidationResultString(convertedText);                                           // return validation result containing string and no-error flag
        }

        private static bool TryConvertToInt(string _inputNumber, out int _convertedNumber)                // tries to parse int, returns true for success, false for fail
        {
            return int.TryParse(
                            _inputNumber,
                            NumberStyles.Integer,                                                       // allows leading & trailing white space & negative
                            CultureInfo.InvariantCulture,                                               // use "." as decimal separator
                            out _convertedNumber
                        );
        }
        private static bool TryConvertToDecimal(string _inputNumber, out decimal _convertedNumber)                // tries to parse int, returns true for success, false for fail
        {
            return decimal.TryParse(
                            _inputNumber,
                            NumberStyles.Number,                                                       // allows leading & trailing white space & negative
                            CultureInfo.InvariantCulture,                                               // use "." as decimal separator
                            out _convertedNumber
                        );
        }

    }
}


