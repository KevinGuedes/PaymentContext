using Flunt.Notifications;
using Flunt.Validations;
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

            AddNotifications(name, document, email); //Grouping all notifications from name, document and email
        }

        public Name Name { get; private set; }

        public Document Document { get; private set; }

        public Email Email { get; private set; }
     
        public Address Address { get; private set; }

        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToList(); } }

        public void AddSubscription(Subscription newSubscription)
        {
            var hasActiveSubscription = false;

            foreach(var sub in _subscriptions)
            {
                if (sub.IsActive)
                    hasActiveSubscription = true;
            }

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsFalse(hasActiveSubscription, "Student.Subscriptions", "Student already has an active subscription")
                .AreNotEquals(0, newSubscription.Payments.Count, "Student.Subscription.Payments", "No payments made in the new subscription")
            );

            if (IsValid)
                _subscriptions.Add(newSubscription);

            // if (hasSubscriptionActive)
            //     AddNotification("Student.Subscriptions", "Você já tem uma assinatura ativa");
        }
    }
}
