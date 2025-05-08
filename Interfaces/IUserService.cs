using CollegeManagementSystem.Models;

namespace CollegeManagementSystem.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO[]> GetAllUsersAsync();

        Task<UserDTO?> GetUserByIdAsync(long id);

        Task<bool> CreateUserAsync(UserDTO userCreateDTO);

        Task<bool> UpdateUserAsync(long id, UserDTO userUpdateDTO);
    }

    public interface IUserRoleService
    {
        Task<UserRoleDTO[]> GetAllUserRolesAsync();
    }
}
