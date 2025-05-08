using CollegeManagementSystem.Models;

namespace CollegeManagementSystem.Interfaces
{
    public interface ICourseDetailService
    {
        Task<CourseDetailDTO[]> GetAllCoursesAsync();

        Task<CourseDetailDTO> GetCourseByIdAsync(int id);

        Task<bool> CreateCourseAsync(CourseDetailDTO courseDetail);

        Task<bool> UpdateCourseAsync(int id, CourseDetailDTO courseDetail);

        Task<bool> DeleteCourseAsync(int id);
    }
}
