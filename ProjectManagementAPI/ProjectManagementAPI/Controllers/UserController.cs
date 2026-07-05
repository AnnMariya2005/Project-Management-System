using Microsoft.AspNetCore.Mvc;
using ProjectManagementAPI.DTOs;
using ProjectManagementAPI.Services;

namespace ProjectManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserDto dto)
        {
            await _userService.AddUserAsync(dto);

            return Ok(new
            {
                success = true,
                message = "User added successfully"
            });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserDto dto)
        {
            await _userService.UpdateUserAsync(dto);

            return Ok(new
            {
                success = true,
                message = "User updated successfully"
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);

            return Ok(new
            {
                success = true,
                message = "User deleted successfully"
            });
        }
    }
}