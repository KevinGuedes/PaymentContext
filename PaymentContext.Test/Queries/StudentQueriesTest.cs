using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PaymentContext.Test.Queries
{
    public class StudentQueriesTest
    {
        private IList<Student> _students;

        public StudentQueriesTest()
        {
            _students = new List<Student>();
            for (var i = 0; i <= 10; i++)
            {
                _students.Add(new Student(
                    new Name("Aluno", i.ToString()),
                    new Document("1111111111" + i.ToString(), EDocumentType.CPF),
                    new Email(i.ToString() + "@balta.io")
                ));
            }
        }

        [Fact]
        public void ShouldReturnNullWhenDocumentDoesNotExist()
        {
            var query = StudentQueries.GetStudentInfo("12345678911");
            var student = _students.AsQueryable().Where(query).FirstOrDefault();

            Assert.Null(student);
        }

        [Fact]
        public void ShouldReturnStudentWhenDocumentExists()
        {
            var query = StudentQueries.GetStudentInfo("11111111111");
            var student = _students.AsQueryable().Where(query).FirstOrDefault();

            Assert.NotNull(student);
        }
    }
}
