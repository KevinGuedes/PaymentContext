namespace PaymentContext.Domain.Services
{
    public interface IEmailService
    {
        void SendSubscriptionEmail(string toName, string toEmail);
    }
}
