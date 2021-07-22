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
        public StudentTest()
        {
            CreateValidStudent();
        }

        public Student ValidStudent { get; set; }

        private void CreateValidStudent()
        {
            var name = new Name("Kevin", "Guedes");
            var email = new Email("hello@gmail.com");
            var document = new Document("98989698368", EDocumentType.CPF);

            ValidStudent = new Student(name, document, email);
        }

        [Fact]
        public void ShouldReturnErrorWhenStudentNameIsInvalid()
        {
            var name = new Name("Kn", "Guedes");
            var email = new Email("hello@gmail.com");
            var document = new Document("98989698368", EDocumentType.CPF);

            var student = new Student(name, document, email);

            Assert.False(student.IsValid);
        }
    }
}
