using System;
using SimpleMessages.Domain.Interfaces;

namespace SimpleMessages.Domain.Services
{
    public class MessageGeneratorService:IMessageGeneratorService
    {
        private readonly IMessagesService _messagesService;

        public MessageGeneratorService(IMessagesService messagesService)
        {
            _messagesService = messagesService;
        }
        
        public void GenerateMessage()
        {
            _messagesService.AddMessage(Guid.NewGuid().ToString("N"));
        }
    }
}