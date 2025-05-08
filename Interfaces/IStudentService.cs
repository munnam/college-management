using CollegeManagementSystem.Models;

namespace CollegeManagementSystem.Interfaces
{
    public interface IStudentService
    {
        Task<StudentDTO[]> GetAllStudentsAsync();

        Task<StudentDTO?> GetStudentByIdAsync(long id);

        Task<StudentDTO> CreateStudentAsync(StudentDTO studentDto);

        Task<bool> UpdateStudentAsync(long id, StudentDTO studentDto);

        Task<bool> DeleteStudentAsync(long id);
    }
}
