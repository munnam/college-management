namespace CollegeManagementSystem.Models
{
    public class CourseDetailDTO
    {
        public int Id { get; set; }

        public string? CourseName { get; set; }

        public string? CourseCode { get; set; }

        public double CourseFee { get; set; }

        public int CourseDuration { get; set; }

        public int MaxDuration { get; set; }

        public int NumSemesters { get; set; }

        public string? Description { get; set; }

        public sbyte? Status { get; set; }
    }
}
