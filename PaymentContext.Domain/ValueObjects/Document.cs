using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, EDocumentType type)
        {
            Number = number;
            Type = type;

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsTrue(Validate(), "Document.Number", "Invalid document")
            );
        }

        public string Number { get; set; }

        public EDocumentType Type { get; set; }

        private bool Validate()
        {
            if (Type == EDocumentType.CNPJ && Number.Length == 14)
                return true; //logic to validate cnpj

            if (Type == EDocumentType.CPF && Number.Length == 11)
                return true; //logic to validate cpf

            return false;
        }
    }
}
