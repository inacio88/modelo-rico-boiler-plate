namespace PaymentContext.Domain.Entities
{
    public class Student
    {
        private IList<Subscription> _subscritipns;
        public Student(string firstName, string lastName, string document, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Document = document;
            Email = email;
            _subscritipns = new List<Subscription>();
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string Adress { get; private set; }

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