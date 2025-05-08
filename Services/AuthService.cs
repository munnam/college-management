using AutoMapper;
using CollegeManagementSystem.Data;
using CollegeManagementSystem.Interfaces;
using CollegeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace CollegeManagementSystem.Services
{
    public class AuthService(AppDbContext dbContext, IMapper mapper) : IAuthService
    {
        // NOTE: When we store user Password the make sure that the value stored in DB is base64Encoded
        public async Task<UserDTO?> ValidateUserAsync(LoginUser user)
        {
            var userObj = await dbContext.Users
                .Where(u => u.UserName == user.UserName)
                .FirstOrDefaultAsync();

            if (userObj == null) { return null; }

            string decodedPassword = DecodeBase64(userObj == null ? string.Empty : userObj.Password);

            return decodedPassword == user?.Password ? mapper.Map<UserDTO>(userObj) : null ;
        }

        private static string DecodeBase64(string base64Encoded)
        {
            byte[] data = Convert.FromBase64String(base64Encoded);
            return Encoding.UTF8.GetString(data);
        }
    }
}
