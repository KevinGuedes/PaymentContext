using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PaymentContext.Test.Handlers
{
    public class SubscriptionHandlerTests
    {
        [Fact]
        public void CommandIsInvalidWhenDocumentIsAlreadyInUse()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand
            {
                FirstName = "Bruce",
                LastName = "Wayne",
                Document = "99999999999",
                Email = "bruce@domain.com",
                BarCode = "123456789",
                BoletoNumber = "1234654987",
                PaymentNumber = "123121",
                PaidDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddMonths(1),
                Total = 60,
                TotalPaid = 60,
                Payer = "WAYNE CORP",
                PayerDocument = "12345678911",
                PayerDocumentType = EDocumentType.CPF,
                PayerEmail = "batman@dc.com",
                Street = "asdas",
                Number = "asdd",
                Neighborhood = "asdasd",
                City = "as",
                State = "as",
                Country = "as",
                ZipCode = "12345678"
            };

            handler.Handle(command);
            Assert.Contains(handler.Notifications, notification => notification.Key == "Document");
            Assert.False(handler.IsValid);
        }

        [Fact]
        public void CommandIsInvalidWhenEmailIsAlreadyInUse()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand
            {
                FirstName = "Bruce",
                LastName = "Wayne",
                Document = "99999999997",
                Email = "name@domain.com",
                BarCode = "123456789",
                BoletoNumber = "1234654987",
                PaymentNumber = "123121",
                PaidDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddMonths(1),
                Total = 60,
                TotalPaid = 60,
                Payer = "WAYNE CORP",
                PayerDocument = "12345678911",
                PayerDocumentType = EDocumentType.CPF,
                PayerEmail = "batman@dc.com",
                Street = "asdas",
                Number = "asdd",
                Neighborhood = "asdasd",
                City = "as",
                State = "as",
                Country = "as",
                ZipCode = "12345678"
            };

            handler.Handle(command);
            Assert.Contains(handler.Notifications, notification => notification.Key == "Email");
            Assert.False(handler.IsValid);
        }
    }
}
