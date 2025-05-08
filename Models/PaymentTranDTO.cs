namespace CollegeManagementSystem.Models
{
    public class PaymentTranDTO
    {
        public long Id { get; set; }

        public string? RollNo { get; set; }

        public string? CourseCode { get; set; }

        public string? TransactionId { get; set; }

        public double Amount { get; set; }

        public int PaymentMode { get; set; }

        public DateTime? PaymentDate { get; set; }

        public string PaymentStatus { get; set; } = null!;
    }
}
