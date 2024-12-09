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
        string adress,
        string owner,
        string document,
        string email): base(paidDate, expireDate, total, totalPaid, adress, owner, document, email)
        {
            BoletoNumber = boletoNumber;
            BarCode = barCode;
        }

        public string BoletoNumber { get; private set; }
        public string BarCode { get; private set; }
    }
}