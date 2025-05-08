using AutoMapper;
using CollegeManagementSystem.Data;
using CollegeManagementSystem.Entities;
using CollegeManagementSystem.Interfaces;
using CollegeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagementSystem.Services
{
    public class StudentService(AppDbContext dbContext, IMapper mapper) : IStudentService
    {
        public async Task<StudentDTO> CreateStudentAsync(StudentDTO studentDto)
        {
            var studentEntity = mapper.Map<StudentDetail>(studentDto);
            dbContext.StudentDetails.Add(studentEntity);
            await dbContext.SaveChangesAsync();
            return mapper.Map<StudentDTO>(studentEntity);
        }

        public async Task<StudentDTO[]> GetAllStudentsAsync()
        {
            var students = await dbContext.StudentDetails
                .Select(s => s)
                .ToArrayAsync();

            return mapper.Map<StudentDTO[]>(students);
        }

        public async Task<StudentDTO?> GetStudentByIdAsync(long id)
        {
            var student = await dbContext.StudentDetails.FirstOrDefaultAsync(s => s.Id == id);
            return student == null ? null : mapper.Map<StudentDTO>(student);
        }

        public async Task<bool> UpdateStudentAsync(long id, StudentDTO studentDto)
        {
            var student = await dbContext.StudentDetails.FirstOrDefaultAsync(s => s.Id == id);
            if (student == null) return false;

            mapper.Map(studentDto, student);
            dbContext.StudentDetails.Update(student);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteStudentAsync(long id)
        {
            var student = await dbContext.StudentDetails.FirstOrDefaultAsync(s => s.Id == id);
            if (student == null) return false;
            student.Status = 0;
            dbContext.StudentDetails.Update(student);
            await dbContext.SaveChangesAsync();

            return true;
        }
    }
}
