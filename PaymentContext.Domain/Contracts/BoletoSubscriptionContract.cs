using Flunt.Validations;
using PaymentContext.Domain.Commands;

namespace PaymentContext.Domain.Contracts;

public class BoletoSubscriptionContract : Contract<CreateBoletoSubscriptionCommand>
{
    public BoletoSubscriptionContract(CreateBoletoSubscriptionCommand command)
    {
        Requires()
            .IsGreaterOrEqualsThan(command.FirstName, 3, "Name.FirstName", "Nome deve conter pelo menos 3 caracteres")
            .IsLowerOrEqualsThan(command.FirstName, 40, "Name.FirstName", "Nome deve conter até 40 caracteres");
    }
}