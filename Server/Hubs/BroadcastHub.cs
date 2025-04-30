using Microsoft.AspNetCore.SignalR;

namespace BlazorSignalR.Server.Hubs
{
    public class BroadcastHub : Hub
    {
        public async Task SendMessage()
        {
            await Clients.All.SendAsync("RecieveMessage");
        }

    }
}
