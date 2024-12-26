
using Microsoft.EntityFrameworkCore;
using Task = TaskManager.Models.Task; 

namespace TaskManager.DataAccessLayer.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Task> CreateTask(Task task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<bool> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return false;

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Task>> GetAllTask()
        {
            return await _context.Tasks.Include(t => t.User).ToListAsync();
        }

        public async Task<Task?> GetByIdTask(int id)
        {
            return await _context.Tasks.Include(t => t.User).FirstOrDefaultAsync(t => t.ID == id);
        }

        public async Task<Task> UpdateTask(Task task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
            return task;
        }
    }
}
