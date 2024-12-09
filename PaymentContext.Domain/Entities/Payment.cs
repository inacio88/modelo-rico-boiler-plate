namespace PaymentContext.Domain.Entities
{
    public abstract class Payment
    {
        public string Number { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public string Adress { get; set; }
        public string Owner { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
    }
}