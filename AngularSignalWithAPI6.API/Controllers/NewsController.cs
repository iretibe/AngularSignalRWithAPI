using AngularSignalWithAPI6.API.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace AngularSignalWithAPI6.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IHubContext<MessageHubClient, IMessageHubClient> _messageHub;

        public NewsController(IHubContext<MessageHubClient, IMessageHubClient> messageHub)
        {
            _messageHub = messageHub;
        }

        [HttpPost]
        [Route("News")]
        public string News()
        {
            List<string> news = new List<string>();

            news.Add("You've got 75% in Maths");
            news.Add("You've got 87% in Science");
            news.Add("You've got 55% in Economy");
            news.Add("Your total point is 72.33%, therefore you have passed...");
            _messageHub.Clients.All.SendNewsToUser(news);
            return "Data sent successfully to all users!";
        }
    }
}
