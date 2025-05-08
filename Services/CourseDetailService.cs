using AutoMapper;
using CollegeManagementSystem.Data;
using CollegeManagementSystem.Entities;
using CollegeManagementSystem.Interfaces;
using CollegeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagementSystem.Services
{
    public class CourseDetailService(AppDbContext dbCotext, IMapper mapper) : ICourseDetailService
    {
        public async Task<bool> CreateCourseAsync(CourseDetailDTO courseDetail)
        {
            var courseEntity = mapper.Map<CourseDetail>(courseDetail);
            dbCotext.CourseDetails.Add(courseEntity);
            await dbCotext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateCourseAsync(int id, CourseDetailDTO courseDetail)
        {
            var courseEntity = await dbCotext.CourseDetails
                                    .FirstOrDefaultAsync(c => c.Id == id);

            if (courseEntity == null) return false;

            mapper.Map(courseDetail, courseEntity);
            await dbCotext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            var courseEntity = await dbCotext.CourseDetails
                                    .FirstOrDefaultAsync(c => c.Id == id);

            if (courseEntity == null) return false;
            courseEntity.Status = 0;
            await dbCotext.SaveChangesAsync();

            return true;
        }

        public async Task<CourseDetailDTO[]> GetAllCoursesAsync()
        {
            var courses = await dbCotext.CourseDetails
              .Where(c => c.Status > 0).ToArrayAsync();

            return mapper.Map<CourseDetailDTO[]>(courses);
        }

        public async Task<CourseDetailDTO> GetCourseByIdAsync(int id)
        {
            var course = await dbCotext.CourseDetails
                                    .FirstOrDefaultAsync(c => c.Id == id);

            return mapper.Map<CourseDetailDTO>(course);
        }
    }
}
