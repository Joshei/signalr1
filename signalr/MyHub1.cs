using System;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;




namespace SignalRChat
{
    public class ChatHub : Hub
    {
        //https://www.codeproject.com/Questions/233650/How-to-define-Global-veriable-in-Csharp-net
        private static int whoseturn = 0;
        private static int integer = 0;
        //private clients A_client = new clients();
        private static readonly List<clients> ClientList = new List<clients>();
        public override Task OnConnected()
        {
            return base.OnConnected();
        }
        public  void printthename()
        {
            string name = "";
            if (whoseturn == 0)
            {
                

                name = "Player one ";
                Clients.Client(ClientList[0].ConnectionId).printname(name);
                name = "Player two ";
                Clients.Client(ClientList[1].ConnectionId).printname2(name);
            }
            //second player
            if (whoseturn == 1)
            {
                

                name = "Player two ";
                Clients.Client(ClientList[0].ConnectionId).printname(name);
                name = "Player one ";
                Clients.Client(ClientList[1].ConnectionId).printname2(name);
            }
            if (whoseturn == 0)
            {
                whoseturn = 1;
            }
            else if (whoseturn == 1)
            {
                whoseturn = 0;
            }

        }
        public void register(string name1)
        {
            //A_Client = new clients { };
            //A_client.ConnectionId = Context.ConnectionId;
            
            clients A_Client = new clients();

            A_Client.ConnectionId = Context.ConnectionId;
            A_Client.Name = name1;
            //A_client.Name = name1;
            ClientList.Add(A_Client);

            if (integer == 0)
            {
                
                integer = integer + 1;
            }
            else if (integer == 1)
            {
               //Clients.Client(ClientList[1].ConnectionId).setinteger();
               //Clients.Client(ClientList[0].ConnectionId).setinteger();
            }
            
        }
        
    }

}