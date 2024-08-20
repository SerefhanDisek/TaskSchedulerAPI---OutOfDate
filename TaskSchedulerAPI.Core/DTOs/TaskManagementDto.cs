using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSchedulerAPI.Core.DTOs
{
    public class TaskManagementDto
    {
        public int TaskId { get; set; }
        public string Action { get; set; }
    }
}
