using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Subscription> _subscriptions;

        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();
        }

        public Name Name { get; private set; }

        public Document Document { get; private set; }

        public Email Email { get; private set; }
     
        public Address Address { get; private set; }

        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToList(); } }

        public void AddSubscription(Subscription newSubscription)
        {
            foreach (var subscription in Subscriptions)
                subscription.Deactivate();

            _subscriptions.Add(newSubscription);
        }
    }
}
