using ProjectManagementAPI.Models;

namespace ProjectManagementAPI.Repositories
{
    public interface IUserRepository
    {
        Task<User?> ValidateUserAsync(string userName, string password);

        Task<User?> GetUserDetailsAsync(string userName);

        Task<List<User>> GetAllUsersAsync();

        Task<User?> GetUserByIdAsync(int userId);

        Task AddUserAsync(User user);

        Task UpdateUserAsync(User user);

        Task DeleteUserAsync(int userId);
    }
}