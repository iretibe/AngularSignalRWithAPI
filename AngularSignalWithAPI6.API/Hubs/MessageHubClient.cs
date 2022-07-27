using Microsoft.AspNetCore.SignalR;

namespace AngularSignalWithAPI6.API.Hubs
{
    public class MessageHubClient : Hub<IMessageHubClient>
    {
        public async Task SendNewsToUser(List<string> message)
        {
            await Clients.All.SendNewsToUser(message);
        }
    }
}
