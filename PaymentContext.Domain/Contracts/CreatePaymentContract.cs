using Flunt.Validations;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Domain.Contracts
{
    public class CreatePaymentContract : Contract<Payment>
    {
        public CreatePaymentContract(Payment payment)
        {
            Requires()
            .IsGreaterThan(DateTime.Now, payment.PaidDate, "Subscription.Payments", "A data do pagamento não pode ser no passado");
        }
    }
}