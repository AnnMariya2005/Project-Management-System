using ProjectManagementAPI.DTOs;
using ProjectManagementAPI.Models;
using ProjectManagementAPI.Repositories;


namespace ProjectManagementAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
        {
            var user = await _userRepository.ValidateUserAsync(
                    request.UserName,
                    request.Password);

            if (user == null)
            {
                return new LoginResponseDto
                {
                    Success = false,
                    Message = "Invalid username or password"
                };
            }

            return new LoginResponseDto
            {
                Success = true,
                Message = "Login successful",
                Role = user.Role,
                Token = "DummyToken"
            };
        }
        public async Task<List<UserDetailsDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();

            return users.Select(u => new UserDetailsDto
            {
                UserId = u.UserId,
                UserName = u.UserName,
                FullName = u.FullName,
                Email = u.Email,
                Role = u.Role,
                IsActive = u.IsActive
            }).ToList();
        }

        public async Task<UserDetailsDto?> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);

            if (user == null)
                return null;

            return new UserDetailsDto
            {
                UserId = user.UserId,
                UserName = user.UserName,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role,
                IsActive = user.IsActive
            };
        }

        public async Task AddUserAsync(AddUserDto dto)
        {
            var user = new User
            {
                UserName = dto.UserName,
                FullName = dto.FullName,
                Email = dto.Email,
                PasswordHash = dto.PasswordHash,
                Role = dto.Role,
                CreatedBy = dto.CreatedBy
            };

            await _userRepository.AddUserAsync(user);
        }

        public async Task UpdateUserAsync(UpdateUserDto dto)
        {
            var existingUser = await _userRepository.GetUserByIdAsync(dto.UserId);

            if (existingUser == null)
                throw new Exception("User not found");

            existingUser.UserName = dto.UserName;
            existingUser.FullName = dto.FullName;
            existingUser.Email = dto.Email;
            existingUser.Role = dto.Role;
            existingUser.IsActive = dto.IsActive;

            if (!string.IsNullOrWhiteSpace(dto.PasswordHash))
                existingUser.PasswordHash = dto.PasswordHash;

            await _userRepository.UpdateUserAsync(existingUser);
        }
        public async Task DeleteUserAsync(int userId)
        {
            await _userRepository.DeleteUserAsync(userId);
        }

    }
}