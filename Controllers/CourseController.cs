using CollegeManagementSystem.Interfaces;
using CollegeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollegeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController(ICourseDetailService _courseDetailService) : ControllerBase
    {
        private readonly ICourseDetailService courseDetailService = _courseDetailService;

        // GET: api/Course/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await courseDetailService.GetCourseByIdAsync(id);

            if (course == null)
            {
                return NotFound(new { message = $"Course with ID {id} not found." });
            }

            return Ok(course);
        }

        // GET: api/Course/getall
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await courseDetailService.GetAllCoursesAsync();

            if (courses == null)
            {
                return NotFound(new { message = $"Courses not exists." });
            }

            return Ok(courses);
        }

        // POST: api/Course/
        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CourseDetailDTO courseDetail)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await courseDetailService.CreateCourseAsync(courseDetail);

            if (!result)
                return StatusCode(500, "An error occurred while creating the course.");

            return Ok("Course created successfully.");
        }

        // PUT: api/Course/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] CourseDetailDTO courseDetail)
        {
            // TODO: Srikanth Please check does we need the following code.
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            var result = await courseDetailService.UpdateCourseAsync(id, courseDetail);

            if (!result)
                return NotFound($"Course with ID {id} not found.");

            return Ok("Course updated successfully.");
        }

        // DELETE: api/Course/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var result = await courseDetailService.DeleteCourseAsync(id);

            if (!result)
                return NotFound($"Course with ID {id} not found.");

            return Ok("Course deleted successfully.");
        }

    }
}
