using Task = TaskManager.Models.Task;
namespace TaskManager.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<Task>> GetAllTask();
        Task<Task?> GetByIdTask(int id);
        Task<Task> AddTask(Task task);
        Task<Task> UpdateTask(Task task);
        Task<bool> DeleteTask(int id);

    }
}
