// a class to hold the results of an InputValidator int object

namespace CIS207.Project6InventoryItem
{
    internal class ValidationResultInt : ValidationResultBase
    {
        private int value;

        public int Value                                                        // the validated value
        {
            get => value;
            set => this.value = value;
        }

        public ValidationResultInt()    // constructor for an error result
        {
            this.IsError = true;
        }

        public ValidationResultInt(int _value)                                  // constructor for a successful result
        {
            IsError = false;
            Value = _value;
        }
    }

}


