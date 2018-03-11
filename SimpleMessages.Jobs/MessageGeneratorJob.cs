using FluentScheduler;
using SimpleMessages.Domain.Interfaces;

namespace SimpleMessages.Jobs
{
    public class MessageGeneratorJob : IJob
    {
        private readonly IMessageGeneratorService _messageGeneratorService;

        public MessageGeneratorJob(IMessageGeneratorService messageGeneratorService)
        {
            _messageGeneratorService = messageGeneratorService;
        }

        public void Execute()
        {
            GenerateMessage();
        }
        
        //TODO написать тест
        private void GenerateMessage()
        {
            _messageGeneratorService.GenerateMessage();
        }
    }
}