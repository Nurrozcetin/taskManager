using Task = TaskManager.Models.Task;
namespace TaskManager.DataAccessLayer.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Task>> GetAllTask();
        Task<Task?> GetByIdTask(int id);
        Task<Task> CreateTask(Task task);
        Task<Task> UpdateTask(Task task);
        Task<bool> DeleteTask(int id);
    }
}
