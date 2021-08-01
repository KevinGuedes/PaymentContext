using PaymentContext.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace PaymentContext.Domain.Queries
{
    public static class StudentQueries
    {
        public static Expression<Func<Student, bool>> GetStudentInfo(string document)
        {
            return student => student.Document.Number == document;
            // _context.Students.Where(GetStudentInfo()).ToList
        }
    }
}
