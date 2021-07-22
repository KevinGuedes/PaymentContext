using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PaymentContext.Test.ValueObjects
{
    public class DocumentTest
    {
        //Red, Green, Refactor

        [Fact]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            var document = new Document("123", EDocumentType.CNPJ);

            Assert.False(document.IsValid);
        }

        [Fact]
        public void ShouldReturnSuccessWhenCNPJIsValid()
        {
            var document = new Document("01562124000123", EDocumentType.CNPJ);

            Assert.True(document.IsValid);
        }

        [Theory]
        [InlineData("123")]
        [InlineData("321")]
        public void ShouldReturnErrorWhenCPFIsInvalid(string cpf)
        {
            var document = new Document(cpf, EDocumentType.CPF);

            Assert.False(document.IsValid);
        }

        [Fact]
        public void ShouldReturnSuccessWhenCPFIsValid()
        {
            var document = new Document("68963236987", EDocumentType.CPF);

            Assert.True(document.IsValid);
        }
    }
}
