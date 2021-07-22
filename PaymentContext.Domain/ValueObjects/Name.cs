using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract<Name>()
               .Requires()
               .IsLowerThan(FirstName, 40, "Name.FirstName", "Name should have no more than 40 chars")
               .IsGreaterThan(FirstName, 3, "Name.FirstName", "Name should have at least 3 chars")
               .IsGreaterThan(LastName, 3, "Name.FirstName", "Name should have at least 3 chars")
            );
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }
    }
}
