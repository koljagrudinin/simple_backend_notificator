using System.Collections.Generic;

namespace SimpleMessages.Domain.Interfaces
{
    public interface IMessagesService
    {
        IEnumerable<string> GetMessages();

        void AddMessage(string message);
    }
}