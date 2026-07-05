using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjectManagementAPI.Data;
using ProjectManagementAPI.Models;

namespace ProjectManagementAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> ValidateUserAsync(
            string userName,
            string password)
        {
            var users = await _context.Users
                .FromSqlRaw(
                    "EXEC Login_ValidateUser @UserName, @Password",
                    new SqlParameter("@UserName", userName),
                    new SqlParameter("@Password", password))
                .AsNoTracking()
                .ToListAsync();

            return users.FirstOrDefault();
        }

        public async Task<User?> GetUserDetailsAsync(
           string userName)
        {
            var users = await _context.Users
                .FromSqlRaw(
                    "EXEC Login_GetUserDetails @UserName",
                    new SqlParameter("@UserName", userName))
                .AsNoTracking()
                .ToListAsync();

            return users.FirstOrDefault();
        }
        public async Task<List<User>> GetAllUsersAsync()
        {
            var users = await _context.Users
                .FromSqlRaw("EXEC User_GetAll")
                .AsNoTracking()
                .ToListAsync();

            return users;
        }

        public async Task<User?> GetUserByIdAsync(int userId)
        {
            var users = await _context.Users
                .FromSqlRaw(
                    "EXEC User_GetById @UserId",
                    new SqlParameter("@UserId", userId))
                .AsNoTracking()
                .ToListAsync();

            return users.FirstOrDefault();
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC User_Add @UserName,@FullName,@Email,@PasswordHash,@Role,@CreatedBy",
                new SqlParameter("@UserName", user.UserName),
                new SqlParameter("@FullName", user.FullName),
                new SqlParameter("@Email", user.Email),
                new SqlParameter("@PasswordHash", user.PasswordHash),
                new SqlParameter("@Role", user.Role),
                new SqlParameter("@CreatedBy", user.CreatedBy)
            );
        }

        public async Task UpdateUserAsync(User user)
        {
            await _context.Database.ExecuteSqlRawAsync(
                @"EXEC User_Update
            @UserId,
            @UserName,
            @FullName,
            @Email,
            @PasswordHash,
            @Role,
            @IsActive",

                new SqlParameter("@UserId", user.UserId),
                new SqlParameter("@UserName", user.UserName),
                new SqlParameter("@FullName", user.FullName),
                new SqlParameter("@Email", user.Email),
                new SqlParameter("@PasswordHash",
                    string.IsNullOrWhiteSpace(user.PasswordHash)
                        ? DBNull.Value
                        : user.PasswordHash),
                new SqlParameter("@Role", user.Role),
                new SqlParameter("@IsActive", user.IsActive)
            );
        }
        public async Task DeleteUserAsync(int userId)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC User_Delete @UserId",
                new SqlParameter("@UserId", userId)
            );
        }

    }
}