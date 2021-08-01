using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Entities
{
    public class BoletoPayment : Payment
    {
        public BoletoPayment(string barCode, string boletoNumber, DateTime paidDate, DateTime expirationDate, decimal total, decimal totalPaid, string payer, Document document, Email email, Address address)
            :base(paidDate, expirationDate, total, totalPaid, payer, document, email, address)
        {
            BarCode = barCode;
            BoletoNumber = boletoNumber;
        }

        public string BarCode { get; private set; }

        public string BoletoNumber { get; private set; }
    }
}
