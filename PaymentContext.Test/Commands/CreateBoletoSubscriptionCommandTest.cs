using PaymentContext.Domain.Commands;
using Xunit;

namespace PaymentContext.Test.Commands
{
    public class CreateBoletoSubscriptionCommandTest
    {
        [Fact]
        public void ShouldReturnErrorWhenStudentHasActiveSubscription()
        {
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "";

            command.Validate();
            Assert.False(command.IsValid);
        }
    }
}
