namespace DemidovPark.Hubs
{
    using Microsoft.AspNetCore.SignalR;
    using System.Threading.Tasks;

    public class AskingHub : Hub
    {
        public async Task NewAsk()
        {
            await Clients.All.SendAsync("NewAskReceived");
        }
    }
}