// a class to hold the results of an InputValidator decimal object
namespace CIS207.Project6InventoryItem
{
    internal class ValidationResultDecimal : ValidationResultBase
    {
        private decimal value;

        public decimal Value                                                        // the validated value
        {
            get => value;
            set => this.value = value;
        }

        public ValidationResultDecimal()                                        // constructor for an error result
        {
            this.IsError = true;
        }

        public ValidationResultDecimal(decimal _value)                                  // constructor for a successful result
        {
            IsError = false;
            Value = _value;
        }
    }

}


