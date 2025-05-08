using CollegeManagementSystem.Interfaces;
using CollegeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollegeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService, IUserRoleService userRoleService) : ControllerBase
    {
        private readonly IUserService _userService = userService;
        private readonly IUserRoleService _userRoleService = userRoleService;

        [HttpGet("userroles")]
        public async Task<ActionResult<UserRoleDTO[]>> GetAllUserRoles()
        {
            var users = await _userRoleService.GetAllUserRolesAsync();
            return Ok(users);
        }

        [HttpGet("users/getall")]
        public async Task<ActionResult<UserDTO[]>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("user/{id:long}")]
        public async Task<ActionResult<UserDTO>> GetUserById(long id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateUser([FromBody] UserDTO userCreateDTO)
        {
            var result = await _userService.CreateUserAsync(userCreateDTO);
            return CreatedAtAction(nameof(GetUserById), result);
        }

        [HttpPut("user/{id:long}")]
        public async Task<ActionResult<UserDTO>> UpdateUser(long id, [FromBody] UserDTO userUpdateDTO)
        {
            var updatedUser = await _userService.UpdateUserAsync(id, userUpdateDTO);
            if (updatedUser == null)
                return NotFound();

            return Ok(updatedUser);
        }

    }
}
