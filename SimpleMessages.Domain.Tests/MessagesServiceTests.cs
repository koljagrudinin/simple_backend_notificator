using Moq;
using SimpleMessages.Domain.Interfaces;
using SimpleMessages.Domain.Services;
using Xunit;

namespace SimpleMessages.Domain.Tests
{
    public class MessagesServiceTests
    {
        private MessagesService _service;
        private Mock<INotificationService> _messageSender;

        public MessagesServiceTests()
        {
            _messageSender = new Mock<INotificationService>();
            _service = new MessagesService(_messageSender.Object);
        }

        [Fact]
        public void AddMessage_ForAnyRequest_CallsNotificationService()
        {
            _service.AddMessage("test");

            _messageSender.Verify(q => q.SendMessageToAllClients("test"), Times.Once);
        }
    }
}