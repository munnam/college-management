using System;
using System.Collections.Generic;

namespace CollegeManagementSystem.Entities;

public partial class FeeTransaction
{
    public long Id { get; set; }

    public string RollNo { get; set; } = null!;

    public string CourseCode { get; set; } = null!;

    public string TransactionId { get; set; } = null!;

    public double Amount { get; set; }

    public int PaymentMode { get; set; }

    public DateTime? PaymentDate { get; set; }

    public string PaymentStatus { get; set; } = null!;

    public long? CreatedBy { get; set; }
}
