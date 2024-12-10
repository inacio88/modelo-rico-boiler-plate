using PaymentContext.Domain.Contracts;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Subscription> _subscritipns;
        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscritipns = new List<Subscription>();

            AddNotifications(name, document, email);
        }

        public Name Name { get; set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public string Address { get; private set; }

        public IReadOnlyCollection<Subscription> Subscriptions { get {return _subscritipns.ToArray();} }

        public void AddSubscription(Subscription subscription)
        {
            var hasSubscriptionActive = false;
            foreach (var item in Subscriptions)
            {
                if (item.Active)
                {
                    hasSubscriptionActive = true;   
                }
            }

            var contrato = new CreateStudentContract();
            contrato
            .IsFalse(hasSubscriptionActive, "student.Subscriptions", "Você já tem uma assinatura ativa")
            .AreNotEquals(0, subscription.Payments.Count, "student.subscription.Payments", "Esta assinatura não possui pagamentos")
            ;
            AddNotifications(contrato);

            if(IsValid)
                _subscritipns.Add(subscription);
        }
    }
} 