using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSchedulerAPI.Core.Entities
{
    public class Task
    {
        public int Id { get; set; }  // Task ID, primary key
        public string Title { get; set; }  // Task başlığı
        public string Description { get; set; }  // Task açıklaması
        public DateTime DueDate { get; set; }  // Task'ın son teslim tarihi
        public bool IsCompleted { get; set; }  // Task'ın tamamlanma durumu
        public ICollection<UserTask> UserTasks { get; set; }  // Task'ın hangi kullanıcıya ait olduğu bilgisi
    }

}
