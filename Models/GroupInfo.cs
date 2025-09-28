using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamsManager.Models
{
    public sealed class GroupInfo
    {
        public string IdGroup { get; set; } = "";
        public string Name { get; set; } = "";
        /// <summary>
        /// Dự phòng: chat / team / channel / unknown...
        /// </summary>
        public string? Type { get; set; }
        public bool IsSelected { get; set; }
    }
}
