// an abstract base class to hold the results of an InputValidator object.
// the error message info is what is common to the child classes

namespace CIS207.Project6InventoryItem
{
    abstract class ValidationResultBase
    {
        private string errorMessage = string.Empty;
        //private string errorTitle = string.Empty;
        private bool isError;
        public string ErrorMessage                                              // the error message for an unsuccessful validation
        {
            get => errorMessage;
            set => errorMessage = value;
        }
        //public string ErrorTitle                                                // the error message box title for unsuccessful validation
        //{
        //    get => errorTitle;
        //    set => errorTitle = value;
        //}

        public bool IsError                                                     // flag to show successful validation
        {
            get => isError;
            set => isError = value;
        }
    }
}