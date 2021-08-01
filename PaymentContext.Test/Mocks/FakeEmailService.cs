using PaymentContext.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Test.Mocks
{
    public class FakeEmailService : IEmailService
    {
        public void SendSubscriptionEmail(string toName, string toEmail)
        {
        }
    }
}
