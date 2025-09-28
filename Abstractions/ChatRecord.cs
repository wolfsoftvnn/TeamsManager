using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamsManager.Abstractions
{
    public sealed class ChatRecord
    {
        public bool Selected { get; set; }    // bạn có thể dùng để gửi tin nhắn theo nhóm đã chọn
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string Type { get; set; } = "";
    }
}
