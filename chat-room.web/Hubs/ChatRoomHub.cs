using chat_room.web.Data.Models;
using chat_room.web.Models;
using Microsoft.AspNetCore.SignalR;

namespace chat_room.web
{
    public class ChatRoomHub: Hub
    {
        public void SendToAll(string name, string message)
        {
            Clients.All.SendAsync("sendToAll", name, message);

            SendTest();
        }
        
        public void SendTest()
        {
            User user;
            using (var context = new ChatRoomContext())
            {
                user = context.Users.Find(1);
            }

            if (user != null)
            {
                Clients.All.SendAsync("sendToAll", user.Name, "Hello there!");
            }
        }
    }
}