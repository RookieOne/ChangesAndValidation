using GMT_ChangesAndValidation.Framework;
using GMT_ChangesAndValidation.PostSharp;

namespace GMT_ChangesAndValidation.Entities
{
    [IsBindable]
    public class SalesPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; protected set; }

        public void OnFirstNameChanged()
        {
            FullName = FirstName + ' ' + LastName;
        }

        public void OnLastNameChanged()
        {
            FullName = FirstName + ' ' + LastName;
        }

        public void FirstNameIsValid(ValidationResult result)
        {
            if (FirstName == "Joe")
                result.SetError("First Name can not be Joe");
        }

        public void LastNameIsValid(ValidationResult result)
        {
            if(LastName == "Birkholz")
                result.SetError("Bad name");
        }
    }
}