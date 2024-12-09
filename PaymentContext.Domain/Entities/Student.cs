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
            foreach (var item in Subscriptions)
            { 
                item.Inactivate();
            }

            _subscritipns.Add(subscription);

        }
    }
} 