using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Entities
{
    public abstract class Payment
    {
        protected Payment(DateTime paidDate, DateTime expirationDate, decimal total, decimal totalPaid, string payer, Document document, Email email, Address address)
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
            PaidDate = paidDate;
            ExpirationDate = expirationDate;
            Total = total;
            TotalPaid = totalPaid;
            Payer = payer;
            Document = document;
            Email = email;
            Address = address;
        }

        public string Number { get; private set; }

        public DateTime PaidDate { get; private set; }

        public DateTime ExpirationDate { get; private set; }

        public decimal Total { get; private set; }

        public decimal TotalPaid { get; private set; }

        public string Payer { get; private set; }

        public Document Document { get; private set; }

        public Email Email { get; private set; }
        
        public Address Address { get; private set; }
    }
}
