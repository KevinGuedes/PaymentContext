using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PaymentContext.Test.Entities
{
    public class StudentTest
    {
        private readonly Name _name;
        private readonly Email _email;
        private readonly Document _document;
        private readonly Address _address;
        private readonly Student _student;
        private readonly PayPalPayment _payPalPayment;
        private readonly Subscription _subscription;

        public StudentTest()
        {
            _name = new Name("Bruce", "Wayne");
            _document = new Document("35111507795", EDocumentType.CPF);
            _email = new Email("batman@dc.com");
            _address = new Address("Rua 1", "1234", "Bairro Legal", "Gotham", "SP", "BR", "13400000");
            _student = new Student(_name, _document, _email);
            _payPalPayment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(15), 10, 10, "WAYNE Corp.", _document, _email, _address); ;
            _subscription = new Subscription(null);
        }

        [Fact]
        public void ShouldReturnErrorWhenStudentHasActiveSubscription()
        {
            _subscription.AddPayment(_payPalPayment);
            _student.AddSubscription(_subscription);

           _student.AddSubscription(_subscription);

            Assert.False(_student.IsValid);
        }

        [Fact]
        public void ShouldNotReturnErrorWhenStudentDoesNotHaveActiveSubscription()
        {
            _subscription.AddPayment(_payPalPayment);

            _student.AddSubscription(_subscription);

            Assert.True(_student.IsValid);
        }

        [Fact]
        public void ShouldReturnErrorWhenNewSubscriptionHasNoPayments()
        {
            _student.AddSubscription(_subscription);

            Assert.False(_student.IsValid);
        }
    }
}
