using Microsoft.EntityFrameworkCore;
using TaskSchedulerAPI.Core.Entities;
using Task = TaskSchedulerAPI.Core.Entities.Task;


namespace TaskSchedulerAPI.DataAccess
{
    public class TaskSchedulerDbContext : DbContext
    {
        public TaskSchedulerDbContext(DbContextOptions<TaskSchedulerDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }  // User tablosu
        public DbSet<Task> Tasks { get; set; }  // Task tablosu
        public DbSet<UserTask> UserTasks { get; set; }  // UserTask tablosu

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // UserTask için composite key tanımlama (UserId, TaskId)
            modelBuilder.Entity<UserTask>()
                .HasKey(ut => new { ut.UserId, ut.TaskId });

            // User ve Task arasında çoktan-çoğa (many-to-many) ilişkiyi tanımlama
            modelBuilder.Entity<UserTask>()
                .HasOne(ut => ut.User)
                .WithMany(u => u.UserTasks)
                .HasForeignKey(ut => ut.UserId);

            modelBuilder.Entity<UserTask>()
                .HasOne(ut => ut.Task)
                .WithMany(t => t.UserTasks)
                .HasForeignKey(ut => ut.TaskId);
        }
    }

}
