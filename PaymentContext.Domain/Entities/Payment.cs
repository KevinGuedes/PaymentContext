using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;
using System;

namespace PaymentContext.Domain.Entities
{
    public abstract class Payment : Entity
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

            AddNotifications(new Contract<Payment>()
                .Requires()
                .IsLowerOrEqualsThan(0, Total, "Payment.Total", "Total must not be 0")
                .IsGreaterOrEqualsThan(Total, TotalPaid, "Payment.TotalPaid", "Paid value is lower than the total value")
            );
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
