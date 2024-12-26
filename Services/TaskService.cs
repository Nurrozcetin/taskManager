
using TaskManager.DataAccessLayer.Repositories;
using Task = TaskManager.Models.Task;

namespace TaskManager.Services

{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<Task> AddTask(Task task)
        {
            return await _taskRepository.CreateTask(task);
        }

        public async Task<bool> DeleteTask(int id)
        {
            return await _taskRepository.DeleteTask(id);
        }

        public async Task<IEnumerable<TaskManager.Models.Task>> GetAllTask()
        {
            return await _taskRepository.GetAllTask();
        }

        public async Task<TaskManager.Models.Task?> GetByIdTask(int id)
        {
            return await _taskRepository.GetByIdTask(id);
        }

        public async Task<TaskManager.Models.Task> UpdateTask(TaskManager.Models.Task task)
        {
            return await _taskRepository.UpdateTask(task);
        }
    }
}
