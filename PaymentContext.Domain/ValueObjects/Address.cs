using PaymentContext.Domain.Contracts;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(string street, string number, string neighobrhood, string city, string state, string county, string zipCode)
        {
            Street = street;
            Number = number;
            Neighobrhood = neighobrhood;
            City = city;
            State = state;
            County = county;
            ZipCode = zipCode;

            AddNotifications(new CreateAddressContract(this));
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighobrhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string County { get; private set; }
        public string ZipCode { get; private set; }
    }
}