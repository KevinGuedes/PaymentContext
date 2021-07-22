using Flunt.Notifications;
using System;

namespace PaymentContext.Shared.Entities
{
    public abstract class Entity : Notifiable<Notification>
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
