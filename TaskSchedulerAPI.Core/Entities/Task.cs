namespace TaskSchedulerAPI.Core.Entities
{
    public class Task
    {
        public static Task CompletedTask { get; set; }
        public int Id { get; set; }  
        public string Title { get; set; }  
        public string Description { get; set; }  
        public DateTime DueDate { get; set; }  
        public bool IsCompleted { get; set; }  
        public ICollection<UserTask> UserTasks { get; set; }  
    }

}
