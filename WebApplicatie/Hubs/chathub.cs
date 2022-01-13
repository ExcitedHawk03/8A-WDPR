using Microsoft.AspNetCore.SignalR;

namespace WebApplicatie.Hubs{
    public class chatHub: Hub
    {
        public string GetConnectionId() =>
            Context.ConnectionId;
        
    }
}