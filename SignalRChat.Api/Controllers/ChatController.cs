using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRChat.Api.Services.Dto;
using SignalRChat.Api.Services.Hubs;

namespace SignalRChat.Api.Controllers
{
    [Route("api/chat")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;
      
        public ChatController(IHubContext<ChatHub> hubContext)
      
        {
            _hubContext = hubContext;
        }

        [Route("send")]                                          
        [HttpPost]
        public async Task< IActionResult> SendRequest([FromBody] MessageDto msg)
        {
         //   await AddToGroup(msg.User, msg.GroupName);
           //await  _hubContext.Clients.Group(msg.GroupName) .SendAsync("ReceiveOne", msg.User, msg.Message);
           await  _hubContext.Clients.All.SendAsync("ReceiveOne", msg.User, msg.Message);
            return Ok();
        }

        //private async Task AddToGroup(string user,string groupName)
        //{
            
        //    await _hubContext.Groups.AddToGroupAsync(user, groupName);

        //    await _hubContext.Clients.Group(groupName).SendAsync("ReceiveOne", user, $"{user} has joined the group {groupName}.");
        //}
    }
}
