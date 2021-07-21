using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Entities
{
    public class PayPalPayment : Payment
    {
        public PayPalPayment(string transactionCode, DateTime paidDate, DateTime expirationDate, decimal total, decimal totalPaid, string payer, Document document, Email email, Address address)
            : base(paidDate, expirationDate, total, totalPaid, payer, document, email, address)
        {
            TransactionCode = transactionCode;
        }

        public string TransactionCode { get; private set; }
    }
}
