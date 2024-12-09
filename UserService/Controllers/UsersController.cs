using Microsoft.AspNetCore.Mvc;
using UserService.Dto;
using UserService.Models;
using UserService.Services.Interface;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _UserService;

        public UsersController(IUserService UserService)
        {
            _UserService = UserService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var Users = await _UserService.GetAllUsers();
            return Ok(Users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var User = await _UserService.GetUserById(id);
            if (User == null)
            {
                return NotFound();
            }
            return Ok(User);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserDTO UserDTO)
        {
            var User = new Users
            {
                Username = UserDTO.Username,
                Email = UserDTO.Email,
                Password = UserDTO.Password,
            };

            await _UserService.AddUser(User);

            return CreatedAtAction(nameof(GetUserById), new { id = User.Id }, User);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDTO UserDTO)
        {
            var existingUser = await _UserService.GetUserById(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.Username = UserDTO.Username;
            existingUser.Email = UserDTO.Email;
            existingUser.Password = UserDTO.Password;

            await _UserService.UpdateUser(existingUser);

            return Ok(existingUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var existingUser = await _UserService.GetUserById(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            await _UserService.DeleteUser(id);
            return Ok(existingUser);
        }
    }
}
