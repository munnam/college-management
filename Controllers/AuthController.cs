using CollegeManagementSystem.Interfaces;
using CollegeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollegeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService = authService;

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUser user)
        {
            var userObj = await _authService.ValidateUserAsync(user);

            if (userObj == null)
                return Unauthorized(new { message = "Invalid username or password" });

            return Ok(new { userObj.UserName, Role = userObj.UserRole });
        }
    }
}
