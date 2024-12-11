using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        private readonly Name _name;
        private readonly Document _doc;
        private readonly Email _mail;
        private readonly Address _address;
        private readonly Student _student;
        private readonly Subscription _subscription;
        public StudentTests()
        {
            _name = new Name("Bruce", "Silva");
            _doc = new Document("85096215008", EDocumentType.CPF);
            _mail = new Email("bruce@mail.com");
            _address = new Address("rua 1", "12", "bairro centro", "gotham", "SP", "BR", "2345");
            _student = new Student(_name, _doc, _mail);
            _subscription = new Subscription(null);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WAYNE CORP", _doc, _address, _mail);
            _subscription.AddPayment(payment);

            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);
            
            Assert.IsFalse(_student.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadSubscriptionHasNoPayment()
        {

            _student.AddSubscription(_subscription);
            
            Assert.IsFalse(_student.IsValid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenHadNoActiveSubscription()
        {
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WAYNE CORP", _doc, _address, _mail);
            _subscription.AddPayment(payment);

            _student.AddSubscription(_subscription);
            
            Assert.IsTrue(_student.IsValid);
        }
    }
}