namespace AngularSignalWithAPI6.API.Hubs
{
    public interface IMessageHubClient
    {
        Task SendNewsToUser(List<string> message);
    }
}
