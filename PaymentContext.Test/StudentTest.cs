using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PaymentContext.Test
{
    public class StudentTest
    {
        [Fact]
        public void Test1()
        {
            var name = new Name("Kevin", "Guedes");
            var email = new Email("hello@gmail.com");
            var document = new Document("123456789", EDocumentType.CPF);

            var student = new Student(name, document, email);
            //student.IsValid

            foreach(var notification in name.Notifications)
            {
            }
        }
    }
}
