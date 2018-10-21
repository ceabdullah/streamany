using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace streamany.Hubs
{
    public class EchoHub : Hub
    {
        //you're going to invoke this method from the client app
        public void Echo(string message)
        {
            //you're going to configure your client app to listen for this
            Clients.All.SendAsync("Send", message);
        }
    }
}
