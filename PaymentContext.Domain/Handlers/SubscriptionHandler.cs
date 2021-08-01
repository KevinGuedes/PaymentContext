using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;
using System;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler : Notifiable<Notification>, IHandler<CreateBoletoSubscriptionCommand>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IEmailService _emailService;

        public SubscriptionHandler(IStudentRepository studentRepository, IEmailService emailService)
        {
            _studentRepository = studentRepository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            command.Validate();
            if (!command.IsValid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Invalid command");
            }

            AddNotifications(new Contract<Notification>()
              .Requires()
              .IsFalse(_studentRepository.DocumentExists(command.Document), "Document", "Document already in use")
            );

            AddNotifications(new Contract<Notification>()
             .Requires()
             .IsFalse(_studentRepository.EmailExists(command.Email), "Email", "Email already in use")
           );

            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);

            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new BoletoPayment(
                 command.BarCode,
                 command.BoletoNumber,
                 command.PaidDate,
                 command.ExpireDate,
                 command.Total,
                 command.TotalPaid,
                 command.Payer,
                 new Document(command.PayerDocument, command.PayerDocumentType),
                 email,
                 address
            );

            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            AddNotifications(name, document, email, address, student, subscription, payment);

            if (!IsValid)
                return new CommandResult(false, "Failed to create subscription");

            _studentRepository.CreateSubscription(student);

            _emailService.SendSubscriptionEmail(student.Name.ToString(), student.Email.Address);

            return new CommandResult(true, "Subscription successfully finished");
        }
    }
}
