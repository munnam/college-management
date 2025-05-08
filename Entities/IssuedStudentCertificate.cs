namespace CollegeManagementSystem.Entities;

public partial class IssuedStudentCertificate
{
    public long Id { get; set; }

    public string RollNo { get; set; } = null!;

    public string Certificate { get; set; } = null!;

    public DateTime? IssueDate { get; set; }

    public long? IssuedBy { get; set; }

    public string? ReceivedBy { get; set; }
}
