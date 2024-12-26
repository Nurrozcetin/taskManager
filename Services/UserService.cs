using TaskManager.DataAccessLayer.Repositories;
using TaskManager.Models;

namespace TaskManager.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> CreateUser(User user)
        {
            return await _userRepository.CreateUser(user);
        }

        public async Task<User> UpdateAsync(User user)
        {
            return await _userRepository.UpdateAsync(user);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _userRepository.DeleteAsync(id);
        }

        public async Task<User?> AuthenticateUser(string email, string password)
        {
            return await _userRepository.AuthenticateUser(email, password);
        }
    }
}
