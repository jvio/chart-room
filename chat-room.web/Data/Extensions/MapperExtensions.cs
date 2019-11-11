using System.Linq;
using chat_room.web.Data.Models;

namespace chat_room.web.Data.Extensions
{
    public static class MapperExtensions
    {
        public static Conversation ToConversation(this Controllers.Models.Conversation c)
        {
            var conversation = new Conversation
            {
                ConversationId = c.ConversationId
            };

            conversation.UserConversations.AddRange(
                c.Users.Select(u => new UserConversation
                {
                    ConversationId = c.ConversationId, UserId = u
                }));
            
            
            conversation.Messages.AddRange(c.Messages.Select(m => m.ToMessage()));

            return conversation;
        }

        public static User ToUser(this Controllers.Models.User u)
        {
            return new User
            {
                UserId = u.UserId,
                Username = u.Username,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Phone = u.Phone,
                Age = u.Age,
                Blood = u.Blood,
                IsDoctor = u.IsDoctor
            };
        }
        
        public static Message ToMessage(this Controllers.Models.Message m)
        {
            return new Message
            {
                MessageId = m.MessageId,
                UserId = m.UserId,
                Content =  m.Content,
                SentDate = m.SentDate
            };
        }
    }
}