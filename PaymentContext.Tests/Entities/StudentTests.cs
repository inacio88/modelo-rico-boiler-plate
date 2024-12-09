using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void AdicionarAssinatura()
        {
            var subscription = new Subscription(null);
            var student = new Student("Carlos", "Roberto", "1234563", "carlo@mail.com");
            student.AddSubscription(subscription);
        }
    }
}