using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Entities
{
    public class BoletoPayment : Payment
    {
        public BoletoPayment(string barCode, string number, DateTime paidDate, DateTime expirationDate, decimal total, decimal totalPaid, string payer, string document, string address, string email)
            :base(paidDate, expirationDate, total, totalPaid, payer, document, address, email)
        {
            BarCode = barCode;
            Number = number;
        }

        public string BarCode { get; private set; }

        public string Number { get; private set; }
    }
}
