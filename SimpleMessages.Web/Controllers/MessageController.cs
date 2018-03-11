using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SimpleMessages.Domain.Interfaces;
using SimpleMessages.Web.Hubs;

namespace SimpleMessages.Web.Controllers
{
    [Route("api/messages")]
    public class MessageController : Controller
    {
        private IMessagesService _messagesService;

        public MessageController(IHubContext<MessagesHub> loopyHubContext, IMessagesService messagesService)
        {
            _messagesService = messagesService;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _messagesService.GetMessages();
        }
    }
}