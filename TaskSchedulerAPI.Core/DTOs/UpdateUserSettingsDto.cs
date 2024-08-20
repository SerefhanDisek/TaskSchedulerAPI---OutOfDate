using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSchedulerAPI.Core.DTOs
{
    public class UpdateUserSettingsDto
    {
        public string Language { get; set; }
        public string Theme { get; set; }
        public bool ReceiveNotifications { get; set; }
    }
}
