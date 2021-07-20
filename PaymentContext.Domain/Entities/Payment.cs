using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Entities
{
    public abstract class Payment
    {
        protected Payment(DateTime paidDate, DateTime expirationDate, decimal total, decimal totalPaid, string payer, string document, string address, string email)
        {
            Id = Guid.NewGuid().ToString();
            PaidDate = paidDate;
            ExpirationDate = expirationDate;
            Total = total;
            TotalPaid = totalPaid;
            Payer = payer;
            Document = document;
            Address = address;
            Email = email;
        }

        public string Id { get; private set; }

        public DateTime PaidDate { get; private set; }

        public DateTime ExpirationDate { get; private set; }

        public decimal Total { get; private set; }

        public decimal TotalPaid { get; private set; }

        public string Payer { get; private set; }

        public string Document { get; private set; }

        public string Address { get; private set; }

        public string Email { get; private set; }
    }
}
