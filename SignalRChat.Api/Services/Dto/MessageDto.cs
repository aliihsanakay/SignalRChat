using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChat.Api.Services.Dto
{
    public class MessageDto
    {
        public string User { get; set; }
        public string Message{ get; set; }
        //public string GroupName { get; set; }
    }
}
