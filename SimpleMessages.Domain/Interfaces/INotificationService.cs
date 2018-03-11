namespace SimpleMessages.Domain.Interfaces
{
    public interface INotificationService
    {
        void SendMessageToAllClients(string message);
    }
}