using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using chat_room.web.Controllers.Extensions;
using chat_room.web.Controllers.Models;
using chat_room.web.Data;
using chat_room.web.Data.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace chat_room.web.Controllers
{
    [ApiController]
    public class ConversationsController : ControllerBase
    {
        private readonly ChatRoomContext _db;

        public ConversationsController(ChatRoomContext context)
        {
            _db = context;
        }
        
        [HttpGet]
        [Route("/conversations")]
        public async Task<ActionResult<IEnumerable<Conversation>>> GetConversations()
        {
            var userId = HttpContext.Session.GetInt64("userId");
            if (userId == null)
            {
                return Unauthorized();
            }
            
            return await _db.Conversations
                .Include(c => c.Messages)
                .Include(c => c.UserConversations)
                .Where(c => c.UserConversations.Any(uc => uc.UserId == userId))
                .Select(c => c.ToConversation())
                .ToListAsync();
        }
        
        [HttpGet]
        [Route("/conversations/{conversationId}")]
        public async Task<ActionResult<Conversation>> GetConversationById([FromRoute][Required]long conversationId)
        {
            var userId = HttpContext.Session.GetInt64("userId");
            if (userId == null)
            {
                return Unauthorized();
            }
            
            var conversation = await _db.Conversations.FindAsync(conversationId);
            if (conversation == null)
            {
                return NotFound();
            }

            return conversation.ToConversation();
        }
        
        [HttpPost]
        [Route("/conversations")]
        public async Task<ActionResult<Conversation>> AddConversation([FromBody]Conversation body)
        {
            var userId = HttpContext.Session.GetInt64("userId");
            if (userId == null)
            {
                return Unauthorized();
            }
            
            var entity = await _db.Conversations.AddAsync(body.ToConversation());
            await _db.SaveChangesAsync();
            return entity.Entity.ToConversation();
        }
    }
}