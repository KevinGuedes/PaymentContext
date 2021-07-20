using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Entities
{
    public class Subscription
    {
        private IList<Payment> _payments;

        public Subscription(DateTime? expirationDate)
        {
            CreationDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
            ExpirationDate = expirationDate;
            IsActive = true;
            _payments = new List<Payment>();
        }

        public DateTime CreationDate { get; private set; }

        public DateTime LastUpdateDate { get; private set; }

        public DateTime? ExpirationDate { get; private set; }

        public bool IsActive { get; private set; }

        public IReadOnlyCollection<Payment> Payments { get { return _payments.ToList(); } }

        public void AddPayment(Payment payment)
        {
            _payments.Add(payment);
        }

        public void Activate()
        {
            IsActive = true;
            LastUpdateDate = DateTime.Now;
        }

        public void Deactivate()
        {
            IsActive = false;
            LastUpdateDate = DateTime.Now;
        }
    }
}
