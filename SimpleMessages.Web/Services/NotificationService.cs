using Microsoft.AspNetCore.SignalR;
using SimpleMessages.Domain.Interfaces;
using SimpleMessages.Web.Hubs;

namespace SimpleMessages.Web.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IHubContext<MessagesHub> _hubContext;

        public NotificationService(IHubContext<MessagesHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public void SendMessageToAllClients(string message)
        {
            _hubContext.Clients.All.InvokeAsync("Send", message);
        }
    }
}