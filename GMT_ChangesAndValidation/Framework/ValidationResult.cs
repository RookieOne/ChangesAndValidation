namespace GMT_ChangesAndValidation.Framework
{
    public class ValidationResult
    {
        public ValidationResult()
        {
            IsValid = true;
        }

        public bool IsValid { get; set; }
        public string Message { get; set; }

        public void SetError(string message)
        {
            IsValid = false;
            Message = message;
        }
    }
}