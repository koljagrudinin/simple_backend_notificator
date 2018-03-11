using Moq;
using SimpleMessages.Domain.Interfaces;
using SimpleMessages.Domain.Services;
using Xunit;

namespace SimpleMessages.Domain.Tests
{
    public class MessageGeneratorServiceTests
    {
        private readonly Mock<IMessagesService> _messagesService;
        private readonly MessageGeneratorService _service;

        public MessageGeneratorServiceTests()
        {
            _messagesService = new Mock<IMessagesService>();
            _service = new MessageGeneratorService(_messagesService.Object);
        }

        [Fact]
        public void GenerateMessage_CallsAddMessageWithAnyString()
        {
            _service.GenerateMessage();

            _messagesService.Verify(q => q.AddMessage(It.IsAny<string>()), Times.Once);
        }
           
    }
}