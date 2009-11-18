using GMT_ChangesAndValidation.Framework;
using GMT_ChangesAndValidation.PostSharp;

namespace GMT_ChangesAndValidation.Entities
{
    [Notify]
    [OnChanged]
    public class CashEstimate : Entity
    {
        public decimal Amount { get; set; }
        public decimal Double { get; set; }

        public void OnAmountChanged()
        {
            Double = Amount*2;
        }

        public ValidationResult AmountIsValid()
        {
            var result = new ValidationResult();

            if (Amount < 0)
            {
                result.SetError("Amount must be greater than 0");
            }

            return result;
        }

        public ValidationResult DoubleIsValid()
        {
            var result = new ValidationResult();

            if (Amount == 10)
                result.SetError("Amount can not be 10");

            return result;
        }
    }
}