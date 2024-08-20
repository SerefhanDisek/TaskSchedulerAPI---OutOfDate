using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSchedulerAPI.Core.DTOs
{
    public class ScheduleTaskDto
    {
        public string TaskName { get; set; }
        public string CronExpression { get; set; } // Hangfire için kullanılan Cron ifadesi
        public string TaskDetails { get; set; }    // Görev hakkında ek bilgiler
    }

}
