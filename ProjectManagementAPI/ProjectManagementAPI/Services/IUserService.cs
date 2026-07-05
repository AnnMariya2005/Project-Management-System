using ProjectManagementAPI.DTOs;

namespace ProjectManagementAPI.Services
{
    public interface IUserService
    {
        Task<LoginResponseDto> LoginAsync(LoginRequestDto request);

        Task<List<UserDetailsDto>> GetAllUsersAsync();

        Task<UserDetailsDto?> GetUserByIdAsync(int userId);

        Task AddUserAsync(AddUserDto user);

        Task UpdateUserAsync(UpdateUserDto user);

        Task DeleteUserAsync(int userId);
    }
}