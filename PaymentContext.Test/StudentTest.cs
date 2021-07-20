using PaymentContext.Domain.Entities;
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
            var student = new Student("Kevin", "Guedes", "123456789", "hello@gmail.com");


        }

    }
}
