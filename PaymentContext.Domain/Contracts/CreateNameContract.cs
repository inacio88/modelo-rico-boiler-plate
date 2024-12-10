using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Contracts
{
    public class CreateNameContract : Contract<Name>
    {
        public CreateNameContract(Name name)
        {
            Requires()
            .IsGreaterOrEqualsThan(name.FirstName, 3, "name.FirstName", "FirstName deve conter pelo menos 3 caracteres")
            .IsGreaterOrEqualsThan(name.LastName, 2, "name.LastName", "LastName deve conter pelo menos 2 caracteres")
            .IsLowerOrEqualsThan(name.FirstName, 40, "name.FirstName", "FirstName deve ter menos de 40 caracteres")
            ;
        }
    }
}