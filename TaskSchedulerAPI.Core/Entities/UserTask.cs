using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSchedulerAPI.Core.Entities
{
    public class UserTask
    {
        public int UserId { get; set; }  // User ID, foreign key
        public User User { get; set; }  // User entity'si ile ilişki

        public int TaskId { get; set; }  // Task ID, foreign key
        public Task Task { get; set; }  // Task entity'si ile ilişki

        public DateTime AssignedDate { get; set; }  // Task'ın kullanıcıya atandığı tarih
    }

}
