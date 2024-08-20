using TaskSchedulerAPI.Business.Interfaces;
using TaskSchedulerAPI.Core.DTOs;
using TaskSchedulerAPI.DataAccess.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Logging;
using TaskSchedulerAPI.Core.Entities;
using Task = TaskSchedulerAPI.Core.Entities.Task;

namespace TaskSchedulerAPI.Business.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<TaskService> _logger;

        public TaskService(ITaskRepository taskRepository, IUserRepository userRepository, IMapper mapper, ILogger<TaskService> logger)
        {
            _taskRepository = taskRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<TaskDto>> GetAllTasksAsync()
        {
            var tasks = await _taskRepository.GetAllTasksAsync();
            return _mapper.Map<IEnumerable<TaskDto>>(tasks);
        }

        public async Task<bool> CreateTaskAsync(TaskCreateDto taskDto)
        {
            var task = _mapper.Map<Task>(taskDto);
            return await _taskRepository.AddAsync(task);
        }

        public async System.Threading.Tasks.Task AssignTasksToUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            var tasks = await _taskRepository.GetUnassignedTasksAsync(); 

            if (users.Any() && tasks.Any())
            {
                int userCount = users.Count();
                int taskIndex = 0;

                foreach (var task in tasks)
                {
                    var assignedUser = users.ElementAt(taskIndex % userCount);
                    task.UserTasks.Add(new UserTask
                    {
                        UserId = assignedUser.Id,
                        TaskId = task.Id,
                        AssignedDate = DateTime.UtcNow
                    });

                    taskIndex++;

                    _logger.LogInformation($"Task {task.Id} is assigned to User {assignedUser.Id}.");
                }

                await _taskRepository.SaveChangesAsync(); 
            }
        }

        Task<OperationResult> ITaskService.CreateTaskAsync(TaskCreateDto taskCreateDto)
        {
            throw new NotImplementedException();
        }

        public Task<TaskDto> GetTaskByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> UpdateTaskAsync(int id, TaskUpdateDto taskUpdateDto)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> DeleteTaskAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> ManageTaskAsync(TaskManagementDto taskManagementDto)
        {
            throw new NotImplementedException();
        }
    }
}


/*       Task<OperationResult> CreateTaskAsync(TaskCreateDto taskCreateDto);
        Task<IEnumerable<TaskDto>> GetAllTasksAsync();
        Task<TaskDto> GetTaskByIdAsync(int id);
        Task<OperationResult> UpdateTaskAsync(int id, TaskUpdateDto taskUpdateDto);
        Task<OperationResult> DeleteTaskAsync(int id);*/