using System;
using GMT_ChangesAndValidation.Framework;
using GMT_ChangesAndValidation.PostSharp;

namespace GMT_ChangesAndValidation.Entities
{
    [IsBindable]
    public class CashEstimate
    {
        public decimal Amount { get; set; }
        public decimal Double { get; set; }

        public void OnAmountChanged()
        {
            Double = Amount*2;
        }

        public void AmountIsValid(ValidationResult result)
        {
            Console.WriteLine("Amount {0}", Amount);
            if (Amount < 0)
            {
                result.SetError("Amount must be greater than 0");
            }
        }

        public void DoubleIsValid(ValidationResult result)
        {
            if (Amount == 10)
                result.SetError("Amount can not be 10");
        }
    }
}