using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Entities
{
    public class Student
    {
        private IList<Subscription> _subscriptions;

        public Student(string firstName, string lastName, string document, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Document { get; private set; }

        public string Email { get; private set; }
     
        public string Address { get; private set; }

        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToList(); } }

        public void AddSubscription(Subscription newSubscription)
        {
            foreach (var subscription in Subscriptions)
                subscription.Deactivate();

            _subscriptions.Add(newSubscription);
        }
    }
}
