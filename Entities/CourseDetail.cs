namespace CollegeManagementSystem.Entities;

public partial class CourseDetail
{
    public int Id { get; set; }

    public string CourseName { get; set; } = null!;

    public string CourseCode { get; set; } = null!;

    public double CourseFee { get; set; }

    public int CourseDuration { get; set; }

    public int? MaxDuration { get; set; }

    public int? NumSemesters { get; set; }

    public string? Description { get; set; }

    public sbyte? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public long? UpdatedBy { get; set; }
}
