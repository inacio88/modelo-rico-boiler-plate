using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Contracts
{
    public class CreateAddressContract : Contract<Address>
    {
        public CreateAddressContract(Address address)
        {
            Requires()
            .IsGreaterOrEqualsThan(address.Street, 3, "address.Street", "a rua deve conter pelo menos 3 caracteres");
        }
    }
}