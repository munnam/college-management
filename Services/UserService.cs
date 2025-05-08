using AutoMapper;
using CollegeManagementSystem.Data;
using CollegeManagementSystem.Entities;
using CollegeManagementSystem.Interfaces;
using CollegeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace CollegeManagementSystem.Services
{
    public class UserService(AppDbContext context, IMapper mapper) : IUserService, IUserRoleService
    {
        public async Task<UserDTO[]> GetAllUsersAsync()
        {
            var users = await context.Users.ToArrayAsync();
            return mapper.Map<UserDTO[]>(users);
        }

        public async Task<UserDTO?> GetUserByIdAsync(long id)
        {
            var user = await context.Users.FindAsync(id);
            return user == null ? null : mapper.Map<UserDTO>(user);
        }

        public async Task<bool> CreateUserAsync(UserDTO userCreateDTO)
        {
            var user = mapper.Map<User>(userCreateDTO);
            // NOTE: When we store user Password the value stored in DB is base64Encoded
            user.Password = EncodeBase64(user.Password);
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateUserAsync(long id, UserDTO userUpdateDTO)
        {
            var user = await context.Users.FindAsync(id);
            if (user == null) return false;

            mapper.Map(userUpdateDTO, user);
            context.Users.Update(user);
            await context.SaveChangesAsync();
            return true;
        }

        async Task<UserRoleDTO[]> IUserRoleService.GetAllUserRolesAsync()
        {
            var userRoles = await context.UserRoles.ToArrayAsync();
            return mapper.Map<UserRoleDTO[]>(userRoles);
        }

        private static string EncodeBase64(string password)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(password); // Convert the plain text to byte array
            return Convert.ToBase64String(buffer);
        }
    }
}
