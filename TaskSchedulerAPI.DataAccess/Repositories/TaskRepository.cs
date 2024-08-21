using Microsoft.EntityFrameworkCore;
using TaskSchedulerAPI.DataAccess.Interfaces;
using Task = TaskSchedulerAPI.Core.Entities.Task;

namespace TaskSchedulerAPI.DataAccess.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskSchedulerDbContext _context;

        public TaskRepository(TaskSchedulerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Task>> GetAllTasksAsync()
        {
            return await _context.Tasks.Include(t => t.UserTasks).ToListAsync();
        }

        public async Task<Task> GetTaskByIdAsync(int taskId)
        {
            return await _context.Tasks.Include(t => t.UserTasks)
                .FirstOrDefaultAsync(t => t.Id == taskId);
        }

        public async Task<bool> AddAsync(Task task)
        {
            _context.Tasks.Add(task);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Task>> GetUnassignedTasksAsync()
        {
            return await _context.Tasks
                .Where(t => !t.IsCompleted && !t.UserTasks.Any())
                .ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public Task<IEnumerable<Task>> GetUncompletedTasksAsync()
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task UpdateTaskAsync(Task task)
        {
            throw new NotImplementedException();
        }
    }
}
