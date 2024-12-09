using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class BoletoPayment : Payment
    {
        public BoletoPayment(string boletoNumber,
        string barCode,
        DateTime paidDate,
        DateTime expireDate,
        decimal total,
        decimal totalPaid,
        Address address,
        string owner,
        Document document,
        Email email): base(paidDate, expireDate, total, totalPaid, address, owner, document, email)
        {
            BoletoNumber = boletoNumber;
            BarCode = barCode;
        }

        public string BoletoNumber { get; private set; }
        public string BarCode { get; private set; }
    }
}