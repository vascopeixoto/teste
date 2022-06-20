using Microsoft.AspNetCore.SignalR;
using MyTicketsPlugin.Shared.Domain;

namespace MyTicketsPlugin.Server.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message, string filename)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message, filename);
        }
    }
}
