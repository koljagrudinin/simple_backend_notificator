using System.Collections.Concurrent;
using System.Collections.Generic;
using SimpleMessages.Domain.Interfaces;

namespace SimpleMessages.Domain.Services
{
    public class MessagesService : IMessagesService
    {
        private readonly INotificationService _notificationService;

        public MessagesService(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        private readonly ConcurrentQueue<string> _messagesList = new ConcurrentQueue<string>();

        public IEnumerable<string> GetMessages()
        {
            return _messagesList;
        }

        public void AddMessage(string message)
        {
            _messagesList.Enqueue(message);

            _notificationService.SendMessageToAllClients(message);
        }
    }
}