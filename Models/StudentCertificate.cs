namespace CollegeManagementSystem.Models
{
    public class StudentCertificate
    {
        public long Id { get; set; }

        public string? RollNo { get; set; }

        public string? Certificate { get; set; }

        public DateTime? IssueDate { get; set; }

        public long? IssuedBy { get; set; }
    }
}
