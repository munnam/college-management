using CollegeManagementSystem.Models;

namespace CollegeManagementSystem.Interfaces
{
    public interface IAuthService
    {
        Task<UserDTO?> ValidateUserAsync(LoginUser user);
    }
}
