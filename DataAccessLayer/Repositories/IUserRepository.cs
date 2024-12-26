using TaskManager.Models;

namespace TaskManager.DataAccessLayer.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> CreateUser(User user);
        Task<User> UpdateAsync(User user);
        Task<bool> DeleteAsync(int id);
        Task<User?> AuthenticateUser(string email, string password);
    }
}
