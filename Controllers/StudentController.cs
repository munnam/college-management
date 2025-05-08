using CollegeManagementSystem.Interfaces;
using CollegeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollegeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(IStudentService studentService) : ControllerBase
    {
        private readonly IStudentService _studentService = studentService;

        [HttpGet("students")]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpGet("student/{id}")]
        public async Task<IActionResult> GetStudent(long id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound(new { message = $"Student with ID {id} not found." });
            }
            return Ok(student);
        }
         
        [HttpPost("student")]
        public async Task<IActionResult> CreateStudent([FromBody] StudentDTO studentDto)
        {
            if (studentDto == null)
            {
                return BadRequest("Student data is required.");
            }

            var createdStudent = await _studentService.CreateStudentAsync(studentDto);
            return CreatedAtAction(nameof(GetStudent), new { id = createdStudent.Id }, createdStudent);
        }

        [HttpPut("student/{id}")]
        public async Task<IActionResult> UpdateStudent(long id, [FromBody] StudentDTO studentDto)
        {
            if (studentDto == null)
            {
                return BadRequest("Student data is required.");
            }

            var updatedStudent = await _studentService.UpdateStudentAsync(id, studentDto);
            if (updatedStudent == null)
            {
                return NotFound(new { message = $"Student with Id: {id} not found." });
            }

            return Ok(updatedStudent);
        }
    }
}
