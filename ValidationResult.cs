
namespace CIS207.Project6InventoryItem
{
    internal class ValidationResult<T>
    {
        public bool IsError
        { get { return !IsSuccess; } }
        public bool IsSuccess
        { get; }
        public T? Value
        { get; }
        public string? ErrorMessage
        { get; }

        private ValidationResult(T? value, bool isSuccess, string? message)
        {
            Value = value;
            IsSuccess = isSuccess;
            ErrorMessage = message;
        }

        public ValidationResult()
        {
            IsSuccess = false;

        }

        public static ValidationResult<T> Success(T value)
        { return new ValidationResult<T>(value, true, null); }

        public static ValidationResult<T> Error(string message)
        { return new ValidationResult<T>(default, false, message); }

    }
}
